using UnityEngine;

namespace Assets.Scripts
{
    public class ScenePesist : MonoBehaviour
    {
        void Awake()
        {
            int numGameSessions = FindObjectsOfType<ScenePesist>().Length;

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