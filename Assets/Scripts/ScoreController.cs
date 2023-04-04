using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//////////////////////////////////////////////
//Assignment/Lab/Project: Arcade Project
//Name: James Deglow
//Section: 2023SP.SGD.285.4171
//Instructor: Aurore Locklear
//Date: 4/3/2023
/////////////////////////////////////////////
public class ScoreController : MonoBehaviour
{
    [SerializeField] TMP_Text[] scoreTexts;
    private bool gameOver = false;

    private int playerScore = 0;
    public void AddToScore(int pointsToAdd)
    {
        if(!gameOver)
        {
            playerScore += pointsToAdd;
            foreach (TMP_Text text in scoreTexts)
            {
                text.text = playerScore.ToString();
            }
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

    public void PauseScore()
    {
        gameOver = true;
    }


}
