using Entitas;

namespace _Project.Code.Gameplay.Features.Movement.TransformPosition
{
    public class UpdateTransformPositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public UpdateTransformPositionSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.WorldPosition,
                GameMatcher.Transform));
        }
        public void Execute()
        {
            foreach (var entity in _entities)
            {
                entity.Transform.position = entity.WorldPosition;
            }
        }
    }
}