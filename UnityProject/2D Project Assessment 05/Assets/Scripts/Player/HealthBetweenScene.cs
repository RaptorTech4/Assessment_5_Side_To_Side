using UnityEngine;

public class HealthBetweenScene : MonoBehaviour
{

    public int PlayerHealth, PlayerMaxHealth;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("HealthDeta");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);


        PlayerHealth = 100;
        PlayerMaxHealth = 100;
    }
}
