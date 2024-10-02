using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Character.Systems
{
    public class SetCharacterInputAccelerationStatusTargetVelocity : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _character;
        private readonly IGroup<GameEntity> _inputs;
        private readonly IGroup<GameEntity> _statuses;

        public SetCharacterInputAccelerationStatusTargetVelocity(GameContext game)
        {
            _statuses = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.InputAccelerationStatus));
            _inputs = game.GetGroup(GameMatcher.Input);
            _character = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Character, GameMatcher.Speed));
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            foreach (GameEntity status in _statuses)
            foreach (GameEntity character in _character)
            {
                if (status.TargetId != character.Id)
                {
                    continue;
                }

                Vector3 velocity = input.hasInputMovementAxis
                    ? new Vector3(input.InputMovementAxis.x, 0, input.InputMovementAxis.y).normalized * character.Speed
                    : Vector3.zero;

                status.ReplaceTargetVelocity(velocity);
            }
        }
    }
}