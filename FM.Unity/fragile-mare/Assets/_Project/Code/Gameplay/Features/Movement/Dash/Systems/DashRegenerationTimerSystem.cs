using System.Collections.Generic;
using _Project.Code.Common.Services.Time;
using Entitas;

namespace _Project.Code.Gameplay.Features.Movement.Dash.Systems
{
    public class DashRegenerationTimerSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(64);

        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _dashers;

        public DashRegenerationTimerSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _dashers = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.DashMaxCount,
                GameMatcher.DashCurrentCount,
                GameMatcher.DashRegenDuration,
                GameMatcher.DashRegenTimer,
                GameMatcher.DashRegenAmount
            ));
        }

        public void Execute()
        {
            foreach (GameEntity dasher in _dashers) // _dashers.GetEntities(_buffer)) // todo: remove buffer?
            {
                if (dasher.DashCurrentCount >= dasher.DashMaxCount)
                {
                    dasher.ReplaceDashRegenTimer(dasher.DashRegenDuration);
                    continue;
                }
                
                dasher.ReplaceDashRegenTimer(dasher.DashRegenTimer - _time.DeltaTime);

                if (dasher.DashRegenTimer > 0) continue;
                
                var toApply = dasher.hasDashRegenAmountToApply ? dasher.DashRegenAmountToApply : 0;
                dasher.ReplaceDashRegenAmountToApply(toApply + dasher.DashRegenAmount);
                
                dasher.ReplaceDashRegenTimer(dasher.DashRegenDuration);
            }
        }
    }
}