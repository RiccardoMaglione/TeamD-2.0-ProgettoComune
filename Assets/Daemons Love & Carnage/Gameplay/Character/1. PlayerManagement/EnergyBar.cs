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
            glowing.GetComponent<Image>().fillAmount = 1;
            GetComponentInChildren<Image>().color = new Color(0, 0, 0, 0);
        }
        else if (EnergySlider.value == 0)
        {
            glowing.SetActive(false);
            GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
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
