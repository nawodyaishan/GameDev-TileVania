using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D myRigidbody;
        private CapsuleCollider2D bulletCollider;
        [SerializeField] private float bulletSpeed;


        private PlayerMovement player;
        private float xSpeed;


        void Start()
        {
            myRigidbody = GetComponent<Rigidbody2D>();
            bulletCollider = GetComponent<CapsuleCollider2D>();
            player = FindObjectOfType<PlayerMovement>();

            xSpeed = player.transform.localScale.x * bulletSpeed;
        }

        void Update()
        {
            myRigidbody.velocity = new Vector2(xSpeed, 0f);
        }
    }
}