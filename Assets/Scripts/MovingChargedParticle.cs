using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovingChargedParticle : ChargedParticle
{
    public float mass = 1;
    public Rigidbody rb;
    public float velocity = 0;
    public float angle = 0;
    public float highest = 0;
    private Manager manager;

    private bool hitEnd = false;

    private void Awake()
    {
        manager = GameObject.FindObjectOfType<Manager>();
    }
    private void Start()
    {

        UpdateData();

        rb.mass = mass;
        rb.useGravity = false;

        rb.velocity = new Vector3(velocity * Mathf.Cos(angle*Mathf.PI/180), velocity * Mathf.Sin(angle * Mathf.PI / 180), 0);

       

        UpdateColor();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Field") || collision.gameObject.CompareTag("Stop"))
            hitEnd = true;
    }

    private void Update()
    {
        if(angle > 0)
        {
            if (transform.position.y > highest)
                highest = transform.position.y;
        }
        if (angle < 0)
        {
            if (transform.position.y < highest)
                highest = transform.position.y;
        }
        
    }

    private void UpdateData()
    {
        velocity = (float)manager.getSpeed() ;
        angle = (float) manager.getAngle();

    }

    public bool isInEnd()
    {
        return this.hitEnd;
    }

    public float getMax()
    {
        return this.highest;
    }
}
