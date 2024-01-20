using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class QuizzController : MonoBehaviour
{
    //Question and answer
    [SerializeField] QuizSO[] quizSO;
    private QuizSO quizz;
    private int currentQuestionIndex = 0;
    [SerializeField] public TextMeshProUGUI question;
    [SerializeField] public Button[] answerButtons;

    public string answer;
    public bool isLoadNextQuestion = false;
    public bool isAnswerDone = false;

    void Start()
    {
        DisplayAnswer();
    }

    private void Update()
    {
        if (isLoadNextQuestion)
        {
            if (currentQuestionIndex < quizSO.Length - 1)
                currentQuestionIndex++;
            else
                currentQuestionIndex = 0;
            DisplayAnswer();
            SetButtonState(true);
            ResetButtonFrame();
        }
    }
    public void DisplayAnswer()
    {
        quizz = GetQuestion(currentQuestionIndex);
        answer = quizz.GetCorrectAnswer();
        question.text = quizz.GetQuestion();
        foreach (Button answerButton in answerButtons)
        {
            answerButton.GetComponentInChildren<TextMeshProUGUI>().text = quizz.GetAnswer(Array.IndexOf(answerButtons, answerButton));
            answerButton.onClick.AddListener(() => CheckAnswer(answerButton));
        }
        isLoadNextQuestion = false;
        isAnswerDone = false;
    }

    private QuizSO GetQuestion(int index)
    {
        return quizSO[index];
    }

    public void CheckAnswer(Button button)
    {
        if (button.GetComponentInChildren<TextMeshProUGUI>().text == answer)
        {
            ScoreController.instance.ChangeScore(1);
        }
        else
        {
            ScoreController.instance.ChangeScore(-1);
        }
        isLoadNextQuestion = true;
        isAnswerDone = true;
        SetButtonState(false);
        foreach (Button answerButton in answerButtons)
        {
            answerButton.onClick.RemoveAllListeners();
        }
    }

    private void SetButtonState(bool value)
    {
        foreach (Button answerButton in answerButtons)
        {
            answerButton.GetComponent<Button>().interactable = value;
        }
    }

    private void ResetButtonFrame()
    {
        foreach (Button answerButton in answerButtons)
        {
            //answerButton.GetComponent<Image>().sprite = defaultAnswerFrame;
        }
    }
}
