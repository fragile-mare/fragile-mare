using _Project.Code.Gameplay.Input.Axis.Systems;
using _Project.Code.Gameplay.Input.Axis.Systems.Mouse;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Input.Axis
{
    public class InputAxisFeature : Feature
    {
        public InputAxisFeature(ISystemsFactory systems)
        {
            Add(systems.Create<EmitInputSystem>());
            Add(systems.Create<InputCursorPositionSystem>());
            Add(systems.Create<InputXRotationPositionSystem>());
            Add(systems.Create<InputYRotationPositionSystem>());
            Add(systems.Create<InputCameraRotationSystem>());
        }
    }
}