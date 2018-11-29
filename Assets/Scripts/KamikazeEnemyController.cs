using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Collider2D))]
public class KamikazeEnemyController : MonoBehaviour {

    public float speed = 3.14f;
    public float pointsForDestroying = 20f;
    private Transform target;
    private Rigidbody2D rgbd2d;

	// Use this for initialization
	void Start () {
        rgbd2d = GetComponent<Rigidbody2D>();
        try
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }catch(NullReferenceException e)
        {
            Debug.Log(e);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
	}

    public float getPoints()
    {
        return pointsForDestroying;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Hittable>().Hit(transform.position, collision.tag);
            Destroy(gameObject);
        }
    }
}
