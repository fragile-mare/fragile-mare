using _Project.Code.Gameplay.Features.Movement.Dash;
using _Project.Code.Gameplay.Features.Movement.Dash.Systems;
using _Project.Code.Gameplay.Features.Movement.Move;
using _Project.Code.Gameplay.Features.Movement.Sprint;
using _Project.Code.Gameplay.Features.Movement.Systems;
using _Project.Code.Infrastructure.Systems;
using Entitas;

namespace _Project.Code.Gameplay.Features.Movement
{
    public class MovementFeature : Feature
    {
        public MovementFeature(ISystemsFactory systems)
        {
            // не менять местами move, sprint и dash, т.к. sprint перекрывает move с помощью установки Moving = false,
            // а dash перекрывает всё
            Add(systems.Create<DashFeature>());
            
            Add(systems.Create<DirectionDeltaSprintSystem>());
            
            Add(systems.Create<DirectionDeltaMoveSystem>());
            
            Add(systems.Create<UpdateTransformPositionSystem>());
        }
    }
}