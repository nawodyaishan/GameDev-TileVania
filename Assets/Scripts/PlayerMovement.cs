using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        Vector2 moveInput;
        Vector2 jumpInput;

        private float gravityScaleAtStart;

        private Rigidbody2D myRigidBody;
        private Animator myAnimator;
        private CapsuleCollider2D myPlayerCollider;

        [SerializeField] float runSpeed = 10f;
        [SerializeField] float jumpSpeed = 10f;
        [SerializeField] private float climbSpeed = 10f;


        void Start()
        {
            myRigidBody = GetComponent<Rigidbody2D>();
            myAnimator = GetComponent<Animator>();
            myPlayerCollider = GetComponent<CapsuleCollider2D>();
            gravityScaleAtStart = myRigidBody.gravityScale;
        }


        void Update()
        {
            Run();
            FlipSprite();
            ClimbLadder();
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

        // Adding Velocity
        void OnJump(InputValue value)
        {
            // TODO - Implement Jump return using LayerMask.GetMask
            if (!myPlayerCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
                return;

            if (value.isPressed)
            {
                myRigidBody.velocity += new Vector2(0f, jumpSpeed);
            }
        }


        // Assigning Velocity
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


        void ClimbLadder()
        {
            if (!myPlayerCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
            {
                myRigidBody.gravityScale = gravityScaleAtStart;
                myAnimator.SetBool("IsClimbing", false);
                return;
            }

            Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, moveInput.y * climbSpeed);
            myRigidBody.velocity = climbVelocity;
            myRigidBody.gravityScale = 0f;

            bool isPlayerMovementVertical = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon; // Epsilon is way of 0 
            myAnimator.SetBool("IsClimbing", isPlayerMovementVertical);
        }
    }
}