using Entitas;

namespace _Project.Code.Gameplay.Features.Character.Systems
{
    public class SetCharacterDirectionByInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<GameEntity> _inputs;

        public SetCharacterDirectionByInputSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.Character);
            
            _inputs = game.GetGroup(GameMatcher.Input);
        }
        
        public void Execute()
        {
            foreach (var input in _inputs)
            foreach (var entity in _entities)
            {
                entity.isMoving = input.hasInputMovementAxis;

                if (input.hasInputMovementAxis)
                {
                    entity.ReplaceDirection(input.InputMovementAxis.normalized);
                }
            }
        }
    }
}