using System.Collections.Generic;
using System.ComponentModel.Design;
using src.Utils.WDebug;

namespace src.pubsub
{
    public class PubSub
    {
        private static readonly ServiceContainer TopicsLists = new();

        // todo: return interface that only can Publish and Delete from PubSub, SetValidators?
        // todo: валидаторы где?? в сабскрайберах
        public static Topic<T> CreateTopic<T>(string name)
        {
            var topic = FindTopic<T>(name);
            if (topic != null) return topic;
            
            topic = new Topic<T>(name);

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

        // todo: return interface that only can Subscribe
        public static Topic<T> GetTopic<T>(string name)
        {
            return CreateTopic<T>(name);
        }

        private static Topic<T> FindTopic<T>(string name)
        {
            var gotList = (List<Topic<T>>)TopicsLists.GetService(typeof(List<Topic<T>>));
            if (gotList == null)
            {
                return null;
            }
                

            var topic = gotList.Find(x => x.Name == name);
            
            if(topic != null) Debug.Log($"Topic was gotten. topic: \"{topic.Name}\" request_name: \"{name}\"");

            return topic;
        }
    }
}
