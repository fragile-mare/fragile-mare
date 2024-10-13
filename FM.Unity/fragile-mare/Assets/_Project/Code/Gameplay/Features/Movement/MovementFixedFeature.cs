using _Project.Code.Gameplay.Features.Movement.Dash;
using _Project.Code.Gameplay.Features.Movement.TransformPosition;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Features.Movement
{
    public class MovementFixedFeature : Feature
    {
        public MovementFixedFeature(ISystemsFactory systems)
        {
            Add(systems.Create<UpdateRigidbodyPositionSystem>());
            Add(systems.Create<DashFixedFeature>());
        }
    }
}