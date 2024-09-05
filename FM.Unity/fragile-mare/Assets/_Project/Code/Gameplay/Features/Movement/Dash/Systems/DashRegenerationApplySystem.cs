using System;
using System.Collections.Generic;
using _Project.Code.Common.Services.Time;
using Entitas;

namespace _Project.Code.Gameplay.Features.Movement.Dash.Systems
{
    public class DashRegenerationApplySystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(64);

        private readonly IGroup<GameEntity> _dashers;

        public DashRegenerationApplySystem(GameContext game)
        {
            _dashers = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.DashMaxCount,
                GameMatcher.DashCurrentCount,
                GameMatcher.DashRegenAmountToApply
            ));
        }

        public void Execute()
        {
            foreach (GameEntity dasher in _dashers.GetEntities(_buffer))
            {
                var requiredCount = dasher.DashCurrentCount + dasher.DashRegenAmountToApply;
                
                dasher.ReplaceDashCurrentCount(Math.Min(dasher.DashMaxCount, requiredCount));

                dasher.RemoveDashRegenAmountToApply();
            }
        }
    }
}