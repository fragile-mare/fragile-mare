using _Project.Code.Gameplay.Input.Scroll.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Input.Scroll
{
    public class InputScrollFeature : Feature
    {
        public InputScrollFeature(ISystemsFactory systems)
        {
            Add(systems.Create<InputScrollPositionSystem>());
        }
    }
}