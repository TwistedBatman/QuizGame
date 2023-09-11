using UnityEngine;

public class SavedSettings : MonoBehaviour
{
    [HideInInspector]
    public int cat11, cat12, cat21, cat22, cat31, cat32, cat44;
    public int category;
    private int flag;

    public void Awake()
    {
        // Set all the categories to 0, meaning that they are not completed, only the first time the application is opened
        flag = PlayerPrefs.GetInt("flag");
        if (flag != 1)
        {
            PlayerPrefs.SetInt("cat11", 0);
            PlayerPrefs.SetInt("cat12", 0);
            PlayerPrefs.SetInt("cat21", 0);            
            PlayerPrefs.SetInt("cat22", 0);
            PlayerPrefs.SetInt("cat31", 0);
            PlayerPrefs.SetInt("cat32", 0);
            PlayerPrefs.SetInt("cat44", 0);

            PlayerPrefs.SetInt("flag", 1);
        }
    }

    // If a category is completed save it as 1
    public void SaveData()
    {
        switch (category)
        {
            case 11:
                PlayerPrefs.SetInt("cat11", 1);
                break;
            case 12:
                PlayerPrefs.SetInt("cat12", 1);
                break;
            case 21:
                PlayerPrefs.SetInt("cat21", 1);
                break;
            case 22:
                PlayerPrefs.SetInt("cat22", 1);
                break;
            case 31:
                PlayerPrefs.SetInt("cat31", 1);
                break;
            case 32:
                PlayerPrefs.SetInt("cat32", 1);
                break;
            case 40:
                PlayerPrefs.SetInt("cat44", 1);
                break;
        }    
    }

    // Load the data which shows whether or not the category is completed
    public void LoadData()
    {
        cat11 = PlayerPrefs.GetInt("cat11");
        cat12 = PlayerPrefs.GetInt("cat12");
        cat21 = PlayerPrefs.GetInt("cat21");
        cat22 = PlayerPrefs.GetInt("cat22");        
        cat31 = PlayerPrefs.GetInt("cat31");
        cat32 = PlayerPrefs.GetInt("cat32");
        cat44 = PlayerPrefs.GetInt("cat44");
    }
}
