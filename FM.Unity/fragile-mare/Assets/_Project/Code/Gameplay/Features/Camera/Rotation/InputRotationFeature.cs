using _Project.Code.Gameplay.Features.Camera.Rotation.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Features.Camera.Rotation
{
    public class InputRotationFeature : Feature
    {
        public InputRotationFeature(ISystemsFactory systems)
        {
            Add(systems.Create<InitializeCameraOffsetSystem>());
            Add(systems.Create<InitializeCameraPositionSystem>());
            
            Add(systems.Create<InputXRotationSystem>());
            Add(systems.Create<InputYRotationSystem>());
            
            Add(systems.Create<InputCameraRotateSystem>());
        }
    }
}