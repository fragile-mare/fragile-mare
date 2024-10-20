using _Project.Code.Common.Services.Time;
using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Movement.Sprint.Systems
{
    public class DirectionDeltaSprintSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;
        private readonly ITimeService _time;

        public DirectionDeltaSprintSystem(GameContext game, ITimeService time)
        {
            _movers = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.CanSprint,
                GameMatcher.Sprinting,
                GameMatcher.SprintSpeed,
                GameMatcher.WorldPosition,
                GameMatcher.Direction
            ).NoneOf(GameMatcher.Rigidbody));
            _time = time;
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                if (mover.isMoving) mover.isMoving = false;

                var direction = new Vector3(mover.Direction.x, 0, mover.Direction.y);
                mover.ReplaceWorldPosition(mover.WorldPosition +
                                           direction.normalized * mover.SprintSpeed * _time.DeltaTime);
            }
        }
    }
}