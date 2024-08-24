using src.pubsub;
using src.Utils.Singleton;
using src.Utils.WDebug;

namespace src.Utils.UnityTopic
{
    // todo: prefix (for consumers) and suffix (for producers)
    public class UnityDynamicTopic<T> : Singleton<UnityDynamicTopic<T>>
    {
        public virtual string Suffix => "todo";

        /// <summary>
        /// Не использовать в Awake и OnEnable
        /// </summary>
        /// <param name="entityPrefix"></param>
        /// <returns></returns>
        public static Topic<T> CreateTopic(string entityPrefix)
        {
            if (Instance == null)
            {
                Debug.LogError($"instance is null. prefix: {entityPrefix}");
            }
            var topic = PubSub.CreateTopic<T>(entityPrefix + Instance.Suffix);
            if (topic == null)
            {
                Debug.LogError($"need to create dynamic topic on scene with suffix {Instance.Suffix}");
            }

            return topic;
        }

        /// <summary>
        /// Не использовать в Awake и OnEnable
        /// </summary>
        /// <param name="entityPrefix"></param>
        /// <returns></returns>
        public static Topic<T> GetTopic(string entityPrefix)
        {
            if (Instance == null)
            {
                Debug.LogError($"instance is null. prefix: {entityPrefix}");
            }
            var topic = PubSub.GetTopic<T>(entityPrefix + Instance.Suffix);
            if (topic == null)
            {
                Debug.LogError($"need to create dynamic topic on scene with suffix {Instance.Suffix}");
            }

            return topic;
        }
    }
}