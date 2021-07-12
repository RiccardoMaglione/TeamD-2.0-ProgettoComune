using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public static EnergyBar EBInstance;
    public Slider EnergySlider;

    public GameObject glowing;

    private void Awake()
    {
        EBInstance = this;
    }

    private void Update()
    {
        if (EnergySlider.value == EnergySlider.maxValue)
        {
            glowing.SetActive(true);
        }
        else
        {
            glowing.SetActive(false);
        }
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
