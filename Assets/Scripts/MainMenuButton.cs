using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour {

    public Animator transitionAnim;

    public void StartGame()
    {
        StartCoroutine(LoadScene());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadScene()
    {
        GetComponentInParent<Canvas>().sortingOrder = -1;
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("IntroScene");
    }
}
