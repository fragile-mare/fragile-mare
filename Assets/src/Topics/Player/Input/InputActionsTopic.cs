using src.Utils.UnityTopic;

namespace src.Topics.Player.InputActions
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
    }
}
