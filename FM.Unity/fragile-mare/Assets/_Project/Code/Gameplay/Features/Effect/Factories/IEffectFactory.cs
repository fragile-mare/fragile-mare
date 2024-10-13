using _Project.Code.Gameplay.Features.Effect.Builders;

namespace _Project.Code.Gameplay.Features.Effect.Factories
{
    public interface IEffectFactory
    {
        GameEntity CreateEffect<TBuilder>(TBuilder builder, int targetId, int producerId) 
            where TBuilder : IEffectBuilder;
    }
}