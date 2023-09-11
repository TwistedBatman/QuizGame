using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("SelectCategory");
    }

    public void SettingsButton()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
