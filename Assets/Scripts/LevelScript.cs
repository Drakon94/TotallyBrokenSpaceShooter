using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour {

    public Animator transitionAnim;
    public AudioClip levelUpSound;
    private Text levelText;
    private int currentLevel = 1;

	// Use this for initialization
	void Start () {
        levelText = GetComponent<Text>();
    }
	
	public void levelUp()
    {
        currentLevel += 1;
        levelText.text = "Level " + currentLevel.ToString();
        GetComponent<AudioSource>().PlayOneShot(levelUpSound);
        transitionAnim.SetTrigger("levelUp");
    }

    public void resetLevel()
    {
        currentLevel = 1;
        levelText.text = "Level " + currentLevel.ToString();
    }

    public int getCurrentLevel()
    {
        return currentLevel;
    }
}
