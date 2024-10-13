using System;
using _Project.Code.Common.Entity;
using _Project.Code.Common.Extensions;

namespace _Project.Code.Gameplay.Features.Effect.Builders
{
    [Serializable]
    public class DefaultEffectBuilder : IEffectBuilder
    {
        public float value;
        
        public virtual GameEntity Build()
        {
            return CreateEntity.Empty()
                .AddEffectValue(value)
                .With(e => e.isImpulseEffect = true);
        }
    }
}