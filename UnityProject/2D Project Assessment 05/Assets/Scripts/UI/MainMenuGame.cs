using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuGame : MonoBehaviour
{

    public Canvas MainMenu;
    public Canvas OptionsMenu;
    public Canvas QuitMenu;

    private void Start()
    {
        MainMenu.enabled = true;
        OptionsMenu.enabled = false;
        QuitMenu.enabled = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void ShowOptions()
    {
        MainMenu.enabled = false;
        OptionsMenu.enabled = true;
    }

    public void HideOptions()
    {
        MainMenu.enabled = true;
        OptionsMenu.enabled = false;
    }

    public void ShowQuitGameMenu()
    {
        MainMenu.enabled = false;
        OptionsMenu.enabled = false;
        QuitMenu.enabled = true;
    }

    public void HideQuitGameMenu()
    {
        MainMenu.enabled = true;
        OptionsMenu.enabled = false;
        QuitMenu.enabled = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
