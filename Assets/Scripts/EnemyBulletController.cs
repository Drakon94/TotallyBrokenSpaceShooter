using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class EnemyBulletController : MonoBehaviour
{

    public float thrust = 100.0f;
    public float timeBeforeDestruction = 12f;
    private Transform target;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        try
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            Vector3 difference = target.position - transform.position;
            float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotz - 90);
        }
        catch(NullReferenceException e)
        {
            Debug.Log(e);
        }
        rb2d.AddForce(transform.up * thrust);

        Destroy(gameObject, timeBeforeDestruction);
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
