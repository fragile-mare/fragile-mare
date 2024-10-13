using System;
using _Project.Code.Common.Extensions;
using _Project.Code.Gameplay.Features.Status.Builders;

namespace _Project.Code.Gameplay.Features.Physics.RelativePush.Statuses
{
    [Serializable]
    public class SphereRelativePushStatusBuilder : DefaultStatusBuilder
    {
        public float radius;
        
        public override GameEntity Build()
        {
            return base
                .Build()
                .AddRadius(radius)
                .With(e => e.isSphereRelativePushStatus = true);
        }
    }
}