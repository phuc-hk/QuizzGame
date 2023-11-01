using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizzController : MonoBehaviour
{
    [SerializeField] QuizSO quizSO;
    [SerializeField] TextMeshProUGUI question;
    [SerializeField] Button[] answers;
    string answer;
    // Start is called before the first frame update
    void Start()
    {
        
        answer = quizSO.GetCorrectAnswer();
        question.text = quizSO.GetQuestion();
        for (int index = 0; index < answers.Length; index++)
        {
            Debug.Log(answers[index].name);
            answers[index].GetComponentInChildren<TextMeshProUGUI>().text 
                = quizSO.GetAnswer(index);
            //answers[index].onClick.AddListener(() => CheckAnswer(answers[index]));
        }
    }

    public void CheckAnswer(Button button)
    {
        if (button.GetComponentInChildren<TextMeshProUGUI>().text == answer)
        {
            Debug.Log("correct");
        }
        else
        {
            Debug.Log("false");
        }
    }


}
