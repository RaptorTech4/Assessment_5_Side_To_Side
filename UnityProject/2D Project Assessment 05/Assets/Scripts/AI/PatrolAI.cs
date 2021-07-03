using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{

    [SerializeField]float _Speed;
    bool _MoveRight = true;

    public Transform _GroundDetection;
    private float _Health;

    private void Update()
    {
        transform.Translate(Vector2.right * _Speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(_GroundDetection.position,Vector2.down,2f);
        if(groundInfo.collider==false)
        {
            if(_MoveRight==true)
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

    public void RemoveHealth(float healthSubtract)
    {
        _Health = _Health - healthSubtract;

        if(_Health <= 0f)
        {
            Destroy(gameObject);
        }
    }
    
}
