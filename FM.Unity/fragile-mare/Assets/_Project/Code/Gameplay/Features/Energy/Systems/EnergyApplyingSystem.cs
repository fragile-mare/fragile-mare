using Entitas;

namespace _Project.Code.Gameplay.Features.Energy.Systems
{
    public class EnergyApplyingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _energyUsers;

        public EnergyApplyingSystem(GameContext gameContext)
        {
           _energyUsers = gameContext.GetGroup(GameMatcher.AllOf(
               GameMatcher.EnergyToApply,
               GameMatcher.MaxEnergy,
               GameMatcher.CurrentEnergy
               ));
        }

        public void Execute()
        {
            foreach (GameEntity energyUser in _energyUsers)
            {
                energyUser.ReplaceCurrentEnergy(energyUser.CurrentEnergy + energyUser.EnergyToApply);
                if (energyUser.CurrentEnergy > energyUser.MaxEnergy) { energyUser.ReplaceCurrentEnergy(energyUser.MaxEnergy); }
                if (energyUser.CurrentEnergy < 0) { energyUser.ReplaceCurrentEnergy(0); }
                energyUser.ReplaceEnergyToApply(0);
            }
        }
    }
}
