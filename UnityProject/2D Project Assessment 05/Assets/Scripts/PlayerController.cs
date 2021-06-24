using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    Rigidbody2D _RB;

    public float _WalkSpeed;
    public float _JumpForce;

    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    private void Start()
    {
        _RB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

    }

    public void Jump()
    {
        CheckIfGrounded();
        if (isGrounded)
        {
            _RB.velocity = new Vector2(_RB.velocity.x, _JumpForce);
        }
    }

    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    public void Move(float x)
    {
        float moveBy = x * _WalkSpeed;
        _RB.velocity = new Vector2(moveBy, _RB.velocity.y);
    }

}
