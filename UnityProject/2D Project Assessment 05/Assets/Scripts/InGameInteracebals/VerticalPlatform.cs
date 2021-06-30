using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlatformEffector2D))]

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D _Effector;
    private float _WaitTimeLeft;
    [SerializeField] private float _WaitTimeLenth;

    bool _PlayerOnColider;

    private void Start()
    {
        _Effector = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        if (_PlayerOnColider)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                DropDown();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _PlayerOnColider = true;
        }
    }

    void DropDown()
    {
        if (_WaitTimeLeft <= 0)
        {
            _Effector.rotationalOffset = 180f;
            _WaitTimeLeft = _WaitTimeLenth;
            Invoke("ResetDirection", 0.5f);
        }
        else
        {
            _WaitTimeLeft -= Time.deltaTime;
        }
    }

    void ResetDirection()
    {
        _Effector.rotationalOffset = 0f;
        _PlayerOnColider = false;
    }
}
