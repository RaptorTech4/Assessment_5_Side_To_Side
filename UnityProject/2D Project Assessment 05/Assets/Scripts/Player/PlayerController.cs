using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private PlayerInputActions _PlayerInput;
    private Rigidbody2D _RB;
    private Collider2D _Col;
    Animator anim;
    //Movement
    [SerializeField] private float _Speed;
    private bool _FacingRight;
    //jump
    [SerializeField] private float _JumpForce;
    [SerializeField] private LayerMask _GroundLayer;
    [SerializeField] private GameObject GroundedGameObject;
    [HideInInspector]
    public int _ExtraJumps;
    public int _ExtraJumpsValue;
    //Attack

    //DropDownPlatform
    private GameObject DropDownPatformGO;

    private void Awake()
    {
        _PlayerInput = new PlayerInputActions();
        _RB = GetComponent<Rigidbody2D>();
        _Col = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        _PlayerInput.Enable();
    }

    private void OnDisable()
    {
        _PlayerInput.Disable();
    }

    private void Start()
    {
        _PlayerInput.Player.Jump.performed += _ => JumpPlayer();
        _PlayerInput.Player.Crouch.performed += _ => DropDownPlatform();
        _PlayerInput.Player.Attack.performed += _ => PlayerAttack();

        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //movement
        float movement = _PlayerInput.Player.Movement.ReadValue<float>();
        float movementRR = Mathf.Clamp01(Mathf.Abs(movement));

        if (_FacingRight == false && movement < 0)
        {
            Flip();
        }
        else if (_FacingRight == true && movement > 0)
        {
            Flip();
        }

        Vector3 currentPosition = transform.position;
        currentPosition.x += movement * _Speed * Time.deltaTime;
        transform.position = currentPosition;

        if (_IsGrounded())
        {
            anim.SetFloat("Movement", movementRR);
            _ExtraJumps = _ExtraJumpsValue;
        }
        else
        {
            anim.SetFloat("Movement", 0.0f);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "OneWayPlatform")
        {
            DropDownPatformGO = collision.gameObject;
        }
    }

    private void DropDownPlatform()
    {

        if (DropDownPatformGO != null)
        {
            VerticalPlatform VP = DropDownPatformGO.GetComponent<VerticalPlatform>();
            if (VP != null)
            {
                VP.ChangeLayers();
                DropDownPatformGO = null;
            }
        }
    }

    void JumpPlayer()
    {
        if (_ExtraJumps > 0)
        {
            _ExtraJumps--;
            _RB.AddForce(new Vector2(0, _JumpForce), ForceMode2D.Impulse);
        }

    }

    private bool _IsGrounded()
    {
        Vector2 topLeftPoint = GroundedGameObject.transform.position;
        topLeftPoint.x -= _Col.bounds.extents.x;
        topLeftPoint.y += _Col.bounds.extents.y;

        Vector2 bottomRightPoint = GroundedGameObject.transform.position;
        bottomRightPoint.x += _Col.bounds.extents.x;
        bottomRightPoint.y -= _Col.bounds.extents.y;



        return Physics2D.OverlapArea(topLeftPoint, bottomRightPoint, _GroundLayer);
    }

    void Flip()
    {
        _FacingRight = !_FacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void PlayerAttack()
    {

    }

    public void AddJumpForce(float AddForce)
    {
        _JumpForce = _JumpForce + AddForce;
    }
    public void AddMoveForce(float AddForce)
    {
        _Speed = _Speed + AddForce;
    }
}
