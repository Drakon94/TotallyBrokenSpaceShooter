using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class Hittable : MonoBehaviour {

    public GameObject explosionPrefab;
    public AudioClip explosionSound;

    public void Hit(Vector3 hitCoordinates, string tag)
    {
        Instantiate(explosionPrefab, hitCoordinates, Quaternion.identity);
        GetComponent<AudioSource>().PlayOneShot(explosionSound);
        if (tag != "Player")
        {
            if(tag == "EnemyMeteor")
            {
                FindObjectOfType<UIScoreCounter>().IncreaseScore(10);
            }
            if (tag == "EnemyKamikaze")
            {
                FindObjectOfType<UIScoreCounter>().IncreaseScore(20);
            }
            if (tag == "EnemyOrbiter")
            {
                FindObjectOfType<UIScoreCounter>().IncreaseScore(30);
            }
            GetComponent<Renderer>().enabled = false;
            GameObject.Destroy(gameObject, explosionSound.length);
            Destroy(this);
        } else
        {
            FindObjectOfType<LiveCounter>().RemoveLife();
        }
    }

}
