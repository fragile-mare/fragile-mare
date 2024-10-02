using _Project.Code.Gameplay.Input.Scroll.Services;
using Entitas;

namespace _Project.Code.Gameplay.Input.Scroll.Systems
{
    public class InputScrollPositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _input;
        private readonly IScrollPositionService _scroll;

        public InputScrollPositionSystem(GameContext game, IScrollPositionService scroll)
        {
            _scroll = scroll;
            _input = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input,
                GameMatcher.MouseScrollWheel
            ));
        }

        public void Execute()
        {
            foreach (GameEntity input in _input)
            {
                input.ReplaceMouseScrollWheel(_scroll.GetScrollPosition());
            }
        }
    }
}