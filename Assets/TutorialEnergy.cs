using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class TutorialEnergy : MonoBehaviour
{
    public static bool TutorialEnergyBool;
    public GameObject PanelTutorial;

    public static TutorialEnergy TutorialEnergyInstance;

    public int NumSkip;
    public int TutSkip;
    private void Update()
    {
        EnableTutorialEnergy();
        TutSkip = PlayerPrefs.GetInt("TutorialSkipEnergy");
    }

    public void EnableTutorialEnergy()
    {
        if(TutorialEnergyBool == false && ChangeFollow.StaticPlayerTemp.GetComponent<PSMController>().CurrentEnergy == 100 && PlayerPrefs.GetInt("TutorialSkipEnergy") < NumSkip)
        {
            Time.timeScale = 0;
            PanelTutorial.SetActive(true);

            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                PlayerPrefs.SetInt("TutorialSkipEnergy", NumSkip);
                Time.timeScale = 1;
                PanelTutorial.SetActive(false);
                TutorialEnergyBool = true;
            }
        }
        else if(PlayerPrefs.GetInt("TutorialSkipEnergy") >= NumSkip)
        {
            TutorialEnergyBool = true;
        }
    }
}
