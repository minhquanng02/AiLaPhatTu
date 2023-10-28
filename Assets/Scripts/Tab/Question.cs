using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Question : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI answerAText;
    public TextMeshProUGUI answerBText;
    public TextMeshProUGUI answerCText;
    public TextMeshProUGUI answerDText;

    public Quiz quiz;

    private void Start()
    {
        questionText.text = quiz.question;
        answerAText.text = quiz.answerA;
        answerBText.text = quiz.answerB;
        answerCText.text = quiz.answerC;
        answerDText.text = quiz.answerD;
    }
}
