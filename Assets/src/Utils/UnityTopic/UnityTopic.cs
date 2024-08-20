using src.Utils.Singleton;

namespace src.Utils.UnityTopic
{
    public class UnityTopic<T> : Singleton<UnityTopic<T>>
    {
        public override void Awake()
        {
            base.Awake();
        }
    }
}