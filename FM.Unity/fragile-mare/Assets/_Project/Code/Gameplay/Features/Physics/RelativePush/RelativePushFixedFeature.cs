using _Project.Code.Gameplay.Features.Physics.RelativePush.Systems;
using _Project.Code.Gameplay.Features.Status.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Features.Physics.RelativePush
{
    public class RelativePushFixedFeature : Feature
    {
        public RelativePushFixedFeature(ISystemsFactory systems)
        {
            Add(systems.Create<ProcessSphereRelativePushStatusSystem>());
        }
    }
}