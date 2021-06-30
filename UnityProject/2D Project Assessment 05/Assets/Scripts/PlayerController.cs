using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    //requirements
    Rigidbody2D _RB;
    //Bace values
    public float _WalkSpeed;
    public float _JumpForce;
    //jump
    public Transform _IsGroundedChecker;
    public float _CheckGroundRadius;
    public LayerMask _GroundLayer;
    //[HideInInspector]
    public int _ExtraJumps;
    public int _ExtraJumpsValue;

    bool _FacingRight = true;

    private void Start()
    {
        _RB = GetComponent<Rigidbody2D>();
        _ExtraJumps = _ExtraJumpsValue;
    }
    private void FixedUpdate()
    {
        CheckIfGrounded();
    }
    public void Jump()
    {
        _RB.velocity = new Vector2(_RB.velocity.x, _JumpForce);
        _ExtraJumps--;
    }

    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(_IsGroundedChecker.position, _CheckGroundRadius, _GroundLayer);
        if (collider != null)
        {
            _ExtraJumps = _ExtraJumpsValue;
        }
        
    }

    public void Move(float x)
    {
        float moveBy = x * _WalkSpeed;
        _RB.velocity = new Vector2(moveBy, _RB.velocity.y);
        if (_FacingRight == false && x > 0)
        {
            Flip();
        }
        else if (_FacingRight == true && x < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        _FacingRight = !_FacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

}
