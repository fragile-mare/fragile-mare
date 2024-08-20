using UnityEngine;

namespace src.Utils.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance;
        public static bool IsInstanceSet;
    
        public virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;
                IsInstanceSet = true;
                return;
            }
            
            Destroy(gameObject);
        }
    }
}
