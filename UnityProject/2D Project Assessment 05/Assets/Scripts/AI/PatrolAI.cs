using UnityEngine;

public class PatrolAI : MonoBehaviour
{

    [SerializeField] float _Speed;
    bool _MoveRight = true;

    public Transform _GroundDetection;
    public LayerMask _GroundLayer;

    Animator anim;
    EnemyHealth Health;
    bool died;

    private void Start()
    {
        anim = GetComponent<Animator>();
        Health = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        died = Health._YouAreDead;
        if (!died)
        {
            transform.Translate(Vector2.right * _Speed * Time.deltaTime);

            RaycastHit2D groundInfo = Physics2D.Raycast(_GroundDetection.position, Vector2.down, 2f, _GroundLayer);
            if (groundInfo.collider == false)
            {
                if (_MoveRight == true)
                {
                    transform.eulerAngles = new Vector3(0f, -180f, 0f);
                    _MoveRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
                    _MoveRight = true;
                }
            }
        }
        else
        {
            anim.SetTrigger("Die");
            Destroy(gameObject, 0.4f);
        }
    }
}
