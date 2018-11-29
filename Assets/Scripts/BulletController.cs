using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Collider2D))]
public class BulletController : MonoBehaviour {

    public float thrust = 100.0f;
    public float timeBeforeDestruction = 12f;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(transform.up * thrust);
        Destroy(gameObject, timeBeforeDestruction);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player" && collision.tag != "Bullet")
        {
            collision.GetComponent<Hittable>().Hit(transform.position, collision.tag);
            Destroy(gameObject);
        }
    }
}
