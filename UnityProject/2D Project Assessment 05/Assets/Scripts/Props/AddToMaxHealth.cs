using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToMaxHealth : MonoBehaviour
{
    public int AddHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealthSystem>().AddHealthFullAmount(AddHealth);
            Destroy(gameObject);
        }
    }
}
