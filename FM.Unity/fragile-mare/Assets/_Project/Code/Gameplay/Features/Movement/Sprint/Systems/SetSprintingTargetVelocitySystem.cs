using _Project.Code.Infrastructure.VectorExtensions;
using Entitas;

namespace _Project.Code.Gameplay.Features.Movement.Sprint.Systems
{
    public class SetSprintingTargetVelocitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _accelerations;
        private readonly IGroup<GameEntity> _sprinters;

        public SetSprintingTargetVelocitySystem(GameContext game)
        {
            _sprinters = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Id,
                    GameMatcher.CanSprint,
                    GameMatcher.Sprinting,
                    GameMatcher.Rigidbody));
            _accelerations = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.AccelerationStatus,
                    GameMatcher.TargetVelocity,
                    GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _sprinters)
            foreach (GameEntity acceleration in _accelerations)
            {
                if (mover.Id != acceleration.TargetId)
                    continue;

                if (mover.isMoving) mover.isMoving = false;

                acceleration.ReplaceTargetVelocity(mover.Direction.XZVector3() * mover.SprintSpeed);
            }
        }
    }
}