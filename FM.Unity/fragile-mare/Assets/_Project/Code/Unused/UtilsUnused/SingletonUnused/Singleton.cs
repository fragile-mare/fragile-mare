using System;
using UnityEngine;

namespace _Project.Code.Unused.UtilsUnused.SingletonUnused
{
    [Obsolete("Unused.")]
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
