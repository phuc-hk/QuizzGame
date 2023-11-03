using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizzController : MonoBehaviour
{
    //Question and answer
    [SerializeField] QuizSO quizSO;
    [SerializeField] TextMeshProUGUI question;
    [SerializeField] Button[] answerButtons;

    [SerializeField] Sprite defaultAnswerFrame;
    [SerializeField] Sprite correctAnswerFrame;

    string answer;

    void Start()
    {
        DisplayAnswer();
    }

    private void DisplayAnswer()
    {
        answer = quizSO.GetCorrectAnswer();
        question.text = quizSO.GetQuestion();
        foreach (Button answerButton in answerButtons)
        {
            answerButton.GetComponentInChildren<TextMeshProUGUI>().text = quizSO.GetAnswer(Array.IndexOf(answerButtons, answerButton));
            answerButton.onClick.AddListener(() => CheckAnswer(answerButton));
        }
    }

    public void CheckAnswer(Button button)
    {
        //Debug.Log(button.GetComponentInChildren<TextMeshProUGUI>().text == answer ? "correct" : "false");
        if (button.GetComponentInChildren<TextMeshProUGUI>().text == answer)
        {
            button.GetComponent<Image>().sprite = correctAnswerFrame;
            ScoreController.instance.ChangeScore(1);
        }
        else
        {
            button.GetComponent<Image>().sprite = defaultAnswerFrame;
            ScoreController.instance.ChangeScore(-1);
        }
        SetButtonState(false);
    }

    private void SetButtonState(bool value)
    {
        foreach (Button answerButton in answerButtons)
        {
            answerButton.GetComponent<Button>().interactable = value;
        }
    }
}
