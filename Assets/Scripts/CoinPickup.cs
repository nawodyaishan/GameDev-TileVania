using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    public class CoinPickup : MonoBehaviour
    {
        [SerializeField] private AudioClip clip;
        [SerializeField] private int coinPickup = 100;

        private bool wasCollected = false;

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player") && !wasCollected)
            {
                wasCollected = true;
                AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
                FindObjectOfType<GameSession>().AddToScore(coinPickup);
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}