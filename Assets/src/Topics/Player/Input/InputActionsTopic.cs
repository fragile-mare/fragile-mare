using src.Utils.UnityTopic;

namespace src.Topics.Player.Input
{
    public class InputActionsTopic : UnityStaticTopic<InputActionParams>
    {
        protected override string TopicName => "input.actions";
    }

    public class InputActionParams
    {
        public InputAction InputAction;

        public override string ToString()
        {
            return InputAction.ToString();
        }
    }

    /// <summary>
    /// При добавлении значений сюда, нужно их замаппить с конкретным action
    /// в <see cref="Scripts.Input.InputActionsMux"/>.
    /// </summary>
    public enum InputAction
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
