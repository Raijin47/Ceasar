using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private KeyCode RunningKeyCode;

        private Animator anim;
        private CharacterController characterController;
        private Vector3 moveDirection = Vector3.zero;

        private float acceleration;
        private float speed;
        private float controllability;
        private float currentSpeed;

        private bool isAcceleration = false;
        private bool canMove = true;

        private static readonly int DeathA = Animator.StringToHash("isDeath");
        private static readonly int isFireA = Animator.StringToHash("isFire");

        private void Start()
        {
            anim = GetComponent<Animator>();
            characterController = GetComponent<CharacterController>();
            speed = Equipment.speed;
            controllability = Equipment.controllability;
            acceleration = Equipment.acceleration;
            currentSpeed = speed;
            anim.Rebind();
        }

        private void Update()
        {
            isAcceleration = Input.GetKey(RunningKeyCode);
            if (canMove)
            {
                Movement();
                anim.SetFloat("DirectionY", Input.GetAxis("Vertical"));
            }
        }

        private void Movement()
        {
            if (isAcceleration && currentSpeed < acceleration)
            {
                currentSpeed += 2 * Time.deltaTime;
                controllability -= 0.1f * Time.deltaTime;
            }

            else if (!isAcceleration && currentSpeed > speed)
            {
                currentSpeed -= 2 * Time.deltaTime;
                controllability += 0.1f * Time.deltaTime;
            }

            moveDirection = new Vector3(1, 0f, Input.GetAxis("Vertical") * controllability);
            moveDirection *= currentSpeed;

            characterController.Move(moveDirection * Time.deltaTime);
        }

        public void StopMovement()
        {
            canMove = false;
        }
    }
}