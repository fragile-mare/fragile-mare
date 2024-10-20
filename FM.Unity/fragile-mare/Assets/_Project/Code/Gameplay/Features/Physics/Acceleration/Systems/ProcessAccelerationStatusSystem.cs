using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Physics.Acceleration.Systems
{
    public class ProcessAccelerationStatusSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly IGroup<GameEntity> _targets;

        public ProcessAccelerationStatusSystem(GameContext game)
        {
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AccelerationStatus,
                    GameMatcher.TargetId,
                    GameMatcher.TargetVelocity,
                    GameMatcher.AppliableAxis)
                .NoneOf(GameMatcher.Expired));
            _targets = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Velocity));
        }

        public void Execute()
        {
            foreach (GameEntity status in _statuses)
            foreach (GameEntity target in _targets)
            {
                if (status.TargetId != target.Id)
                {
                    continue;
                }

                Vector3 currentVelocity = target.Velocity;
                Vector3 targetVelocity = status.TargetVelocity;

                currentVelocity.Scale(status.AppliableAxis - Vector3.one);
                currentVelocity.Scale(-Vector3.one);
                targetVelocity.Scale(status.AppliableAxis);
                
                targetVelocity += currentVelocity;

                target.ReplaceVelocity(targetVelocity);
            }
        }
    }
}