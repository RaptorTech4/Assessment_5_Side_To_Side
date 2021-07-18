using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int _HealthAmount;
    public bool _YouAreDead;


    private void Start()
    {
        _YouAreDead = false;
    }

    public void RemoveHealth(int RemoveAmount)
    {
        _HealthAmount = _HealthAmount - RemoveAmount;

        if (_HealthAmount <= 0)
        {
            EnemyDied();
        }
    }

    public void EnemyDied()
    {
        _YouAreDead = true;
    }

}
