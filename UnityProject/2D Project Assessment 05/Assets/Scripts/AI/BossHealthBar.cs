using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    private Image _HealthBarIMG;
    public float _CurrentHealth;
    public float _MaxHealth;
    EnemyHealth _Boss;

    private void Start()
    {
        _HealthBarIMG = GetComponent<Image>();
        _Boss = FindObjectOfType<EnemyHealth>();
    }

    private void Update()
    {
        _CurrentHealth = _Boss._HealthAmount;
        _MaxHealth = 400.0f;

        _HealthBarIMG.fillAmount = _CurrentHealth / _MaxHealth;

    }
}
