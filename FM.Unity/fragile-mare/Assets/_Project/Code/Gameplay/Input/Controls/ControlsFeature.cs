using _Project.Code.Gameplay.Input.Controls.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Input.Controls
{
    public class ControlsFeature: Feature
    {
        public ControlsFeature(ISystemsFactory systems)
        {
            Add(systems.Create<ApplyControlsActionsSystem>());
        }
    }
}