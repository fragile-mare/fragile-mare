using System;
using _Project.Code.Common.Extensions;

namespace _Project.Code.Gameplay.Features.Physics.Acceleration.Statuses
{
    [Serializable]
    public class AccelerationInputStatusBuilder : AccelerationStatusBuilder
    {
        public override GameEntity Build()
        {
            return base
                .Build()
                .With(e => e.isInputAccelerationStatus = true);
        }
    }
}