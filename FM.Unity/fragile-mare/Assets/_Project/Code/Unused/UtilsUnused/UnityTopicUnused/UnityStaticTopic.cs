using System;
using _Project.Code.Unused.PubSubUnused;
using _Project.Code.Unused.UtilsUnused.SingletonUnused;

namespace _Project.Code.Unused.UtilsUnused.UnityTopicUnused
{
    /// <summary>
    /// Статический топик. Можно вызывать так: КлассТопика.Subscribe или .Publish из любого места в коде.
    /// !!!WARNING: Обязательно переопределять TopicName.
    /// !!!WARNING: Обязательно отписываться от топика при Destroy объекта (см. класс <see cref="Subscription"/>).
    /// 
    /// См. подробнее в классе <see cref="Topic{T}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Obsolete("Unused.")]
    public class UnityStaticTopic<T> : Singleton<UnityStaticTopic<T>>
    {
        protected virtual string TopicName => "todo";

        private static Topic<T> _topic;

        public override void Awake()
        {
            base.Awake();
            
            // TODO: нагружает ли создание топика инициализацию сцены?
            TopicState state;
            (_topic, state) = Topic();
            
            if (state is TopicState.CreatedNotAdded or TopicState.GottenNotAdded)
            {
                PubSub.AddTopic(_topic, TopicName);
            }
        }

        private static (Topic<T>, TopicState) Topic()
        {
            if (!IsInstanceSet)
            {
                if (_topic != null) return (_topic, TopicState.GottenNotAdded);
                
                _topic = new Topic<T>("without name");
                return (_topic, TopicState.CreatedNotAdded);
            }
            
            _topic ??= PubSub.GetTopic<T>(Instance.TopicName);
            var state = TopicState.Gotten;
            
            if (_topic != null) return (_topic, state);
            
            _topic ??= PubSub.CreateTopic<T>(Instance.TopicName);
            state = TopicState.Created;

            return (_topic, state);
        }

        public static void Publish(T @params)
        {
            var (topic, _) = Topic();
            topic.Publish(@params);
        }

        public static void Subscribe(Action<T> func, out Subscription subscription)
        {
            var (topic, _) = Topic();
            topic.Subscribe(func, out subscription);
        }

        private enum TopicState
        {
            Created,
            CreatedNotAdded,
            Gotten,
            GottenNotAdded,
        }
    }
}
