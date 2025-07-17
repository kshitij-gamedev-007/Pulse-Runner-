using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    Vector2 movement;
    Rigidbody rb;
    Vector3 currentPosition;
    Vector3 newPosition;
    [SerializeField] float Xclamp = 3f;
    [SerializeField] float Zclamp = 4f;
    [SerializeField] float moveSpeed = 3f;
    void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }


    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
    void HandleMovement()
    {
        currentPosition = rb.position;
        Vector3 moveDirection = new Vector3(movement.x, 0f, movement.y);
        Vector3 movePosition = currentPosition + moveSpeed * Time.fixedDeltaTime * moveDirection;
        movePosition.x = Mathf.Clamp(movePosition.x, -Xclamp, Xclamp);
        movePosition.z = Mathf.Clamp(movePosition.z, -Zclamp, Zclamp);
        rb.MovePosition(movePosition);
    }
}
