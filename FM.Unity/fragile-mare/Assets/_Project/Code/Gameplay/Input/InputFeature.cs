using _Project.Code.Gameplay.Input.Axis;
using _Project.Code.Gameplay.Input.Common;
using _Project.Code.Gameplay.Input.Controls;
using _Project.Code.Gameplay.Input.Cursor;
using _Project.Code.Gameplay.Input.Scroll;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Input
{
    public class InputFeature : Feature
    {
        public InputFeature(ISystemsFactory systems)
        {
            Add(systems.Create<InputScrollFeature>());
            Add(systems.Create<InputCursorFeature>());

            Add(systems.Create<InputAxisFeature>());
            Add(systems.Create<InputCommonFeature>());
            Add(systems.Create<ControlsFeature>());
        }
    }
}
