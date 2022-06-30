using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class LevelExit : MonoBehaviour
    {
        [SerializeField] float levelLoadDelay;


        // Coroutine for loading next level delay
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                StartCoroutine(LoadNextLevel());
            }

            StartCoroutine(LoadNextLevel());
        }

        IEnumerator LoadNextLevel()
        {
            yield return new WaitForSecondsRealtime(levelLoadDelay);
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;

            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }

            FindObjectOfType<ScenePesist>().ResetScreenPersist();
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}