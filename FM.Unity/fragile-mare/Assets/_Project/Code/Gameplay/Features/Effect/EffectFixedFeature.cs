using _Project.Code.Gameplay.Features.Effect.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Features.Effect
{
    public class EffectFixedFeature : Feature
    {
        public EffectFixedFeature(ISystemsFactory systems)
        {
            Add(systems.Create<ApplyImpulseEffectSystem>());
            Add(systems.Create<ApplyDashEffectSystem>());
        }
    }
}