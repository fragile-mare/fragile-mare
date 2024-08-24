using src.Utils.UnityTopic;

namespace src.Topics.General
{
    public class MovementActionsTopic : UnityDynamicTopic<MovementAction>
    {
        public override string Suffix => ".movement.actions";
    }

    /// <summary>
    /// При добавлении значений сюда, нужно их замаппить с InputAction
    /// в <see cref="Scripts.Input.InputActionsMux"/>.
    /// </summary>
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
    }
}