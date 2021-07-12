using UnityEngine;
using UnityEngine.SceneManagement;


public class InGameUI : MonoBehaviour
{

    public bool _PauseMenuActev = false;
    public Canvas InGameCanvas;
    public Canvas _PauseMenuCanvas;

    void Start()
    {
        _PauseMenuActev = false;
        _PauseMenuCanvas.enabled = false;
        InGameCanvas.enabled = true;
    }

    void Update()
    {
        if (Input.GetButton("PauseMenu"))
        {
            pauseTheGame();
        }
    }

    public void pauseTheGame()
    {
        _PauseMenuActev = true;
        _PauseMenuCanvas.enabled = true;
        InGameCanvas.enabled = false;
        Time.timeScale = 0;
    }

    public void PlayTheGame()
    {

        Debug.Log("Play");

        _PauseMenuActev = false;
        _PauseMenuCanvas.enabled = false;
        InGameCanvas.enabled = true;
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
