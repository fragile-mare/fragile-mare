using System.Collections.Generic;
using Entitas;

namespace _Project.Code.Gameplay.Features.Movement.TransformPosition
{
    public class UpdateRigidbodyPositionSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(16);
        private readonly IGroup<GameEntity> _rigidbodies;

        public UpdateRigidbodyPositionSystem(GameContext game)
        {
            _rigidbodies = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.WorldPosition,
                    GameMatcher.Rigidbody));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _rigidbodies.GetEntities(_buffer))
            {
                entity.Rigidbody.position = entity.WorldPosition;
                entity.isForceMovePosition = false;
            }
        }
    }
}