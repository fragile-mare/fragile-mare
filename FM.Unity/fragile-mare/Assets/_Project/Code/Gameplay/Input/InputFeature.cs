using _Project.Code.Gameplay.Input.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Input
{
    public class InputFeature : Feature
    {
        public InputFeature(ISystemsFactory systems)
        {
            Add(systems.Create<InitializeInputSystem>());
            Add(systems.Create<EmitInputSystem>());
            Add(systems.Create<PressSprintButtonSystem>());
            Add(systems.Create<PressDashButtonSystem>());
        }
    }
}