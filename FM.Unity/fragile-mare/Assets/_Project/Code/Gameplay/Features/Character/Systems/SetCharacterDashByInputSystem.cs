using Entitas;

namespace _Project.Code.Gameplay.Features.Character.Systems
{
    public class SetCharacterDashByInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _characters;
        private readonly IGroup<GameEntity> _inputs;

        public SetCharacterDashByInputSystem(GameContext game)
        {
            _characters = game.GetGroup(GameMatcher.Character);
            _inputs = game.GetGroup(GameMatcher.Input);
        }
        
        public void Execute()
        {
            foreach (var input in _inputs)
            foreach (var character in _characters)
            {
                character.isDashActivated = input.isDashButtonPressed;
            }
        }
    }
}