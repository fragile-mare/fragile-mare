using _Project.Code.Gameplay.Features.Physics.Acceleration.Systems;
using _Project.Code.Gameplay.Features.Physics.Impulse;
using _Project.Code.Gameplay.Features.Physics.RelativePush;
using _Project.Code.Gameplay.Features.Status.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Features.Physics
{
    public class PhysicsFixedFeature : Feature
    {
        public PhysicsFixedFeature(ISystemsFactory systems)
        {
            Add(systems.Create<ImpulseFixedFeature>());
            Add(systems.Create<RelativePushFixedFeature>());
            Add(systems.Create<ProcessAccelerationStatusSystem>());
        }
    }
}