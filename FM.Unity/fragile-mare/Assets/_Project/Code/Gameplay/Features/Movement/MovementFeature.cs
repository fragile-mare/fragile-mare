using _Project.Code.Gameplay.Features.Movement.Systems;
using _Project.Code.Infrastructure.Systems;
using Entitas;

namespace _Project.Code.Gameplay.Features.Movement
{
    public class MovementFeature : Feature
    {
        public MovementFeature(ISystemsFactory systems)
        {
            Add(systems.Create<DirectionDeltaMoveSystem>());
            Add(systems.Create<UpdateTransformPositionSystem>());
        }
    }
}