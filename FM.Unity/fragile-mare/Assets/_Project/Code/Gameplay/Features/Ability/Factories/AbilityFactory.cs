using System;
using System.Collections.Generic;
using _Project.Code.Common.Entity;
using _Project.Code.Common.Extensions;
using _Project.Code.Common.Services.Identifiers;
using _Project.Code.Gameplay.Features.Ability.Configs;

namespace _Project.Code.Gameplay.Features.Ability.Factories
{
    public class AbilityFactory : IAbilityFactory
    {
        private readonly IIdentifierService _identifierService;

        public AbilityFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateAbility(AbilityConfig abilityConfig, int holderId)
        {
            GameEntity entity;

            switch (abilityConfig.type)
            {
                case AbilityType.Dash:
                    entity = CreateDashAbility();
                    break;
                case AbilityType.SphereRelativePush:
                    entity = CreateSphereRelativePushAbility();
                    break;
                default:
                    throw new Exception($"Unknown ability with type id {abilityConfig.type}");
            }

            return entity
                .AddId(_identifierService.Next())
                .AddHolderId(holderId)
                .AddTargetBuffer(new List<int> { holderId })
                .AddAbilityType(abilityConfig.type)
                .AddStatusList(abilityConfig.statuses)
                .AddEffectList(abilityConfig.effects)
                .AddCooldownInterval(abilityConfig.cooldown)
                .AddCooldownTimer(0)
                .With(e => e.isAbility = true);
        }


        private GameEntity CreateDashAbility()
        {
            return CreateEntity.Empty()
                .With(e => e.isDashAbility = true);
        }


        private GameEntity CreateSphereRelativePushAbility()
        {
            return CreateEntity.Empty()
                .With(e => e.isSphereRelativePushAbility = true);
        }
    }
}