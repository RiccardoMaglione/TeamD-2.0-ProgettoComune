using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;
using TMPro;

public class TutorialEnergy : MonoBehaviour
{
    public static TutorialEnergy TutorialEnergyInstance;

    public static bool TutorialEnergyBool;

    public int NumSkip;

    private void Update()
    {
        EnergyTrue();
    }

    public void EnergyTrue()
    {
        if (PlayerPrefs.GetInt("TutorialSkipEnergy") >= NumSkip)
        {
            TutorialEnergyBool = true;
        }
    }
}
