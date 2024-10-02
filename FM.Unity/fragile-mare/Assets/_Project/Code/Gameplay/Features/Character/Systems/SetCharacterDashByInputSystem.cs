using Entitas;

namespace _Project.Code.Gameplay.Features.Character.Systems
{
    public class SetCharacterDashByInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _characters;
        private readonly IGroup<GameEntity> _dashAbilities;
        private readonly IGroup<GameEntity> _inputs;

        public SetCharacterDashByInputSystem(GameContext game)
        {
            _characters = game.GetGroup(GameMatcher.Character);
            _inputs = game.GetGroup(GameMatcher.Input);
            _dashAbilities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.DashAbility, GameMatcher.HolderId, GameMatcher.Ready));
        }

        public void Execute()
        {
            foreach (var input in _inputs)
            {
                if (!input.isDashButtonPressed)
                {
                    continue;
                }

                foreach (var character in _characters)
                foreach (var dashAbility in _dashAbilities)
                {
                    if (dashAbility.HolderId != character.Id)
                    {
                        continue;
                    }

                    dashAbility.isApplied = true;
                }
            }
        }
    }
}