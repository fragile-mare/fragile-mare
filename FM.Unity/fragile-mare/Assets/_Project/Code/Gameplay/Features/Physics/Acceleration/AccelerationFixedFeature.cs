using _Project.Code.Gameplay.Features.Physics.Acceleration.Systems;
using _Project.Code.Gameplay.Features.Status.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Features.Physics.Acceleration
{
    public class AccelerationFixedFeature : Feature
    {
        public AccelerationFixedFeature(ISystemsFactory systems)
        {
            Add(systems.Create<ProcessAccelerationStatusSystem>());

        }
    }
}