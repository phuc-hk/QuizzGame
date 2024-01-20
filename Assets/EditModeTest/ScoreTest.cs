using NUnit.Framework;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class QuizzControllerTest
{
    [Test]
    public void CheckAnswerTest()
    {
        // Load the scene
        EditorSceneManager.OpenScene("Assets/Scenes/Scene01.unity");

        // Get the QuizController object
        GameObject quizControllerObject = GameObject.Find("GameController");
        QuizzController quizController = quizControllerObject.GetComponent<QuizzController>();

        // Set up the test
        quizController.question.text = "What is the capital of Canada?";
        quizController.answerButtons[0].GetComponentInChildren<TextMeshProUGUI>().text = "Toronto";
        quizController.answerButtons[1].GetComponentInChildren<TextMeshProUGUI>().text = "Ottawa";
        quizController.answer = "Ottawa";

        Debug.Log(quizController.answerButtons[0].name);
        Debug.Log(quizController.answerButtons[1].name);
        // Call the CheckAnswer() function with correct answer
        quizController.CheckAnswer(quizController.answerButtons[1]);

        // Check if the score is increased by 1
        Assert.AreEqual(ScoreController.instance.score, 1);

        // Call the CheckAnswer() function with incorrect answer
        quizController.CheckAnswer(quizController.answerButtons[0]);

        // Check if the score is decreased by 1
        Assert.AreEqual(ScoreController.instance.score, 0);
    }
}