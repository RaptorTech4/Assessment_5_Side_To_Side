using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTheGame : MonoBehaviour
{

    public Canvas Winning;

    private void Start()
    {
        Winning.enabled = false;
    }

    public void YouWin()
    {
        Winning.enabled = true;
        Time.timeScale = 0;
    }
}
