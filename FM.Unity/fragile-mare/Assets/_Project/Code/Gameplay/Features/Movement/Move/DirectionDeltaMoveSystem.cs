using _Project.Code.Common.Services.Time;
using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Movement.Move
{
    public class DirectionDeltaMoveSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _movers;

        public DirectionDeltaMoveSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _movers = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Moving,
                GameMatcher.WorldPosition,
                GameMatcher.Speed,
                GameMatcher.Direction
            ));
        }
        
        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                var direction = new Vector3(mover.Direction.x, 0, mover.Direction.y);
                mover.ReplaceWorldPosition(mover.WorldPosition +
                                           direction.normalized * mover.Speed * _time.DeltaTime);
            }
        }
    }
}