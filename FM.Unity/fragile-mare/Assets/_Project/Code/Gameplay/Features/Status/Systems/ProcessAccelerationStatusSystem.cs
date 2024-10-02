using _Project.Code.Gameplay.Features.Effect;
using _Project.Code.Gameplay.Features.Effect.Configs;
using _Project.Code.Gameplay.Features.Effect.Factories;
using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Status.Systems
{
    public class ProcessAccelerationStatusSystem : IExecuteSystem
    {
        private readonly IEffectFactory _effectFactory;
        private readonly IGroup<GameEntity> _statuses;
        private readonly IGroup<GameEntity> _targets;

        public ProcessAccelerationStatusSystem(GameContext game, IEffectFactory effectFactory)
        {
            _effectFactory = effectFactory;
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AccelerationStatus,
                    GameMatcher.TargetId,
                    GameMatcher.TargetVelocity,
                    GameMatcher.EffectValue,
                    GameMatcher.DeltaAxis)
                .NoneOf(GameMatcher.Expired));
            _targets = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Rigidbody));
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

                var delta = status.TargetVelocity - target.Rigidbody.velocity;

                delta.x *= status.DeltaAxis.x;
                delta.y *= status.DeltaAxis.y;
                delta.z *= status.DeltaAxis.z;

                if (delta.magnitude > 0.1)
                {
                    _effectFactory.CreateEffect(new EffectSetup
                    {
                        type = EffectType.Impulse,
                        direction = delta.normalized,
                        value = Mathf.Clamp(delta.magnitude, 0, 1) * status.EffectValue
                    }, target.Id, GetProducerId(status));
                }
            }
        }

        private static int GetProducerId(GameEntity status)
        {
            return status.hasProducerId ? status.ProducerId : status.Id;
        }
    }
}