using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int _HealthAmount;
    public bool _YouAreDead;
    public bool _Boss = false;
    RandomSpawn RS;


    private void Start()
    {
        _YouAreDead = false;
        RS = GetComponent<RandomSpawn>();
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
        if(!_Boss)
        {
            RS.SpawnRandomHealth();
        }
        else
        {
            FindObjectOfType<WinTheGame>().YouWin();
        }

        _YouAreDead = true;
    }

}
