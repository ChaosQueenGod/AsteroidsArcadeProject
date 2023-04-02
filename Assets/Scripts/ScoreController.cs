using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TMP_Text[] scoreTexts;

    private int playerScore = 0;
    public void AddToScore(int pointsToAdd)
    {
        playerScore += pointsToAdd;
        foreach(TMP_Text text in scoreTexts)
        {
            text.text = playerScore.ToString();
        }
    }

    public void ResetScore()
    {
        playerScore = 0;
        foreach (TMP_Text text in scoreTexts)
        {
            text.text = playerScore.ToString();
        }
    }
}
