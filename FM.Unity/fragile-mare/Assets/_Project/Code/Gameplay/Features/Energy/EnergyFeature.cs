using _Project.Code.Gameplay.Features.Energy.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Features.Energy
{
    public class EnergyFeature : Feature
    {
        public EnergyFeature(ISystemsFactory systems)
        {
            Add(systems.Create<EnergyRegenerationSystem>());
            Add(systems.Create<EnergyApplyingSystem>());
        }
        
    }
}