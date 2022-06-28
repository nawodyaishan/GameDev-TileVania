using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        Vector2 moveInput;

        private Rigidbody2D myRigidBody;
        [SerializeField] float runSpeed = 10f;


        void Start()
        {
            myRigidBody = GetComponent<Rigidbody2D>();
        }


        void Update()
        {
            Run();
        }

        // On Move Input
        void OnMove(InputValue value)
        {
            moveInput = value.Get<Vector2>();
            Debug.Log(moveInput);
        }

        void Run()
        {
            Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidBody.velocity.y);
            myRigidBody.velocity = playerVelocity;
        }
    }
}