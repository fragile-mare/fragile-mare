using Entitas;

namespace _Project.Code.Gameplay.Features.Physics.Systems
{
    public class GetVelocitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public GetVelocitySystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Rigidbody, GameMatcher.Velocity));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.ReplaceVelocity(entity.Rigidbody.velocity);
            }
        }
    }
}