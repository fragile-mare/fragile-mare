using src.Utils.UnityTopic;

namespace src.Topics.Player.InputActions
{
    public class PlayerActions : UnityStaticTopic<PlayerActionsParams>
    {
        protected override string TopicName => "player.actions";
    }

    public class PlayerActionsParams
    {
        public PlayerAction PlayerAction;

        public override string ToString()
        {
            return PlayerAction.ToString();
        }
    }

    public enum PlayerAction
    {
        MoveForward,
        MoveBack,
        MoveRight,
        MoveLeft,
    }
}
