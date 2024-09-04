using _Project.Code.Gameplay.Features.Movement.Systems;
using _Project.Code.Infrastructure.Systems;
using Entitas;

namespace _Project.Code.Gameplay.Features.Movement
{
    public class MovementFeature : Feature
    {
        public MovementFeature(ISystemsFactory systems)
        {
            // не менять местами, т.к. sprint перекрывает move с помощью установки Moving = false.
            Add(systems.Create<DirectionDeltaSprintSystem>());
            Add(systems.Create<DirectionDeltaMoveSystem>());
            
            Add(systems.Create<UpdateTransformPositionSystem>());
        }
    }
}