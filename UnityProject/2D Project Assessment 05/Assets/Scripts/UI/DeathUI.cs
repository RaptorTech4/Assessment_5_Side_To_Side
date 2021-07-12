using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{

    public Canvas _DeathCanvis;

    private void Start()
    {
        _DeathCanvis.enabled = true;
        _DeathCanvis.gameObject.SetActive(true);
    }

    public void TryAgian()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
