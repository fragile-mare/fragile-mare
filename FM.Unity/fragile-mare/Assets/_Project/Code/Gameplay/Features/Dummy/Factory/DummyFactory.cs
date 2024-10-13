using _Project.Code.Common.Entity;
using _Project.Code.Common.Extensions;
using _Project.Code.Common.Services.Identifiers;
using _Project.Code.Gameplay.Features.Ability.Factories;
using _Project.Code.Gameplay.Features.Dummy.Configs;

namespace _Project.Code.Gameplay.Features.Dummy.Factory
{
    public class DummyFactory : IDummyFactory
    {
        private readonly IAbilityFactory _abilityFactory;
        private readonly IIdentifierService _identifiers;

        public DummyFactory(IIdentifierService identifiers, IAbilityFactory abilityFactory)
        {
            _identifiers = identifiers;
            _abilityFactory = abilityFactory;
        }

        public GameEntity CreateDummy(DummyConfig dummyConfig)
        {
            GameEntity dummy = CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddWorldPosition(dummyConfig.at)
                .AddViewPrefab(dummyConfig.prefab)
                .With(e => e.isForceMovePosition = true)
                .With(e => e.isDummy = true);

            foreach (var config in dummyConfig.abilities)
            {
                _abilityFactory.CreateAbility(config.ability.Current, dummy.Id);
            }

            return dummy;
        }
    }
}