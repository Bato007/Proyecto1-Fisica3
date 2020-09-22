using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedParticle : MonoBehaviour
{

    public float charge = 1;
    Color color;
    private Manager manager;


    private void Awake()
    {
        manager = GameObject.FindObjectOfType<Manager>();
    }
    private void Start()
    {
        UpdateData();
        UpdateColor();
    }

    public void UpdateColor()
    {
        if (charge == 0)
            color = Color.blue;
        if (charge > 0)
            color = Color.green;
        if (charge < 0)
            color = Color.red;
        
        GetComponent<Renderer>().material.color = color;
    }

    private void UpdateData()
    {
        if (manager.isPositive())
            charge = (float)manager.getField();
        else
            charge = (float)manager.getField() * -1;
    }
}
