using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyMovement : MonoBehaviour
    {
        private Rigidbody2D enemyRigidbody2D;

        [SerializeField] private float moveSpeed = 2f;


        void Start()
        {
            enemyRigidbody2D = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            enemyRigidbody2D.velocity = new Vector2(moveSpeed, 0f);
        }

        void OnTriggerExit2D(Collider2D col)
        {
            moveSpeed = -moveSpeed;
            FlipEnemyFacing();
        }

        private void FlipEnemyFacing()
        {
            transform.localScale = new Vector2(-(Mathf.Sign(enemyRigidbody2D.velocity.x)), 1f);
        }
    }
}