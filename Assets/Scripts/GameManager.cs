using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Question> questions;
    public TextAsset fileData;
    public TextMeshProUGUI questionCounter;
    public GameObject[] options;
    public int currentQuestion;
    public TextMeshProUGUI[] answersTxt;
    public TextMeshProUGUI questionTxt;
    public GameObject finishPanel;
    public GameObject StopPanel;
    public bool success;
    private GameObject correctOption;
    public Sprite correct;
    public Sprite wrong;
    public Sprite original;
    public int category;
    public GameObject returnPanel;
    private string categoryName;
    int counter = 1;
    public int correctAnswers = 0;


    private void Start()
    {
        success = true;
        SetCategory();
    }

    // Set the category depending on the user's choice
    private void SetCategory()
    {
        category = FindObjectOfType<SelectedCategory>().category;
        switch (category)
        {
            case 11:
                categoryName = "Greek Geography";
                break;
            case 12:
                categoryName = "World Geography";
                break;
            case 21:
                categoryName = "Greek History";
                break;            
            case 22:
                categoryName = "World History";
                break;
            case 31:
                categoryName = "Animals";
                break;
            case 32:
                categoryName = "Plants";
                break;
            case 40:
                categoryName = "Space";
                break;
        }
        ImportData(categoryName);
    }

    // Read the file and pass to a list only the questions from the selected category
    public void ImportData(string category)
    {
        string[] data = fileData.text.Split(new string[] { ",", "\n" }, System.StringSplitOptions.None);

        for (int i = 0, j = 7, k = 0; i < data.Length / 7; i++, j += 7)
        {
            if (data[j] == category)
            {
                questions[k].question = data[j + 1];
                questions[k].answers[0] = data[j + 2];
                questions[k].answers[1] = data[j + 3];
                questions[k].answers[2] = data[j + 4];
                questions[k].answers[3] = data[j + 5];
                questions[k].correctAnswer = System.Convert.ToInt32(data[j + 6]);
                k++;
            }
        }
        GetQuestion();
    }

    // Get a random question from the list
    private void GetQuestion()
    {
        if (questions.Count > 0) // Check if there are any more questions
        {
            currentQuestion = Random.Range(0, questions.Count);
            questionTxt.text = questions[currentQuestion].question;
            SetAnswers();
        }
        else
            finishPanel.SetActive(true);
    }

    //  Fill the option buttons with the given answers
    private void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            
            options[i].GetComponent<Answer>().isCorrect = false; // Initialize all answers as false
            options[i].GetComponent<Image>().sprite = original; // Initialize all answers with blue  
            answersTxt[i].text = questions[currentQuestion].answers[i]; // Set the answers on the buttons

            // Find the correct answer and make it true
            if (questions[currentQuestion].correctAnswer == i + 1)
            {
                options[i].GetComponent<Answer>().isCorrect = true;
                correctOption = options[i];
            }
        }
    }

    // If the answer is correct get next answer
    public void CorrectAnswer()
    {
        correctAnswers++;
        questions.RemoveAt(currentQuestion); // Remove the current question
        correctOption.GetComponent<Image>().sprite = correct; // Make the right choice green
        StartCoroutine(waitSeconds(1));
    }

    public void FalseAnswer(GameObject optionClicked)
    {
        success = false;
        questions.RemoveAt(currentQuestion); // Remove the current question
        optionClicked.GetComponent<Image>().sprite = wrong; // Make the wrong choice red
        correctOption.GetComponent<Image>().sprite = correct; // Make the right choice green
        StartCoroutine(waitSeconds(4));
    }

    IEnumerator waitSeconds(int sec)
    {
        StopPanel.SetActive(true);
        yield return new WaitForSeconds(sec);
        StopPanel.SetActive(false);
        counter++;
        if(counter <= 20)
            questionCounter.SetText(counter + "/20");
        GetQuestion();
    }
    public void ReturnCategoryButton()
    {
        CompletedCategory();
        SceneManager.LoadScene("SelectCategory");
    }

    public void ReturnMenuButtonFinish()
    {
        CompletedCategory();
        SceneManager.LoadScene("MainMenu");
    }
    public void ReturnButton()
    {
        returnPanel.SetActive(true);
    }

    public void ReturnMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ReturnGameButton()
    {
        returnPanel.SetActive(false);
    }

    // When there are no more questions check if they were are correctly answered
    public void CompletedCategory()
    {
        if(success)
        {
            FindObjectOfType<SavedSettings>().category = category;
            FindObjectOfType<SavedSettings>().SaveData();
        }
    }
}
