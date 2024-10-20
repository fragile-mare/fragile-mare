using _Project.Code.Gameplay.Features.Movement.Dash.Systems;
using _Project.Code.Gameplay.Features.Movement.Move.Systems;
using _Project.Code.Gameplay.Features.Movement.Sprint.Systems;
using _Project.Code.Gameplay.Features.Movement.TransformPosition;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Features.Movement
{
    public sealed class MovementFixedFeature : Feature
    {
        public MovementFixedFeature(ISystemsFactory systems)
        {
            Add(systems.Create<ZeroTargetVelocityOnStopMovingReactSystem>());

            Add(systems.Create<UpdateRigidbodyPositionSystem>());

            Add(systems.Create<SetDasherTargetVelocitySystem>()); 
            Add(systems.Create<SetSprintingTargetVelocitySystem>()); // обязательно после dasher
            Add(systems.Create<SetMovingTargetVelocitySystem>()); // Обязательно после sprinting
        }
    }
}