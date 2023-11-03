using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;
    public int score;
    public Action OnScoreChange;

    private void Awake()
    {
        instance = this;
    }

    public void ChangeScore(int point)
    {      
        score += point;
        OnScoreChange?.Invoke();
    }
}
