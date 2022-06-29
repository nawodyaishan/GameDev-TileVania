using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class LevelExit : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D col)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }
    }
}