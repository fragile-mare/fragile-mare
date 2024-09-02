using System;

namespace _Project.Code.Unused.PubSubUnused
{
    // todo
    [Obsolete("Unused.")]
    public interface ITopicSubscriber<out T>
    {
        public void Subscribe(Action<T> func, out Subscription subscription);
    }
}