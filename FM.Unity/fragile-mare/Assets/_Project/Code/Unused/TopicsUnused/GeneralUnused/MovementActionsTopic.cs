using System;
using _Project.Code.Unused.ScriptsUnused.InputUnused;
using _Project.Code.Unused.UtilsUnused.UnityTopicUnused;

namespace _Project.Code.Unused.TopicsUnused.GeneralUnused
{
    [Obsolete("Unused.")]
    public class MovementActionsTopic : UnityDynamicTopic<MovementAction>
    {
        public override string Suffix => ".movement.actions";
    }

    /// <summary>
    /// При добавлении значений сюда, нужно их замаппить с InputAction
    /// в <see cref="InputActionsMux"/>.
    /// </summary>
    [Obsolete("Unused.")]
    public enum MovementAction
    {
        MoveForward,
        MoveBack,
        MoveRight,
        MoveLeft,
        
        SprintForward,
        SprintBack,
        SprintRight,
        SprintLeft,
        
        Dash,
    }
}