using _Project.Code.Gameplay.Features.Effect.Configs;

namespace _Project.Code.Gameplay.Features.Effect.Factories
{
    public interface IEffectFactory
    {
        GameEntity CreateEffect(EffectSetup effectSetup, int targetId, int producerId);
    }
}