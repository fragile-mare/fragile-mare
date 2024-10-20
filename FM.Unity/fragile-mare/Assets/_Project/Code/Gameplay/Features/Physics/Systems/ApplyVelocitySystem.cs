using Entitas;

namespace _Project.Code.Gameplay.Features.Physics.Systems
{
    public class ApplyVelocitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public ApplyVelocitySystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Rigidbody,
                    GameMatcher.CanMove,
                    GameMatcher.Velocity));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.Rigidbody.velocity = entity.Velocity;
            }
        }
    }
}