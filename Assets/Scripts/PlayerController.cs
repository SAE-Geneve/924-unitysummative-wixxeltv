using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.81f;
    public float acceleration = 10f;
    public float deceleration = 10f;

    private CharacterController characterController;
    private Vector2 moveInput;
    private Vector3 velocity;
    private Vector3 currentSpeed;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void Update()
    {
        Vector3 targetSpeed = (transform.right * moveInput.x + transform.forward * moveInput.y) * speed;
        currentSpeed = Vector3.MoveTowards(currentSpeed, targetSpeed, (moveInput.magnitude > 0 ? acceleration : deceleration) * Time.deltaTime);
        characterController.Move(currentSpeed * Time.deltaTime);
        if (!characterController.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = -2f;
        }
        characterController.Move(velocity * Time.deltaTime);
    }
}
