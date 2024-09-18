using _Project.Code.Common.Entity;
using _Project.Code.Common.Extensions;
using _Project.Code.Common.Services.Identifiers;
using _Project.Code.Common.Services.StaticData;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Character.Factory
{
    public class CharacterFactory : ICharacterFactory
    {
        private readonly IIdentifierService _identifiers;
        private readonly IStaticDataService _staticData;

        public CharacterFactory(IIdentifierService identifiers, IStaticDataService staticData)
        {
            _identifiers = identifiers;
            _staticData = staticData;
        }
        
        public GameEntity CreateCharacter(Vector3 at, Quaternion rotation)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddWorldPosition(at)
                .AddDirection(Vector2.zero)
                .AddViewPrefab(_staticData.CharacterConfig.prefab)
                .AddSpeed(_staticData.CharacterConfig.speed)
                .AddSprintSpeed(_staticData.CharacterConfig.sprintSpeed)
                .AddDashSpeed(_staticData.CharacterConfig.dashSpeed)
                .AddDashDuration(_staticData.CharacterConfig.dashDuration)
                .AddDashTimer(0)
                .AddDashMaxCount(_staticData.CharacterConfig.dashMaxCount)
                .AddDashCurrentCount(_staticData.CharacterConfig.dashMaxCount)
                .AddDashRegenDuration(_staticData.CharacterConfig.dashRegenDuration)
                .AddDashRegenTimer(_staticData.CharacterConfig.dashRegenDuration)
                .AddDashRegenAmount(_staticData.CharacterConfig.dashRegenAmount)
                .AddCurrentEnergy(_staticData.CharacterConfig.currentEnergy)
                .AddMaxEnergy(_staticData.CharacterConfig.maxEnergy)
                .AddEnergyToApply(0)
                .AddEnergyToRegen(_staticData.CharacterConfig.energyToRegen)
                .With(x =>x.isEnergyType = false)
                .With(x => x.isCharacter = true)
                .With(x => x.isCanMove = true)
                .With(x => x.isCanSprint = true)
                .With(x => x.isCanDash = true);
        }
    }
}