using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public TextMeshProUGUI congratsTxt;
    //public TextMeshProUGUI nextTxt;

    public GameManager GM;
    int correctAnswers;
    
    // Show a message depending the number of the questions the user got right 
    private void Start()
    {
        correctAnswers = GM.correctAnswers;
        if (correctAnswers >= 20)
            congratsTxt.text = ("Συγχαρητήρια, ολοκλήρωσες επιτυχώς το επίπεδο!");
        else if(correctAnswers >= 15)
            congratsTxt.text = ("Μπράβο, βρήκες " + correctAnswers + " από τις 20 ερωτήσεις.");
        else if (correctAnswers >= 10)
            congratsTxt.text = ("Καλά τα πήγες, βρήκες " + correctAnswers + " από τις 20 ερωτήσεις.");
        else
            congratsTxt.text = ("Δεν τα πήγες και πολύ καλά, βρήκες " + correctAnswers + " από τις 20 ερωτήσεις.");
    }
}
