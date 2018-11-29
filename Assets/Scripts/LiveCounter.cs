using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveCounter : MonoBehaviour
{

    public int lives;
    public int maxNumOfLives = 3;
    public GameObject deathPrefab;
    public AudioClip gameOverSound;
    public AudioClip lifeGainedSound;
    public Animator[] heartAnimators;
    private GameObject[] hearts;
    [SerializeField] GameObject player;
    [SerializeField] GameObject gameOverScreen;

    // Use this for initialization
    void Start()
    {
        lives = maxNumOfLives;
        hearts = new GameObject[maxNumOfLives];
        for (int i = 0; i < maxNumOfLives; i++)
        {
            hearts[i] = transform.GetChild(i).gameObject;
        }
    }

    public void AddLife()
    {
        lives++;
        GetComponent<AudioSource>().PlayOneShot(lifeGainedSound);
        if (lives > maxNumOfLives)
        {
            FindObjectOfType<UIScoreCounter>().IncreaseScore(30);
            lives = maxNumOfLives;
        }
        UpdateGraphics();
    }

    public void RemoveLife()
    {
        lives--;
        if (lives <= 0)
        {
            Instantiate(deathPrefab, player.transform.position, Quaternion.identity);
            GetComponent<AudioSource>().PlayOneShot(gameOverSound);
            GameObject.Destroy(player);
            gameOverScreen.SetActive(true);
            FindObjectOfType<PlayerController>().enabled = false;
        }
        UpdateGraphics();
    }

    public void UpdateGraphics()
    {
        for (int i = 0; i < maxNumOfLives; i++)
        {
            if (i >= lives)
            {
                if(i == 0)
                {
                    if (hearts[i].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idleHeart"))
                    {
                        hearts[i].GetComponent<Animator>().SetTrigger("lifeLost1");
                    }
                }
                if (i == 1)
                {
                    if (hearts[i].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idleHeart2"))
                    {
                        hearts[i].GetComponent<Animator>().SetTrigger("lifeLost2");
                    }
                }
                if (i == 2)
                {
                    if (hearts[i].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idleHeart3"))
                    {
                        hearts[i].GetComponent<Animator>().SetTrigger("lifeLost3");
                    }
                }
            }
            else
            {
                if (i == 0)
                {
                    if (hearts[i].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("inactiveHeart"))
                    {
                        hearts[i].GetComponent<Animator>().SetTrigger("lifeGained1");
                    }
                }
                if (i == 1)
                {
                    if (hearts[i].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("inactiveHeart2"))
                    {
                        hearts[i].GetComponent<Animator>().SetTrigger("lifeGained2");
                    }
                }
                if (i == 2)
                {
                    if (hearts[i].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("inactiveHeart3"))
                    {
                        hearts[i].GetComponent<Animator>().SetTrigger("lifeGained3");
                    }
                }
            }
        }
    }
}
