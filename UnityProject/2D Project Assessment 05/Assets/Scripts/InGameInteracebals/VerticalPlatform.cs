using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlatformEffector2D))]

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D _Effector;
    [SerializeField] private LayerMask _NewLayerMask, _ResetLayerMask;

    private void Start()
    {
        _Effector = GetComponent<PlatformEffector2D>();
    }

    public void ChangeLayers()
    {
        if(_Effector!=null)
        {
            _Effector.colliderMask = _NewLayerMask;
            Invoke("ResetLayers", 0.5f);
        }
    }

    public void ResetLayers()
    {
        _Effector.colliderMask = _ResetLayerMask;
    }
}
