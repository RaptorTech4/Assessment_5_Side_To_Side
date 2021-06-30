using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D _Effector;
    private float _WaitTimeLeft;
    [SerializeField] private float _WaitTimeLenth;

    private void Start()
    {
        _Effector = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("DropFromPlatform"))
        {
            DropDown();
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
    }
}
