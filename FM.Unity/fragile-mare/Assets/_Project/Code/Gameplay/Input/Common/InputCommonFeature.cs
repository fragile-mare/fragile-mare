using _Project.Code.Gameplay.Input.Common.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Input.Common
{
    public class InputCommonFeature : Feature
    {
        public InputCommonFeature(ISystemsFactory systems)
        {
            Add(systems.Create<InitializeInputSystem>());
        }
    }
}