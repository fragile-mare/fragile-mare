using _Project.Code.Gameplay.Features.Physics.Impulse.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Features.Physics.Impulse
{
    public class ImpulseFixedFeature : Feature
    {
        public ImpulseFixedFeature(ISystemsFactory systems)
        {
            Add(systems.Create<ApplyImpulseEffectSystem>());
        }
    }
}