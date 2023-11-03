using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private ScoreController scoreController;

    private void Start()
    {
        scoreController = ScoreController.instance;
        scoreController.OnScoreChange += UpdateScore;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + scoreController.score.ToString();
    }
}
