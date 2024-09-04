using System.Collections.Generic;
using Entitas;

namespace _Project.Code.Gameplay.Features.Movement.Dash.Systems
{
    public class DashActivationSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(64);
        
        private readonly IGroup<GameEntity> _dashers;

        public DashActivationSystem(GameContext game)
        {
            _dashers = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.DashActivated,
                GameMatcher.DashDuration,
                GameMatcher.DashTimer
            ).NoneOf(
                GameMatcher.Dashing));
        }
        
        public void Execute()
        {
            foreach (GameEntity dasher in _dashers.GetEntities(_buffer))
            {
                if (dasher.hasDashCurrentCount)
                {
                    var curr = dasher.DashCurrentCount;
                    if(curr <= 0) continue;
                    dasher.ReplaceDashCurrentCount(curr - 1);
                }
                
                dasher.isDashing = true;
                dasher.ReplaceDashTimer(dasher.DashDuration);
            }
        }
    }
}