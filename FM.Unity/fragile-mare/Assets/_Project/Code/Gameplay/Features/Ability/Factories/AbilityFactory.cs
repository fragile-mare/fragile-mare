using System.Collections.Generic;
using _Project.Code.Common.Extensions;
using _Project.Code.Common.Services.Identifiers;
using _Project.Code.Gameplay.Features.Ability.Builders;
using _Project.Code.Infrastructure.CustomUnity;

namespace _Project.Code.Gameplay.Features.Ability.Factories
{
    public class AbilityFactory : IAbilityFactory
    {
        private readonly IIdentifierService _identifierService;

        public AbilityFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateAbility<TBuilder>(TBuilder builder, int holderId) 
            where TBuilder : IAbilityBuilder
        {
            return builder
                .Build()
                .AddId(_identifierService.Next())
                .AddHolderId(holderId)
                .AddTargetBuffer(new List<int> { holderId })
                .With(e => e.isAbility = true);
        }
    }
}