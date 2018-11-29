using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    public Text textDisplay;
    public string[] sentences;
    public float typingSpeed = 0.025f;
    public AudioClip typingSound;
    public GameObject continueButton;
    private int index;

	// Use this for initialization
	void Start () {
        StartCoroutine(Type());
	}

    private void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        }
    }

    public void Skip()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            GetComponent<AudioSource>().PlayOneShot(typingSound);
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
