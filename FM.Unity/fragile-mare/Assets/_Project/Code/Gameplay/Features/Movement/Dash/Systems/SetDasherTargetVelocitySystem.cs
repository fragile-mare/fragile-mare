using _Project.Code.Infrastructure.VectorExtensions;
using Entitas;

namespace _Project.Code.Gameplay.Features.Movement.Dash.Systems
{
    public class SetDasherTargetVelocitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _accelerations;
        private readonly IGroup<GameEntity> _dashers;

        public SetDasherTargetVelocitySystem(GameContext game)
        {
            _dashers = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Id,
                    GameMatcher.Dashing,
                    GameMatcher.Rigidbody));
            _accelerations = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.AccelerationStatus,
                    GameMatcher.TargetVelocity,
                    GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _dashers)
            foreach (GameEntity acceleration in _accelerations)
            {
                if (mover.Id != acceleration.TargetId)
                    continue;

                if (mover.isMoving) mover.isMoving = false;
                if (mover.isSprinting) mover.isSprinting = false;

                acceleration.ReplaceTargetVelocity(mover.DashDirection.XZVector3() * mover.DashSpeed);
            }
        }
    }
}