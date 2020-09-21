using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Dynamic;

public class Manager : MonoBehaviour
{
    private static Manager instance;

    // Los menus que obtienen los valores
    public GameObject mainMenu;
    public GameObject particleMenu;
    public GameObject erroMenu;
    public GameObject backMenu;

    // Los text fields
    public InputField speedT, angleT, fieldT;

    // Los toggle group
    public Toggle[] sign, particles;

    // En donde se guardan los valores de input
    private double speed, angle, field;
    private bool positive;
    private int particlePosition;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
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
            field = Math.Abs(field);
            // Verificando que el angulo este entre -90 y 90
            if ((angle > 90) || (angle < -90))
                return false;

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
        backMenu.SetActive(!backMenu.activeSelf);
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

    // Getters de los atributos
    public double getSpeed()
    {
        return this.speed;
    }

    public double getAngle()
    {
        return this.angle;
    }

    public double getField()
    {
        return this.field;
    }

    public bool isPositive()
    {
        return this.positive;
    }

    public int getParticlePosition()
    {
        return this.particlePosition;
    }

}
