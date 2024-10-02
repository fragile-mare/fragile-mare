using _Project.Code.Gameplay.Features.Dummy.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Features.Dummy
{
    public sealed class DummyFeature : Feature
    {
        public DummyFeature(ISystemsFactory systems)
        {
            Add(systems.Create<InitializeDummiesSystem>());

            Add(systems.Create<DummyApplyAbilitySystem>());
        }
    }
}