using UnityEngine;

public class Answer : MonoBehaviour
{
    public bool isCorrect = false;
    public GameManager gameManager;
    [HideInInspector]
    public bool success = true;
    GameObject optionClicked;

    // Check if the sected option is correct
    public void Answers()
    {
        if(isCorrect)
        {
            gameManager.CorrectAnswer();
        }
        else
        {
            success = false;
            optionClicked = gameObject;
            gameManager.FalseAnswer(optionClicked);            
        }
    }
}
