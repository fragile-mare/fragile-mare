using _Project.Code.Common.Services.Physics;
using _Project.Code.Gameplay.Features.Effect.Factories;
using _Project.Code.Gameplay.Features.Physics.Impulse.Effects;
using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Physics.RelativePush.Systems
{
    public class ProcessSphereRelativePushStatusSystem : IExecuteSystem
    {
        private readonly GameEntity[] _buffer = new GameEntity[16];
        private readonly IEffectFactory _effectFactory;
        private readonly IPhysicsService _physics;
        private readonly IGroup<GameEntity> _producers;
        private readonly IGroup<GameEntity> _statuses;

        public ProcessSphereRelativePushStatusSystem(GameContext game, IEffectFactory effectFactory,
            IPhysicsService physics)
        {
            _effectFactory = effectFactory;
            _physics = physics;
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.SphereRelativePushStatus,
                    GameMatcher.TargetId,
                    GameMatcher.Radius,
                    GameMatcher.EffectValue)
                .NoneOf(GameMatcher.Expired));
            _producers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Rigidbody));
        }

        public void Execute()
        {
            foreach (GameEntity status in _statuses)
            foreach (GameEntity producer in _producers)
            {
                if (status.TargetId != producer.Id)
                {
                    continue;
                }

                int hits = _physics.SphereCastNonAlloc(producer.Transform.position, status.Radius,
                    (1 << LayerMask.NameToLayer("PC")) | (1 << LayerMask.NameToLayer("NPC")), _buffer);

                for (int i = 0; i < hits; i++)
                {
                    GameEntity target = _buffer[i];

                    if (!target.hasTransform || !target.hasVelocity || !target.hasId || target.Id == producer.Id)
                        continue;

                    Vector3 distance = target.Transform.position - producer.Transform.position;

                    float force = Mathf.Clamp01(1 - distance.magnitude / status.Radius) * status.EffectValue;

                    target.ReplaceVelocity(target.Velocity + distance.normalized * force);
                }
            }
        }

        private static int GetProducerId(GameEntity status)
        {
            return status.hasProducerId ? status.ProducerId : status.Id;
        }
    }
}