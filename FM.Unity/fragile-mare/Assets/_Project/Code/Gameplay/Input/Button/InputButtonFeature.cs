using _Project.Code.Gameplay.Input.Button.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Input.Button
{
    public class InputButtonFeature : Feature
    {
        public InputButtonFeature(ISystemsFactory systems)
        {
            Add(systems.Create<PressSprintButtonSystem>());
            Add(systems.Create<PressDashButtonSystem>());
        }
    }
}