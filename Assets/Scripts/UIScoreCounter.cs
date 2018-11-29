using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreCounter : MonoBehaviour {

    public int scoreToNextLevel = 30;
    public int LevelProgressionHandicap = 10;
    private Text uiText;
    private int score;

	// Use this for initialization
	void Start () {
        uiText = GetComponent<Text>();
	}

    public void IncreaseScore(int points)
    {
        score += points;
        uiText.text = score.ToString();
        if(score >= scoreToNextLevel)
        {
            scoreToNextLevel += scoreToNextLevel + LevelProgressionHandicap;
            FindObjectOfType<LevelScript>().levelUp();
        }
        if(score == 100)
        {
            FindObjectOfType<LiveCounter>().AddLife();
        }
        if(score == 200)
        {
            FindObjectOfType<LiveCounter>().AddLife();
        }
        if(score == 300)
        {
            FindObjectOfType<LiveCounter>().AddLife();
        }
        if(score == 400)
        {
            FindObjectOfType<LiveCounter>().AddLife();
        }
        if(score == 500)
        {
            FindObjectOfType<LiveCounter>().AddLife();
        }
    }

    public void ResetScore()
    {
        score = 0;
        uiText.text = score.ToString();
    }

    public int getScore()
    {
        return score;
    }
}
