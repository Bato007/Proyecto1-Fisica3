﻿using System;
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


    private void Awake()
    {
        manager = GameObject.FindObjectOfType<Manager>();
    }
    private void Start()
    {

        UpdateData();

        rb = gameObject.AddComponent<Rigidbody>();
        rb.mass = mass;
        rb.useGravity = false;

        rb.velocity = new Vector3(velocity * Mathf.Abs(Mathf.Cos(angle)), velocity * Mathf.Sin(angle), 0);

        UpdateColor();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Field" || collision.gameObject.tag == "Stop")
            Time.timeScale = 0;
    }

    private void Update()
    {
        if (transform.position.y > highest)
            highest = transform.position.y;
    }

    private void UpdateData()
    {
        velocity = (float)manager.getSpeed() ;
        angle = (float) manager.getAngle();

    }

}
