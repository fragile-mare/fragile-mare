using _Project.Code.Gameplay.Input.Axis.Systems;
using _Project.Code.Gameplay.Input.Axis.Systems.CameraRotationSystem;
using _Project.Code.Gameplay.Input.Common.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Input.Axis
{
    public class InputAxisFeature : Feature
    {
        public InputAxisFeature(ISystemsFactory systems)
        {
            Add(systems.Create<InitializeCameraOffsetSystem>());
            Add(systems.Create<InitializeCameraPositionSystem>());
            
            Add(systems.Create<EmitInputSystem>());

            Add(systems.Create<InputScrollPositionSystem>());
            Add(systems.Create<InputZoomPositionSystem>());
            Add(systems.Create<InputMouseCursorPositionSystem>());
            Add(systems.Create<InputXRotationSystem>());
            Add(systems.Create<InputYRotationSystem>());
            Add(systems.Create<InputCameraRotateSystem>());
        }
    }
}