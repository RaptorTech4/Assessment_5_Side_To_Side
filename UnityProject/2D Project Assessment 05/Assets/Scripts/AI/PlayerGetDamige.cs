using UnityEngine;

public class PlayerGetDamige : MonoBehaviour
{

    [SerializeField] private bool _InstendDeath, _GiveDamige;
    [SerializeField] private int _DamigeGiven;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_InstendDeath)
            {
                InstantDeath(collision.gameObject);
            }
            if (_GiveDamige)
            {
                GiveDamige(collision.gameObject);
            }
        }
    }

    public void InstantDeath(GameObject Player)
    {
        PlayerHealthSystem phs = Player.GetComponent<PlayerHealthSystem>();
        phs.PlayerDied();
    }

    public void GiveDamige(GameObject Player)
    {
        PlayerHealthSystem phs = Player.GetComponent<PlayerHealthSystem>();
        phs.RemoveHealth(_DamigeGiven);
    }
}
