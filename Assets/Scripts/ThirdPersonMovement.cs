using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public LayerMask groundLayer;

    public GameObject groundCheck;

    Rigidbody rb;

    Vector2 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector3(direction.x * speed, rb.velocity.y, direction.y * speed);
    }

    public void OnMoveCharacter(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    public void OnJumpCharacter(InputAction.CallbackContext context)
    {
        Debug.Log(IsGrounded());
        if (IsGrounded() && context.performed)
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    bool IsGrounded()
    {
        Collider[] isGrounded = Physics.OverlapBox(groundCheck.transform.position, new Vector3(0.1f, 0.1f, 0.1f), Quaternion.identity, groundLayer);
        return isGrounded.Length > 0;
    }
}
