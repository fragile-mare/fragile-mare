using System;
using _Project.Code.Common.Extensions;
using _Project.Code.Gameplay.Features.Effect.Builders;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Physics.Impulse.Effects
{
    [Serializable]
    public class ImpulseEffectBuilder : DefaultEffectBuilder
    {
        public Vector3 direction;
        
        public override GameEntity Build()
        {
            return base
                .Build()
                .AddDirection3(direction)
                .With(e => e.isImpulseEffect = true);
        }
    }
}