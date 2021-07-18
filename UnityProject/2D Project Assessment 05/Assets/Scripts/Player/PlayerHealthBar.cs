using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    private Image _HealthBarIMG;
    public float _CurrentHealth;
    public float _MaxHealth;
    PlayerHealthSystem _Player;

    private void Start()
    {
        _HealthBarIMG = GetComponent<Image>();
        _Player = FindObjectOfType<PlayerHealthSystem>();
    }

    private void Update()
    {
        _CurrentHealth = _Player._HealthAmount;
        _MaxHealth = _Player._HealthFullAmount;

        _HealthBarIMG.fillAmount = _CurrentHealth / _MaxHealth;

    }

}
