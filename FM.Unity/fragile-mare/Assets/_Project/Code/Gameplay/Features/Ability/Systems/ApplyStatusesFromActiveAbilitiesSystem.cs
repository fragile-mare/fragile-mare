using _Project.Code.Gameplay.Features.Status.Configs;
using _Project.Code.Gameplay.Features.Status.Factories;
using Entitas;

namespace _Project.Code.Gameplay.Features.Ability.Systems
{
    public class ApplyStatusesFromActiveAbilitiesSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IStatusFactory _statusFactory;

        public ApplyStatusesFromActiveAbilitiesSystem(GameContext game, IStatusFactory statusFactory)
        {
            _statusFactory = statusFactory;
            _abilities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Ability,
                    GameMatcher.Applied,
                    GameMatcher.HolderId,
                    GameMatcher.TargetBuffer,
                    GameMatcher.StatusList));
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities)
            foreach (int targetId in ability.TargetBuffer)
            foreach (StatusConfig statusConfig in ability.StatusList)
            {
                _statusFactory.CreateStatus(statusConfig.status.Current, targetId, ability.HolderId);
            }
        }
    }
}