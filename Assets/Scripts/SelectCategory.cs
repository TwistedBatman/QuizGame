using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SelectCategory : MonoBehaviour
{
    public GameObject star1, star2, star3, star41, star42, star43, star44;
    public Sprite star;
    public GameObject tick11, tick12, tick21, tick22, tick31, tick32;
    public GameObject subButtons1, subButtons2, subButtons3;
    public Button cat4Button;
    public TextMeshProUGUI cat4Text;

    public void Awake()
    {
        LoadStars();
        LoadTicks();
    }

    // When each main category button is pressed reveal the subcategory buttons
    public void Category10()
    {
        subButtons1.SetActive(true);
    }    
    public void Category20()
    {
        subButtons2.SetActive(true);
    }   
    public void Category30()
    {
        subButtons3.SetActive(true);
    }

    // Choose category depending on the button pressed and load the game
    public void Category11()
    {
        SceneManager.LoadScene("MainLevel");
        FindObjectOfType<SelectedCategory>().category = 11;
    }    
    public void Category12()
    {
        SceneManager.LoadScene("MainLevel");
        FindObjectOfType<SelectedCategory>().category = 12;
    }
    public void Category21()
    {    
        SceneManager.LoadScene("MainLevel");        
        FindObjectOfType<SelectedCategory>().category = 21;
    }
    public void Category22()
    {    
        SceneManager.LoadScene("MainLevel");        
        FindObjectOfType<SelectedCategory>().category = 22;
    }
    public void Category31()
    {
        SceneManager.LoadScene("MainLevel");
        FindObjectOfType<SelectedCategory>().category = 31;
    }
    public void Category32()
    {
        SceneManager.LoadScene("MainLevel");
        FindObjectOfType<SelectedCategory>().category = 32;
    }
    public void Category40()
    {
        SceneManager.LoadScene("MainLevel");
        FindObjectOfType<SelectedCategory>().category = 40;
    }

    // Load the stars by checking if the category is completed or not
    public void LoadStars()
    {
        FindObjectOfType<SavedSettings>().LoadData();
        
        if (FindObjectOfType<SavedSettings>().cat11 == 1 && FindObjectOfType<SavedSettings>().cat12 == 1)
        {
            star1.GetComponent<Image>().sprite = star;
            star41.GetComponent<Image>().sprite = star;
        }
        if (FindObjectOfType<SavedSettings>().cat21 == 1 && FindObjectOfType<SavedSettings>().cat22 == 1)
        {
            star2.GetComponent<Image>().sprite = star; 
            star42.GetComponent<Image>().sprite = star; 
        }
        if (FindObjectOfType<SavedSettings>().cat31 == 1 && FindObjectOfType<SavedSettings>().cat32 == 1)
        {
            star3.GetComponent<Image>().sprite = star; 
            star43.GetComponent<Image>().sprite = star; 
        }
        if (star41.GetComponent<Image>().sprite.name == "GUI_24" && star42.GetComponent<Image>().sprite.name == "GUI_24" && star43.GetComponent<Image>().sprite.name == "GUI_24")
        {
            cat4Button.interactable = true;
            cat4Text.text = "Συγχαρητήρια ολοκληρωσες επιτυχώς όλες τις προηγούμενες κατηγορίες\nΜπορείς τώρα να συνεχίσεις με την κατηγορία Διάστημα";
        }
        // Show a message when all categories are completed
        if (FindObjectOfType<SavedSettings>().cat44 == 1)
        {
            star44.GetComponent<Image>().sprite = star;
            cat4Text.text = "Συγχαρητήρια ολοκληρωσες επιτυχώς όλες τις κατηγορίες";
        }
    }

    // Load the ticks by checking if the category is completed or not
    public void LoadTicks()
    {
        if (FindObjectOfType<SavedSettings>().cat11 == 1)
            tick11.SetActive(true);
        if (FindObjectOfType<SavedSettings>().cat12 == 1)
            tick12.SetActive(true);
        if (FindObjectOfType<SavedSettings>().cat21 == 1)
            tick21.SetActive(true);
        if (FindObjectOfType<SavedSettings>().cat22 == 1)
            tick22.SetActive(true);
        if (FindObjectOfType<SavedSettings>().cat31 == 1)
            tick31.SetActive(true);
        if (FindObjectOfType<SavedSettings>().cat32 == 1)
            tick32.SetActive(true);
    }

    public void ReturnButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
