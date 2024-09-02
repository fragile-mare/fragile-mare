using _Project.Code.Unused.ScriptsUnused.InputUnused;
using _Project.Code.Unused.UtilsUnused.UnityTopicUnused;

namespace _Project.Code.Unused.TopicsUnused.PlayerUnused.Input
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
    /// в <see cref="InputActionsMux"/>.
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
