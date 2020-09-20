using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    private Manager manager;

    public List<GameObject> prefabs;

    private Vector3 start = new Vector3(-6f, 0f, 0f);

    private void Awake()
    {
        manager = GameObject.FindObjectOfType<Manager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefabs[manager.getParticlePosition()], start, Quaternion.identity);

    }

}
