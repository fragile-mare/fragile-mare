using System;

namespace _Project.Code.Unused.PubSubUnused
{
    // todo
    [Obsolete("Unused.")]
    public interface ITopicPublisher<in T>
    {
        public void Publish(T parameters);
    }
}