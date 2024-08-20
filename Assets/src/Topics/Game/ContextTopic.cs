using src.Utils.GameContext;
using src.Utils.UnityTopic;

namespace src.Topics.Game
{
    public class ContextTopic : UnityStaticTopic<ContextParams>
    {
        protected override string TopicName => "game.context.changes";
    }

    public class ContextParams
    {
        public GameContext Context;
    }
}