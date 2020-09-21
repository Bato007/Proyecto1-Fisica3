﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerS : MonoBehaviour
{

    // Menu de pausa
    public GameObject backGround;
    public GameObject pauseMenu;
    public GameObject finishMenu;
    public Text maxheight;

    private bool active = false;
    private float scale = 0.05f;

    public float time = 0;
    private GameObject particleGO;
    private MovingChargedParticle particle;
    private bool flag = true;
    private bool finish = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        // Verifica si ya se instancio la particula
        if (!particleGO)
        {
            try
            {
                particleGO = GameObject.FindGameObjectWithTag("Particle");
            }
            catch (System.Exception)
            {

            }

        } 
        
        // Obtiene el objeto
        if(flag && particleGO)
        {
            particle = GameObject.FindObjectOfType<MovingChargedParticle>();
            flag = false;
        }

        //Verifica si ya se tiene que terminar
        if (particleGO && (particle.isInEnd() || (time >= 0.35f)) && !finish)
        {
            Finish();
        }


        // Pausa
        if (Input.GetKeyDown(KeyCode.Escape) && !finish)
        {
            TogglePause();
        }
    }



    public void TogglePause()
    {
        if (pauseMenu)
        {
            backGround.SetActive(!backGround.activeSelf);
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            active = !active;
            Time.timeScale = active ? 0.0f : scale;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }

    public void Finish()
    {
        finish = true;
        Time.timeScale = 0;
        maxheight.text = "Altura Máxima:" + particle.getMax().ToString();
        backGround.SetActive(!backGround.activeSelf);
        finishMenu.SetActive(!finishMenu.activeSelf);
    }

}
