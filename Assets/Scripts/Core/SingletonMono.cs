using UnityEngine;

namespace TTSH.Core
{
    [DisallowMultipleComponent]
    public abstract class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
    {
        [Header("Singleton")]
        [SerializeField] private bool m_DoNotDestroyOnLoad;

        public static T Instance { get; private set; }


        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this as T;

            if (m_DoNotDestroyOnLoad) DontDestroyOnLoad(gameObject);
        }
    }
}
