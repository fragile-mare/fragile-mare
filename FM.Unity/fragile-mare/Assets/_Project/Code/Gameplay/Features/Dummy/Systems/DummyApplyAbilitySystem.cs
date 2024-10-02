using Entitas;

namespace _Project.Code.Gameplay.Features.Dummy.Systems
{
    public class DummyApplyAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _dummies;

        public DummyApplyAbilitySystem(GameContext game)
        {
            _dummies = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Dummy, GameMatcher.Id));
            _abilities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.SphereRelativePushAbility, GameMatcher.HolderId, GameMatcher.Ready));
        }

        public void Execute()
        {
            foreach (GameEntity dummy in _dummies)
            foreach (GameEntity ability in _abilities)
            {
                if (ability.HolderId != dummy.Id)
                    continue;

                ability.isApplied = true;
            }
        }
    }
}