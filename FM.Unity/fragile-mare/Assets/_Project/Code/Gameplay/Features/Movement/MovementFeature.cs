using _Project.Code.Gameplay.Features.Movement.Dash;
using _Project.Code.Gameplay.Features.Movement.Move.Systems;
using _Project.Code.Gameplay.Features.Movement.Sprint.Systems;
using _Project.Code.Gameplay.Features.Movement.TransformPosition;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Features.Movement
{
    public class MovementFeature : Feature
    {
        public MovementFeature(ISystemsFactory systems)
        {
            Add(systems.Create<ListenWorldPositionForRigidbodySystem>());

            // не менять местами move, sprint и dash, т.к. sprint перекрывает move с помощью установки Moving = false,
            // а dash перекрывает всё
            Add(systems.Create<DirectionCharacterMoveSystem>());

            Add(systems.Create<DashFeature>());

            Add(systems.Create<DirectionDeltaSprintSystem>());

            Add(systems.Create<DirectionDeltaMoveSystem>());

            Add(systems.Create<UpdateTransformPositionSystem>());
        }
    }
}