using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovingChargedParticle : ChargedParticle
{
    public float mass = 1;
    public Rigidbody rb;

    public float equis;
    public float ye;


    private void Start()
    {
        UpdateColor();


        rb = gameObject.AddComponent<Rigidbody>();
        rb.mass = mass;
        rb.useGravity = false;

        rb.AddForce(new Vector3(equis,ye,0));
    }

}
