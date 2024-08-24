using src.Utils.UnityTopic;

namespace src.Topics.General
{
    public class MovementActionsTopic : UnityDynamicTopic<MovementAction>
    {
        public override string Suffix => ".movement.actions";
    }

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