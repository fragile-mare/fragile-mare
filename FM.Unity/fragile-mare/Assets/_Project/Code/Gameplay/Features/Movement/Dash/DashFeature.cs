using _Project.Code.Gameplay.Features.Movement.Dash.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Features.Movement.Dash
{
    public class DashFeature : Feature
    {
        public DashFeature(ISystemsFactory systems)
        {
            Add(systems.Create<DashRegenerationTimerSystem>());
            Add(systems.Create<DashRegenerationApplySystem>());

            Add(systems.Create<DashTimerSystem>());
            Add(systems.Create<DashActivationSystem>());

            Add(systems.Create<DirectionDeltaDashSystem>());
        }
    }
}