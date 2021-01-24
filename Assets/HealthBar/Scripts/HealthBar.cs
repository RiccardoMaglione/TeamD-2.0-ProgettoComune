﻿using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider sliderBar;

    public void MaxHealth(int health) //setta il valore massimo 
    {
        sliderBar.maxValue = health;
    }

    public void SetHealth(int health) //setta il valore della barra con la variabile intera
    {
        sliderBar.value = health;
    }
}
