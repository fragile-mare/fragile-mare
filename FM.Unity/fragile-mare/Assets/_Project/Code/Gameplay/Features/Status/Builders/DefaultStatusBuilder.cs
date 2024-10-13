using System;
using _Project.Code.Common.Entity;
using _Project.Code.Common.Extensions;

namespace _Project.Code.Gameplay.Features.Status.Builders
{
    [Serializable]
    public class DefaultStatusBuilder : IStatusBuilder
    {
        public float value;
        public float duration;
        
        public virtual GameEntity Build()
        {
            return CreateEntity.Empty()
                .AddEffectValue(value)
                .With(e => e.AddDurationTimer(duration), when: duration > 0);
        }
    }
}