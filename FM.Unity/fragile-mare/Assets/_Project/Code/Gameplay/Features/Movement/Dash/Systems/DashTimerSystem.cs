using System.Collections.Generic;
using _Project.Code.Common.Services.Time;
using Entitas;

namespace _Project.Code.Gameplay.Features.Movement.Dash.Systems
{
    public class DashTimerSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(64);
        
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _dashers;

        public DashTimerSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _dashers = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Dashing,
                GameMatcher.DashTimer
            ));
        }
        
        public void Execute()
        {
            foreach (GameEntity dasher in _dashers.GetEntities(_buffer))
            {
                dasher.ReplaceDashTimer(dasher.DashTimer - _time.DeltaTime);

                if (dasher.DashTimer <= 0)
                {
                    dasher.isDashing = false;
                }
            }
        }
    }
}