/******************************************************************************
Author: Marcus

Name of Class: HealthBar

Description of Class: Makes health bar react to hp.

******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //reference slider
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        //set slider to value
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        //change slider value
        slider.value = health;
    }
}
