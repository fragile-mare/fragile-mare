using _Project.Code.Gameplay.Features.Effect;
using _Project.Code.Gameplay.Features.Movement;
using _Project.Code.Gameplay.Features.Status;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay
{
    public sealed class GameFixedFeature : Feature
    {
        public GameFixedFeature(ISystemsFactory systems)
        {
            Add(systems.Create<MovementFixedFeature>());
            Add(systems.Create<EffectFixedFeature>());
            Add(systems.Create<StatusFixedFeature>());
        }
    }
}