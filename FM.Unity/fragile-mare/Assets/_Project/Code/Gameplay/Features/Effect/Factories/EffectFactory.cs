using System;
using _Project.Code.Common.Entity;
using _Project.Code.Common.Extensions;
using _Project.Code.Common.Services.Identifiers;
using _Project.Code.Gameplay.Features.Effect.Configs;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Effect.Factories
{
    public class EffectFactory : IEffectFactory
    {
        private readonly IIdentifierService _identifierService;

        public EffectFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateEffect(EffectSetup effectSetup, int targetId, int producerId)
        {
            GameEntity entity;

            switch (effectSetup.type)
            {
                case EffectType.Impulse:
                    entity = CreateImpulseEffect(effectSetup.direction);
                    break;
                case EffectType.Dash:
                    entity = CreateDashEffect();
                    break;
                default:
                    throw new Exception($"Unknown effect with type id {effectSetup.type}");
            }

            return entity
                .AddId(_identifierService.Next())
                .AddTargetId(targetId)
                .AddProducerId(producerId)
                .AddEffectTypeId(effectSetup.type)
                .AddEffectValue(effectSetup.value)
                .With(e => e.isEffect = true);
        }

        private GameEntity CreateDashEffect()
        {
            return CreateEntity.Empty()
                .With(e => e.isDashEffect = true);
        }

        private GameEntity CreateImpulseEffect(Vector3 direction)
        {
            return CreateEntity.Empty()
                .AddDirection3(direction)
                .With(e => e.isImpulseEffect = true);
        }
    }
}