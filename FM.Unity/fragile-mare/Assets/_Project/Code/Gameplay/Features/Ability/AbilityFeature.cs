using _Project.Code.Gameplay.Features.Ability.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Features.Ability
{
    public sealed class AbilityFeature : Feature
    {
        public AbilityFeature(ISystemsFactory systems)
        {
            Add(systems.Create<CooldownAbilitySystem>());

            Add(systems.Create<ApplyStatusesFromActiveAbilitiesSystem>());
            Add(systems.Create<ApplyEffectsFromActiveAbilitiesSystem>());

            Add(systems.Create<MarkAppliedAbilitiesAsNotReadyCleanupSystem>());
        }
    }
}