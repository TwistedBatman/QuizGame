using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public GameObject confirmationPanel;
    public GameObject confirmationText;

    // Delete all saved data
    public void DeleteData()
    {
        PlayerPrefs.SetInt("cat11", 0);
        PlayerPrefs.SetInt("cat12", 0);
        PlayerPrefs.SetInt("cat21", 0);
        PlayerPrefs.SetInt("cat22", 0);
        PlayerPrefs.SetInt("cat31", 0);
        PlayerPrefs.SetInt("cat32", 0);
        PlayerPrefs.SetInt("cat44", 0);
    }

    public void DeleteButton()
    {
        confirmationPanel.SetActive(true);
    }
    public void ReturnButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void YesButton()
    {
        DeleteData();
        confirmationPanel.SetActive(false);
        confirmationText.SetActive(true);
    }
    public void NoButton()
    {
        confirmationPanel.SetActive(false);
        confirmationText.SetActive(false);
    }
}
