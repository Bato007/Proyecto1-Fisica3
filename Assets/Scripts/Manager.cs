﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class Manager : MonoBehaviour
{
    // Referencia unica
    static Manager instance;

    // Los menus que obtienen los valores
    public GameObject mainMenu;
    public GameObject particleMenu;
    public GameObject erroMenu;

    // Los text fields
    public InputField speedT, angleT, fieldT;

    // Los toggle group
    public Toggle[] sign, particles;

    // En donde se guardan los valores de input
    private double speed, angle, field;
    private bool positive;
    private int particlePosition;

    // Start is called before the first frame update
    void Start()
    {
        NoDestroy();
    }

    public void GoSimulation(int indexScene)
    {
        if (CheckField())
        {
            // Verificando el signo
            if (sign[0].isOn)
            {
                positive = true;
            }else
            {
                positive = false;
            }

            // Verificando la particula
            for (int i = 0; i < particles.Length; i++)
            {
                if (particles[i].isOn)
                {
                    particlePosition = i; 
                }
            }

            // Cambiar a la simulación
            ChangeScene(indexScene);
        }
        else
        {
            ChangeError();
        }
                
    }

    // Verifica si se puede convertir el texto en numero
    public bool CheckField()
    {
        try
        {
            speed = System.Convert.ToDouble(speedT.text);
            angle = System.Convert.ToDouble(angleT.text);
            field = System.Convert.ToDouble(fieldT.text);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    public void ChangeError()
    {
        erroMenu.SetActive(!erroMenu.activeSelf);
    }

    public void ChangeView()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        particleMenu.SetActive(!particleMenu.activeSelf);
    }

    public void ChangeScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }

    public void NoDestroy()
    {
        if(instance == null)
        {
            instance = null;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}