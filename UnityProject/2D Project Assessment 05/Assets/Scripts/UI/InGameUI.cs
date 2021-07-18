using UnityEngine;
using UnityEngine.SceneManagement;


public class InGameUI : MonoBehaviour
{

    public bool _PauseMenuActev = false;
    public Canvas InGameCanvas;
    public Canvas _PauseMenuCanvas;
    public Canvas _DeathCanvas;

    PlayerHealthSystem _Player;
    bool _PlayerDied;

    void Start()
    {
        _PauseMenuActev = false;
        _PauseMenuCanvas.enabled = false;
        _DeathCanvas.enabled = false;
        InGameCanvas.enabled = true;

        Time.timeScale = 1;
        _Player = FindObjectOfType<PlayerHealthSystem>();
    }

    void Update()
    {
        if (Input.GetButton("PauseMenu"))
        {
            pauseTheGame();
        }

        _PlayerDied = _Player._YouAreDead;
        if(_PlayerDied)
        {
            _PauseMenuActev = false;
            _PauseMenuCanvas.enabled = false;
            _DeathCanvas.enabled = true;
            InGameCanvas.enabled = false;
            Time.timeScale = 0;
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

    public void TryAgain()
    {
        SceneManager.LoadScene("MainLevel");
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
