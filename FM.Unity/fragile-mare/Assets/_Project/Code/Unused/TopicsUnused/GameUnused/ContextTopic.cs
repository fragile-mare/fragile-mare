using System;
using _Project.Code.Unused.UtilsUnused.GameContextUnused;
using _Project.Code.Unused.UtilsUnused.UnityTopicUnused;

namespace _Project.Code.Unused.TopicsUnused.GameUnused
{
    [Obsolete("Unused.")]
    public class ContextTopic : UnityStaticTopic<ContextParams>
    {
        protected override string TopicName => "game.context.changes";
    }

    [Obsolete("Unused.")]
    public class ContextParams
    {
        public UtilsUnused.GameContextUnused.GameContext Context;
    }
}