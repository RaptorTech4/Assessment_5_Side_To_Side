using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRot : MonoBehaviour
{

    public bool XRot = false, YRot = false, ZRot=true;

    float RandomRotationSet;

    private void Start()
    {

        RandomRotationSet = Random.Range(0.0f, 360.0f);
        
        if(XRot)
        {
            RotOnX();
        }
        if (YRot)
        {
            RotOnY();
        }
        if (ZRot)
        {
            RotOnZ();
        }

    }

    void RotOnX()
    {
        Quaternion target = Quaternion.Euler(RandomRotationSet, 0.0f, 0.0f);
        gameObject.transform.rotation = target;
    }

    void RotOnY()
    {
        Quaternion target = Quaternion.Euler(0.0f, RandomRotationSet, 0.0f);
        gameObject.transform.rotation = target;
    }

    void RotOnZ()
    {
        Quaternion target = Quaternion.Euler(0.0f, 0.0f, RandomRotationSet);
        gameObject.transform.rotation = target;
    }
}
