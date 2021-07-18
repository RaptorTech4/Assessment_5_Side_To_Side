using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{

    public GameObject _GaineHealth;
    public GameObject _GaineMaxHealth;
    public GameObject _FullHealth;

    public int _RanomMax, _RandomValu;

    public int _GaineHealthMax, _GaineHealthMin;
    public int _GaineMaxHealthMax, _GaineMaxHealthMin;
    public int _FullHealthMax, _FullHealthMin;

    public void SpawnRandomHealth()
    {

        _RandomValu = Random.Range(0, _RanomMax);

        if(_RandomValu < _GaineHealthMax && _RandomValu > _GaineHealthMin)
        {
            Instantiate(_GaineHealth, transform.position, transform.rotation);
        }

        if (_RandomValu < _GaineMaxHealthMax && _RandomValu > _GaineMaxHealthMin)
        {
            Instantiate(_GaineMaxHealth, transform.position, transform.rotation);

        }

        if (_RandomValu < _FullHealthMax && _RandomValu > _FullHealthMin)
        {
            Instantiate(_FullHealth, transform.position, transform.rotation);

        }
    }

}
