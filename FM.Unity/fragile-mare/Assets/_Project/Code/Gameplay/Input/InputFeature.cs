using _Project.Code.Gameplay.Input.Axis;
using _Project.Code.Gameplay.Input.Button;
using _Project.Code.Gameplay.Input.Common;
using _Project.Code.Gameplay.Input.Common.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Input
{
    public class InputFeature : Feature
    {
        public InputFeature(ISystemsFactory systems)
        {
            Add(systems.Create<InputCommonFeature>());
            Add(systems.Create<InputAxisFeature>());
            Add(systems.Create<InputButtonFeature>());
        }
    }
}