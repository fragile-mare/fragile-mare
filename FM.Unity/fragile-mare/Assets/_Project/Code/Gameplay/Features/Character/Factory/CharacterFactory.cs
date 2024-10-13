using _Project.Code.Common.Entity;
using _Project.Code.Common.Extensions;
using _Project.Code.Common.Services.Identifiers;
using _Project.Code.Common.Services.StaticData;
using _Project.Code.Gameplay.Features.Ability.Factories;
using _Project.Code.Gameplay.Features.Status.Factories;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Character.Factory
{
    public class CharacterFactory : ICharacterFactory
    {
        private readonly IAbilityFactory _abilityFactory;
        private readonly IIdentifierService _identifiers;
        private readonly IStaticDataService _staticData;
        private readonly IStatusFactory _statusFactory;

        public CharacterFactory(IIdentifierService identifiers, IStatusFactory statusFactory,
            IAbilityFactory abilityFactory, IStaticDataService staticData)
        {
            _identifiers = identifiers;
            _statusFactory = statusFactory;
            _abilityFactory = abilityFactory;
            _staticData = staticData;
        }

        public GameEntity CreateCharacter(Vector3 at, Quaternion rotation)
        {
            GameEntity character = CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddWorldPosition(at)
                .AddDirection(Vector2.zero)
                .AddViewPrefab(_staticData.CharacterConfig.prefab)
                .AddSpeed(_staticData.CharacterConfig.speed)
                .AddCurrentEnergy(_staticData.CharacterConfig.currentEnergy)
                .AddMaxEnergy(_staticData.CharacterConfig.maxEnergy)
                .AddEnergyToApply(0)
                .AddEnergyToRegen(_staticData.CharacterConfig.energyToRegen)
                .With(x => x.isEnergyType = false)
                .With(x => x.isCharacter = true)
                .With(x => x.isCanMove = true)
                .With(x => x.isForceMovePosition = true);

            foreach (var config in _staticData.CharacterConfig.statuses)
            {
                _statusFactory.CreateStatus(config.status.Current, character.Id, character.Id);
            }

            foreach (var ability in _staticData.CharacterConfig.abilities)
            {
                _abilityFactory.CreateAbility(ability.ability.Current, character.Id);
            }


            return character;
        }
    }
}