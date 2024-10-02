using _Project.Code.Gameplay.Features.Movement.TransformPosition;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Features.Movement
{
    public class MovementFeature : Feature
    {
        public MovementFeature(ISystemsFactory systems)
        {
            Add(systems.Create<UpdateTransformPositionSystem>());
        }
    }
}