using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        Vector2 moveInput;
        Vector2 jumpInput;

        private Rigidbody2D myRigidBody;
        [SerializeField] float runSpeed = 10f;
        private Animator myAnimator;
        [SerializeField] float jumpSpeed = 10f;


        void Start()
        {
            myRigidBody = GetComponent<Rigidbody2D>();
            myAnimator = GetComponent<Animator>();
        }


        void Update()
        {
            Run();
            FlipSprite();
            Jump();
            JumpAnimation();
        }

        private void JumpAnimation()
        {
            bool isPlayerMovementJump = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon; // Epsilon is way of 0 

            if (isPlayerMovementJump)
            {
                transform.localScale = new Vector2(1f, Mathf.Sign(myRigidBody.velocity.y));
            }
        }

        private void FlipSprite()
        {
            bool isPlayerMovementHorizontal = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon; // Epsilon is way of 0 

            if (isPlayerMovementHorizontal)
            {
                transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
            }
        }

        // On Move Input
        void OnMove(InputValue value)
        {
            moveInput = value.Get<Vector2>();
            Debug.Log(moveInput);
        }

        void OnJump(InputValue value)
        {
            if (value.isPressed)
            {
                myRigidBody.velocity += new Vector2(0f, )
            }
        }

        void Jump()
        {
            Vector2 playerJump = new Vector2(myRigidBody.velocity.x, jumpInput.y * jumpSpeed);
            myRigidBody.velocity = playerJump;

            bool isPlayerJump = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon; // Epsilon is way of 0

            if (isPlayerJump)
            {
                myAnimator.SetBool("IsJump", true);
            }
            else
            {
                myAnimator.SetBool("IsJump", false);
            }
        }

        void Run()
        {
            Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidBody.velocity.y);
            myRigidBody.velocity = playerVelocity;

            bool isRunningStatus = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon; // Epsilon is way of 0 

            if (isRunningStatus)
            {
                myAnimator.SetBool("IsRunning", true);
            }
            else
            {
                myAnimator.SetBool("IsRunning", false);
            }
        }
    }
}