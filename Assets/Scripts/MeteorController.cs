using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Collider2D))]
public class MeteorController : MonoBehaviour {

    public float thrust = 100f;
    public float randomRadius = 2.0f;
    public float pointsForDestroying = 10f;
    private float centerX = 0f;
    private float centerY = 0f;
    private bool invisible = true;
    private Transform target;
    private Rigidbody2D rdgdbdy;

	// Use this for initialization
	void Start () {
        rdgdbdy = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Center").GetComponent<Transform>();

        var RandomXSeed = Random.Range(-randomRadius, randomRadius);
        var RandomYSeed = Random.Range(-randomRadius, randomRadius);

        centerX = RandomXSeed + target.position.x;
        centerY = RandomYSeed + target.position.y;

        Vector3 difference = new Vector3(centerX, centerY, 0f) - transform.position;
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz - 90);

        rdgdbdy.AddForce(transform.up* thrust);
    }

    private void OnBecameVisible()
    {
        invisible = false;
        GetComponent<ScreenWrapper>().TurnOn();
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
