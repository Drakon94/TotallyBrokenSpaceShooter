using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Collider2D))]
public class PlayerController : MonoBehaviour {

    public float maxSpeed = 180.0f;
    public float rotationSpeed = 180.0f;
    public float recoilPower = 5.0f;
    public float reloadTime = 0.75f;
    public GameObject bulletPrefab;
    public AudioClip shootingSound;
    public Animator transitionAnim;
    private bool cloneCreated = false;
    private float lastTimeShot = 0f;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        GetComponent<ScreenWrapper>().TurnOn();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        var r = rb2d.rotation + rotationSpeed * Time.deltaTime * -Input.GetAxis("Horizontal");
        rb2d.MoveRotation(r);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time - lastTimeShot > reloadTime)
            {
                lastTimeShot = Time.time;
                transitionAnim.SetTrigger("shoot");
                GetComponent<AudioSource>().PlayOneShot(shootingSound);
                rb2d.AddForce(-(transform.up * recoilPower));
                Instantiate(bulletPrefab, transform.position, transform.rotation);
                if(rb2d.velocity.magnitude > maxSpeed)
                {
                    rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
                }
            }
        }
	}
}
