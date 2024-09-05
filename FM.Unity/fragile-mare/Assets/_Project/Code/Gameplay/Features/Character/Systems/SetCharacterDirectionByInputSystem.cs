using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Character.Systems
{
    public class SetCharacterDirectionByInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _characters;
        private readonly IGroup<GameEntity> _inputs;

        public SetCharacterDirectionByInputSystem(GameContext game)
        {
            _characters = game.GetGroup(GameMatcher.Character);
            _inputs = game.GetGroup(GameMatcher.Input);
        }
        
        public void Execute()
        {
            foreach (var input in _inputs)
            foreach (var character in _characters)
            {
                character.isMoving = input.hasInputMovementAxis;

                if (input.hasInputMovementAxis)
                {
                    character.ReplaceDirection(input.InputMovementAxis.normalized);
                }
                else
                {
                    character.ReplaceDirection(Vector2.zero);
                }
            }
        }
    }
}