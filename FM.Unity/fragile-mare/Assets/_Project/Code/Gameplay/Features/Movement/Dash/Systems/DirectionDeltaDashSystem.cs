using _Project.Code.Common.Services.Time;
using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Movement.Dash.Systems
{
    public class DirectionDeltaDashSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _movers;

        public DirectionDeltaDashSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _movers = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.CanDash,
                GameMatcher.Dashing,
                GameMatcher.WorldPosition,
                GameMatcher.DashSpeed,
                GameMatcher.DashDirection
            ));
        }
        
        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                if (mover.isMoving) mover.isMoving = false;
                if (mover.isSprinting) mover.isSprinting = false;

                var direction = new Vector3(mover.DashDirection.x, 0, mover.DashDirection.y);
                mover.ReplaceWorldPosition(mover.WorldPosition +
                                           direction.normalized * mover.DashSpeed * _time.DeltaTime);
            }
        }
    }
}