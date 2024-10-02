using _Project.Code.Gameplay.Features.Status.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Features.Status
{
    public sealed class StatusFixedFeature : Feature
    {
        public StatusFixedFeature(ISystemsFactory systems)
        {
            Add(systems.Create<ProcessAccelerationStatusSystem>());
            Add(systems.Create<ProcessSphereRelativePushStatusSystem>());
        }
    }
}