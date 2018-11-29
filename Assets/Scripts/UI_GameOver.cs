using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameOver : MonoBehaviour {

    public Animator transitionAnim;
    [SerializeField] GameObject gameOverScreen;

    public void PlayAgain()
    {
        StartCoroutine(LoadScene("GameScene"));
    }

    public void ReturnToMenu()
    {
        StartCoroutine(LoadScene("MainMenu"));
    }

    IEnumerator LoadScene(string sceneName)
    {
        GetComponentInParent<Canvas>().sortingOrder = -1;
        gameOverScreen.SetActive(true);
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
