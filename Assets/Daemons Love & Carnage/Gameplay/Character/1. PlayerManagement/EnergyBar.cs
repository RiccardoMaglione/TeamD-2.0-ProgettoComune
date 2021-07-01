﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public static EnergyBar EBInstance;
    public Slider EnergySlider;

    private void Awake()
    {
        EBInstance = this;
    }

    public void MaxEnergy(int Energy) //setta il valore massimo 
    {
        EnergySlider.maxValue = Energy;
    }

    public void SetEnergy(float Energy) //setta il valore della barra con la variabile intera
    {
        EnergySlider.value = Energy;
    }
}
