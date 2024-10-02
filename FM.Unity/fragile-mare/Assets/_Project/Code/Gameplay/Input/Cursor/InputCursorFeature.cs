using _Project.Code.Gameplay.Features.Camera.Rotation.Systems;
using _Project.Code.Gameplay.Input.Cursor.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Input.Cursor
{
    public class InputCursorFeature : Feature
    {
        public InputCursorFeature(ISystemsFactory systems)
        {
            Add(systems.Create<InputCameraRotateSystem>());
            Add(systems.Create<InputMouseCursorPositionSystem>());
        }
    }
}