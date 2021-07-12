using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealthSystem : MonoBehaviour
{

    public int _HealthAmount;
    public bool _YouAreDead;

    public int _HealthFullAmount;


    private void Start()
    {
        _HealthAmount = _HealthFullAmount;
        _YouAreDead = false;
    }

    public void RemoveHealth(int RemoveAmount)
    {
        _HealthAmount = _HealthAmount - RemoveAmount;

        if(_HealthAmount <= 0)
        {
            PlayerDied();
        }
    }

    public void PlayerDied()
    {
        _YouAreDead = true;
        SceneManager.LoadScene("Death");

    }

    public void AddHealth(int AddAmount)
    {
        _HealthAmount = _HealthAmount + AddAmount;

        if(_HealthAmount > _HealthFullAmount)
        {
            _HealthAmount = _HealthFullAmount;
        }
    }

    public void AddHealthFullAmount(int AddAmount)
    {
        _HealthFullAmount = _HealthFullAmount + AddAmount;

    }
}
