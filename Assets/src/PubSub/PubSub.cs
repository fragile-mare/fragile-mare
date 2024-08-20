using System.Collections.Generic;
using System.ComponentModel.Design;
using src.Utils.Debug;

namespace src.pubsub
{
    public class PubSub
    {
        private static readonly ServiceContainer TopicsLists = new();

        public static Topic<T> CreateTopic<T>(string name)
        {
            var topic = new Topic<T>(name);

            AddTopic(topic, name);

            return topic;
        }

        public static void AddTopic<T>(Topic<T> topic, string name)
        {
            topic.Name = name;
            
            var gotList = (List<Topic<T>>)TopicsLists.GetService(typeof(T));
            if (gotList != null)
            {
                // TODO: check if list already have topic with this name.
                gotList.Add(topic);
            }

            TopicsLists.AddService(typeof(List<Topic<T>>), new List<Topic<T>> { topic });
            
            Debug.Log($"Topic is created. topic: \"{topic.Name}\".");
        }

        public static Topic<T> GetTopic<T>(string name)
        {
            var gotList = (List<Topic<T>>)TopicsLists.GetService(typeof(List<Topic<T>>));
            if (gotList == null)
            {
                Debug.LogWarning($"gotList in GetTopic is null. request_name: \"{name}\"");
                // TODO: error
                return null;
            }
                

            var topic = gotList.Find(x => x.Name == name);
            
            Debug.Log($"Topic was gotten. topic: \"{topic.Name}\" request_name: \"{name}\"");

            return topic;
        }
    }
}
