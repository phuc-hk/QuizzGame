using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quizz", menuName = "New Quiz Answer", order = 1)]
public class QuizSO : ScriptableObject
{
    [TextArea(1, 4)]
    [SerializeField] string question = "What answer is it";

    [SerializeField] string[] answer;

    [SerializeField] int correctAnswerIndex;

    public string GetQuestion()
    {
        return question;
    }

    public string GetAnswer(int index)
    {
        return answer[index];
    }

    public string GetCorrectAnswer()
    {
        return answer[correctAnswerIndex];
    }

    internal int GetAnswerCount()
    {
        return answer.Length;
    }
}    
