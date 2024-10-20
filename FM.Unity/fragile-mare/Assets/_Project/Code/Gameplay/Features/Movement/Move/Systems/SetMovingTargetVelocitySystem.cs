using _Project.Code.Infrastructure.VectorExtensions;
using Entitas;

namespace _Project.Code.Gameplay.Features.Movement.Move.Systems
{
    public class SetMovingTargetVelocitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _accelerations;
        private readonly IGroup<GameEntity> _movers;

        public SetMovingTargetVelocitySystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Id,
                    GameMatcher.Moving,
                    GameMatcher.Rigidbody));
            _accelerations = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.AccelerationStatus,
                    GameMatcher.TargetVelocity,
                    GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            foreach (GameEntity acceleration in _accelerations)
            {
                if (mover.Id != acceleration.TargetId)
                    continue;

                acceleration.ReplaceTargetVelocity(mover.Direction.XZVector3() * mover.Speed);
            }
        }
    }
}