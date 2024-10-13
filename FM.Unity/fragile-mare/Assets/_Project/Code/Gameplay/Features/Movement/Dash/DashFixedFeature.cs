using _Project.Code.Gameplay.Features.Movement.Dash.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Features.Movement.Dash
{
    public class DashFixedFeature : Feature
    {
        public DashFixedFeature(ISystemsFactory systems)
        {
            Add(systems.Create<ApplyDashEffectSystem>());
        }
    }
}