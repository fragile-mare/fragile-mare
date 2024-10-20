using _Project.Code.Gameplay.Features.Effect.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Features.Effect
{
    public class EffectFeature : Feature
    {
        public EffectFeature(ISystemsFactory systems)
        {
            Add(systems.Create<DestroyAppliedEffectsCleanupSystem>());
        }
    }
}