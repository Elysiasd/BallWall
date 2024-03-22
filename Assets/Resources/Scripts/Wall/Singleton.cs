using UnityEngine;

namespace Common
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {

        private static T _instance;

        public static T Instance
        {
            get
            {
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            _instance = this as T;
        }
    }
}
