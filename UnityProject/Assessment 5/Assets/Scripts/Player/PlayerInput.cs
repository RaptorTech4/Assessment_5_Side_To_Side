using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{
    [HideInInspector]
    public PlayerController _PC;


    private void Start()
    {

        _PC = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        float MI = Input.GetAxis("Movement");
        Move(MI);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Jump()
    {
        if (_PC._ExtraJumps > 0)
        {
            _PC.Jump();
            Debug.Log("Jump");
        }
    }

    void Move(float _Movement)
    {
        _PC.Move(_Movement);
    }
}
