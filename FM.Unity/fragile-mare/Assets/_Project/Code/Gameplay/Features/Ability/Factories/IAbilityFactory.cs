using _Project.Code.Gameplay.Features.Ability.Configs;

namespace _Project.Code.Gameplay.Features.Ability.Factories
{
    public interface IAbilityFactory
    {
        GameEntity CreateAbility(AbilityConfig abilityConfig, int holderId);
    }
}