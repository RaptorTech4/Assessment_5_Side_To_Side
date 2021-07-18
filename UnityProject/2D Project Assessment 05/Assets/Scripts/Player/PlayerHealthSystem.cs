using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealthSystem : MonoBehaviour
{

    public int _HealthAmount;
    public bool _YouAreDead;

    public int _HealthFullAmount;
    GameObject objs;

    private void Start()
    {

        objs = GameObject.FindGameObjectWithTag("HealthDeta");

        _HealthAmount = objs.GetComponent<HealthBetweenScene>().PlayerHealth;
        _HealthFullAmount = objs.GetComponent<HealthBetweenScene>().PlayerMaxHealth;

        _YouAreDead = false;
    }

    public void RemoveHealth(int RemoveAmount)
    {
        _HealthAmount = _HealthAmount - RemoveAmount;
        objs.GetComponent<HealthBetweenScene>().PlayerHealth = _HealthAmount;
        if (_HealthAmount <= 0)
        {
            PlayerDied();
        }
    }

    public void PlayerDied()
    {
        _YouAreDead = true;
    }

    public void AddHealth(int AddAmount)
    {
        _HealthAmount = _HealthAmount + AddAmount;

        if(_HealthAmount > _HealthFullAmount)
        {
            _HealthAmount = _HealthFullAmount;
        }
        objs.GetComponent<HealthBetweenScene>().PlayerHealth = _HealthAmount;
    }

    public void AddHealthFullAmount(int AddAmount)
    {
        _HealthFullAmount = _HealthFullAmount + AddAmount;
        objs.GetComponent<HealthBetweenScene>().PlayerMaxHealth = _HealthFullAmount;

    }

    public void FullUpHealth()
    {
        _HealthAmount = _HealthFullAmount;
        objs.GetComponent<HealthBetweenScene>().PlayerHealth = _HealthAmount;
    }
}
