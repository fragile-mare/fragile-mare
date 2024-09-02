using System;

namespace _Project.Code.Unused.PubSubUnused
{
    [Obsolete("Unused.")]
    public class TypedPubSub<T>
    {
        public static Topic<T> CreateTopic(string name)
        {
            return PubSub.CreateTopic<T>(name);
        }

        public static void AddTopic(Topic<T> topic, string name)
        {
            PubSub.AddTopic(topic, name);
        }

        public static Topic<T> GetTopic(string name)
        {
            return PubSub.GetTopic<T>(name);
        }
    }
}