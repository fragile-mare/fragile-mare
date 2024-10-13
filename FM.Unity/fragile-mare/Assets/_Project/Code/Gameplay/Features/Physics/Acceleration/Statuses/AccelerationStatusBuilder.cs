using System;
using _Project.Code.Common.Extensions;
using _Project.Code.Gameplay.Features.Status.Builders;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Physics.Acceleration.Statuses
{
    [Serializable]
    public class AccelerationStatusBuilder : DefaultStatusBuilder
    {
        public Vector3 deltaAxis;
        
        public override GameEntity Build()
        {
            return base
                .Build()
                .AddTargetVelocity(Vector3.zero)
                .AddDeltaAxis(deltaAxis)
                .With(e => e.isAccelerationStatus = true);
        }
    }
}