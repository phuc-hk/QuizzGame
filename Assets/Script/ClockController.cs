using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion;
    private float currentTime;
    [SerializeField] QuizzController quizzController;

    private void Start()
    {
        currentTime = timeToCompleteQuestion;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            ResetTimer();
            quizzController.isLoadNextQuestion = true;
        }
        //else
        //{
        //    quizzController.isLoadNextQuestion = false;
        //}
        if (quizzController.isAnswerDone)
        {
            ResetTimer();
        }
    }

    private void ResetTimer()
    {
        currentTime = timeToCompleteQuestion;
    }

    public float GetTimerPercentage()
    {
        return currentTime / timeToCompleteQuestion;
    }
}
