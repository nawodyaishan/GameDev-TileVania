using UnityEngine;

namespace Assets.Scripts
{
    public class ScenePersist : MonoBehaviour
    {
        void Awake()
        {
            int numGameSessions = FindObjectsOfType<ScenePersist>().Length;

            if (numGameSessions > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        public void ResetScreenPersist()
        {
            Destroy(gameObject);
        }
    }
}