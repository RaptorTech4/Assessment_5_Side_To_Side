using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [Header("Movement")]
    public float _Speed = 3.2f;
    public Transform _GroundDetection;
    public LayerMask GroundLayer;
    bool _MovingRight = true;
    bool _Moving = true;
    public float _RayDis = 2.5f;
    float _XScale;

    [Space]
    [Header("Timers")]
    public float _DirectionTimerMin = 0.5f;
    public float _DirectionTimerMax = 3.5f;
    float _DirectionCurrentTimer;

    public float _StandTimerMin = 0.5f;
    public float _StandTimerMax = 2.5f;
    float _StandCurrentTimer;
    bool _MackTimer;

    public float _AttackTimerMin = 0.5f;
    public float _AttackTimerMax = 1.2f;
    float _AttackCurrentTimer;

    [Space]
    [Header("Player Checks")]
    public Transform _PlayerCheckPos;
    public float _PlayerRayDis = 2.5f;
    public LayerMask _PlayerLayer;
    bool _FoundPlayer;

    [Space]
    [Header("Attack")]
    public Transform _AttackPos;
    public float _AttackRange = 1.5f;
    public int _AttackDamigeAmount;
    [HideInInspector] public bool _CanAttack = true;

    Rigidbody2D rb;
    Animator anim;
    EnemyHealth Health;
    bool died;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Health = GetComponent<EnemyHealth>();
        _XScale = transform.localScale.x;
        _AttackCurrentTimer -= Random.Range(_AttackTimerMin, _AttackTimerMax);
    }

    private void Update()
    {
        died = Health._YouAreDead;
        if (!died)
        {

            Movement();

            PlayerCheck();

            if (_FoundPlayer)
            {
                Attack();
            }
            else
            {

                RaycastHit2D groundInfo = Physics2D.Raycast(_GroundDetection.position, Vector2.down, _RayDis, GroundLayer);

                if (groundInfo.collider == false)
                {
                    _MovingRight = !_MovingRight;
                }
                SetUpTimers();
                Flip();
            }
        }
        else
        {
            anim.SetTrigger("Die");
            Destroy(gameObject, 0.4f);
        }
    }

    void SetUpTimers()
    {
        if (_MackTimer)
        {
            _DirectionCurrentTimer = Random.Range(_DirectionTimerMin, _DirectionTimerMax);
            _StandCurrentTimer = Random.Range(_StandTimerMin, _StandTimerMax);
            _MackTimer = false;
            _MovingRight = (Random.value >= 0.5f);
        }

        if (_Moving)
        {
            if (_DirectionCurrentTimer > 0.0f)
            {
                _DirectionCurrentTimer -= Time.deltaTime;
            }
            else
            {
                _Moving = false;
            }
        }
        if (!_Moving)
        {
            if (_StandCurrentTimer > 0.0f)
            {
                _StandCurrentTimer -= Time.deltaTime;
            }
            else
            {
                _Moving = true;
                _MackTimer = true;
            }
        }
    }

    void Movement()
    {
        float horizontal = (!_Moving) ? 0.0f : (_MovingRight) ? 1.0f : -1.0f;

        float movement = Mathf.Clamp01(Mathf.Abs(horizontal));
        Vector2 dir = new Vector2(horizontal * _Speed, rb.velocity.y);
        rb.velocity = dir;

        anim.SetFloat("Movement", movement);
    }

    void Flip()
    {
        Vector3 scaler = transform.localScale;

        if (_MovingRight)
        {
            scaler.x = _XScale;
            transform.localScale = scaler;
        }
        else
        {
            scaler.x = -_XScale;
            transform.localScale = scaler;
        }
    }

    void PlayerCheck()
    {
        bool isRight;
        bool isLeft;
        if (_MovingRight)
        {
            RaycastHit2D PlayerRightCheck = Physics2D.Raycast(_PlayerCheckPos.position, Vector2.right, _PlayerRayDis, _PlayerLayer);
            if (PlayerRightCheck.collider == true)
            {
                if (!_Moving)
                {
                    _MovingRight = true;
                }
                _Moving = false;
                isRight = true;
            }
            else
            {
                isRight = false;
            }

            if (isRight)
                _FoundPlayer = true;
            if (!isRight)
                _FoundPlayer = false;
        }
        else
        {
            RaycastHit2D PlayerLeftCheck = Physics2D.Raycast(_PlayerCheckPos.position, Vector2.left, _PlayerRayDis, _PlayerLayer);
            if (PlayerLeftCheck.collider == true)
            {
                if (!_Moving)
                {
                    _MovingRight = false;
                }
                _Moving = false;
                isLeft = true;
            }
            else
            {
                isLeft = false;
            }

            if (isLeft)
                _FoundPlayer = true;
            if (!isLeft)
                _FoundPlayer = false;

        }
    }

    void Attack()
    {
        if (_AttackCurrentTimer > 0.0f)
        {
            _AttackCurrentTimer -= Time.deltaTime;
        }
        else
        {
            if (_CanAttack)
            {
                _CanAttack = false;

                anim.SetTrigger("Attack1");

                Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(_AttackPos.position, _AttackRange, _PlayerLayer);

                foreach (Collider2D enemy in hitPlayer)
                {
                    enemy.GetComponent<PlayerHealthSystem>().RemoveHealth(_AttackDamigeAmount);
                }
                _AttackCurrentTimer -= Random.Range(_AttackTimerMin, _AttackTimerMax);
            }
        }
    }
}
