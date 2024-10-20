using _Project.Code.Common.Extensions;
using _Project.Code.Common.Services.Identifiers;
using _Project.Code.Gameplay.Features.Effect.Builders;

namespace _Project.Code.Gameplay.Features.Effect.Factories
{
    public class EffectFactory : IEffectFactory
    {
        private readonly IIdentifierService _identifierService;

        public EffectFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateEffect<TBuilder>(TBuilder builder, int targetId, int producerId) 
            where TBuilder : IEffectBuilder
        {
            return builder
                .Build()
                .AddId(_identifierService.Next())
                .AddTargetId(targetId)
                .AddProducerId(producerId)
                .With(e => e.isEffect = true);
        }
    }
}