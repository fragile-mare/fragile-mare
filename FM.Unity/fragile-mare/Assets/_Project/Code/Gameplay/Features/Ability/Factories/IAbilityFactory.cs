using _Project.Code.Gameplay.Features.Ability.Builders;

namespace _Project.Code.Gameplay.Features.Ability.Factories
{
    public interface IAbilityFactory
    {
        GameEntity CreateAbility<TBuilder>(TBuilder builder, int holderId)
            where TBuilder : IAbilityBuilder;
    }
}