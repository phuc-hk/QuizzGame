using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizzController : MonoBehaviour
{
    [SerializeField] QuizSO quizSO;
    [SerializeField] TextMeshProUGUI question;
    [SerializeField] Button[] answerButtons;
    string answer;

    void Start()
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
        Debug.Log(button.GetComponentInChildren<TextMeshProUGUI>().text == answer ? "correct" : "false");
    }
}
