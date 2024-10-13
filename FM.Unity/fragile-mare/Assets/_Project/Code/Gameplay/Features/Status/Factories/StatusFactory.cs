using _Project.Code.Common.Extensions;
using _Project.Code.Common.Services.Identifiers;
using _Project.Code.Gameplay.Features.Status.Builders;
using _Project.Code.Gameplay.Features.Status.Configs;
using UnityEngine.Serialization;

namespace _Project.Code.Gameplay.Features.Status.Factories
{
    public class StatusFactory : IStatusFactory
    {
        private readonly IIdentifierService _identifierService;

        public StatusFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateStatus<TBuilder>(TBuilder builder, int targetId, int producerId) 
            where TBuilder : IStatusBuilder
        {
            return builder
                .Build()
                .AddId(_identifierService.Next())
                .AddTargetId(targetId)
                .AddProducerId(producerId)
                .With(e => e.isStatus = true);
        }
    }
}