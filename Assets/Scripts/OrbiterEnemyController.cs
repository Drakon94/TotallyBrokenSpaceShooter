using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Collider2D))]
public class OrbiterEnemyController : MonoBehaviour {

    public float speed = 3.14f;
    public float rotatingSpeed = 40f;
    public float radius = 5.5f;
    public float pointsForDestroying = 30f;
    public float reloadTime = 1.5f;
    public GameObject bulletPrefab;
    private bool wasInRange = false;
    private bool canShoot = false;
    private float lastTimeShot = 0f;
    private Transform target;
    private Rigidbody2D rgbd2d;

    // Use this for initialization
    void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        try
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        } catch(NullReferenceException e)
        {
            Debug.Log(e);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!wasInRange)
        {
            MoveTowardsPlayer();
        }
        else
        {
            if (!isInRotatingRange())
            {
                MoveTowardsPlayer();
            } else
            {
                rotateAroundPlayer();
            }
        }
        if (Time.time - lastTimeShot > reloadTime)
        {
            if (Time.time - lastTimeShot > reloadTime)
            {

                if (canShoot)
                {
                    lastTimeShot = Time.time;
                    Instantiate(bulletPrefab, transform.position, transform.rotation);
                }
            }
        }
    }

    void MoveTowardsPlayer()
    {
        try
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }catch(MissingReferenceException e)
        {
            Debug.Log(e);
        }
        if (isInRotatingRange())
        {
            wasInRange = true;
        }
    }

    void rotateAroundPlayer()
    {
        try
        {
            transform.RotateAround(target.position, new Vector3(0, 0, 1), rotatingSpeed * Time.deltaTime);
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }

    public float getPoints()
    {
        return pointsForDestroying;
    }

    bool isInRotatingRange()
    {
        try
        {
            if(target != null && transform != null)
            {
                return Vector3.Distance(target.position, transform.position) <= radius;
            }
            else
            {
                return false;
            }
        }
        catch (MissingReferenceException e)
        {
            Debug.Log(e);
            return false;
        }
    }

    private void OnBecameVisible()
    {
        canShoot = true;
    }

    private void OnBecameInvisible()
    {
        canShoot = false;
    }
}
