using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private int playerLives = 3;

        void Awake()
        {
            int numGameSessions = FindObjectsOfType<GameSession>().Length;

            if (numGameSessions > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        public void ProcessPlayerDeath()
        {
            if (playerLives > 1)
            {
                TakeLife();
            }
            else
            {
                ResetGameSession();
            }
        }

        private void ResetGameSession()
        {
            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }

        private void TakeLife()
        {
            playerLives--;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}