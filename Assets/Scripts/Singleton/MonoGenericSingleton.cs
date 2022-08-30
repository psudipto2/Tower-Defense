using UnityEngine;

namespace Singleton
{
    public class MonoGenericSingleton<T> : MonoBehaviour where T : MonoGenericSingleton<T>
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                return instance;
            }
        }
        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = (T)this;
                DontDestroyOnLoad(this);
            }
            else if (instance != this)
            {
                Destroy(instance.gameObject);
                instance = (T)this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}