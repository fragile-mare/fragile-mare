using _Project.Code.Gameplay.Features.Movement;
using _Project.Code.Gameplay.Features.Physics;
using _Project.Code.Gameplay.Features.Status;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay
{
    public sealed class GameFixedFeature : Feature
    {
        public GameFixedFeature(ISystemsFactory systems)
        {
            Add(systems.Create<MovementFixedFeature>());
            Add(systems.Create<PhysicsFixedFeature>());
            Add(systems.Create<StatusFixedFeature>());
        }
    }
}