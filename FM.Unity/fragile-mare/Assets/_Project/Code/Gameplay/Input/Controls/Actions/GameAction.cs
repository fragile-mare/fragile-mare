
using System;
using _Project.Code.Common.Extensions;

namespace _Project.Code.Gameplay.Input.Controls.Actions
{
    public enum GameAction
    {
        Sprint, Dash
    }

    public static class GameActionExtensions
    {
        public static GameEntity Assign(this GameAction action, GameEntity entity)
        {
            return Set(action, entity, true);
        }
        
        public static GameEntity UnAssign(this GameAction action, GameEntity entity)
        {
            return Set(action, entity, false);
        }
        
        private static GameEntity Set(GameAction action, GameEntity entity, bool value)
        {
            return action switch
            {
                GameAction.Sprint => entity.With(x => x.isSprintButtonPressed = value),
                GameAction.Dash => entity.With(x => x.isDashButtonPressed = value),
                _ => throw new ArgumentOutOfRangeException(nameof(action), action, null)
            };
        }
    }
}