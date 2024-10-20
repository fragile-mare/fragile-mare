using _Project.Code.Common.Services.Time;
using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Movement.Move.Systems
{
    public class DirectionDeltaMoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;
        private readonly ITimeService _time;

        public DirectionDeltaMoveSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _movers = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.CanMove,
                GameMatcher.Moving,
                GameMatcher.WorldPosition,
                GameMatcher.Speed,
                GameMatcher.Direction
            ).NoneOf(GameMatcher.Rigidbody));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                var worldDirection = new Vector3(mover.Direction.x, 0, mover.Direction.y);
                mover.ReplaceWorldPosition(mover.WorldPosition +
                                           worldDirection.normalized * mover.Speed * _time.DeltaTime);
            }
        }
    }
}