using Entitas;
using _Project.Code.Common.Services.Time;

namespace _Project.Code.Gameplay.Features.Energy.Systems
{
    public class EnergyRegenerationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _energyUsers;
        private readonly ITimeService _time;
        public EnergyRegenerationSystem(GameContext gameContext, ITimeService time)
        {
            _time = time;
            _energyUsers = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.EnergyToApply,
                GameMatcher.EnergyToRegen
                //GameMatcher.EnergyRegenTimer
                ));
        }
        
        public void Execute()
        {
            foreach (GameEntity energyUser in _energyUsers)
            {
                    energyUser.ReplaceEnergyToApply(energyUser.EnergyToApply + energyUser.EnergyToRegen * _time.DeltaTime);
            }
        }
    }
}