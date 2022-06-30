using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    public class CoinPickup : MonoBehaviour
    {
        void Start()
        {
        }

        void Update()
        {
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Player"))
                Destroy(gameObject);
        }
    }
}