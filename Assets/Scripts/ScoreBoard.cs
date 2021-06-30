using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//This class communicates with Enemy Class
public class ScoreBoard : MonoBehaviour 
{
    float score;
    TMP_Text scoreText;
    
     void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Start";
    }
    public void increaseScorebyKill(float amountToIncrease)
    {
        score += amountToIncrease;
        scoreText.text = score.ToString();
    }
    public void increaseScorebyHit(float amountToIncrease)
    {
        score += amountToIncrease;
        scoreText.text = score.ToString();
    }
  
}
