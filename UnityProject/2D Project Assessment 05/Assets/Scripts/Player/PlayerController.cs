using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private PlayerInputActions _PlayerInput;
    private Rigidbody2D _RB;
    private Collider2D _Col;
    //Movement
    [SerializeField]private float _Speed;
    private bool _FacingRight;
    //jump
    [SerializeField]private float _JumpForce;
    [SerializeField]private LayerMask _GroundLayer;
    //[HideInInspector]
    public int _ExtraJumps;
    public int _ExtraJumpsValue;

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
    }

    private void Update()
    {
        //movement
        float movement = _PlayerInput.Player.Movement.ReadValue<float>();

        Vector3 currentPosition = transform.position;
        currentPosition.x += movement * _Speed * Time.deltaTime;
        transform.position = currentPosition;

        
    }

    void JumpPlayer()
    {
        if(_IsGrounded())
        {
            _ExtraJumps = _ExtraJumpsValue;
        }

        if(_ExtraJumps>0)
        {
            _RB.AddForce(new Vector2(0,_JumpForce),ForceMode2D.Impulse);
            _ExtraJumps--;
        }

    }

    private bool _IsGrounded()
    {
        Vector2 topLeftPoint = transform.position;
        topLeftPoint.x -= _Col.bounds.extents.x;
        topLeftPoint.y += _Col.bounds.extents.y;

        Vector2 bottomRightPoint = transform.position;
        bottomRightPoint.x += _Col.bounds.extents.x;
        bottomRightPoint.y -= _Col.bounds.extents.y;



        return Physics2D.OverlapArea(topLeftPoint,bottomRightPoint,_GroundLayer);
    }

    void Flip()
    {
        _FacingRight = !_FacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
