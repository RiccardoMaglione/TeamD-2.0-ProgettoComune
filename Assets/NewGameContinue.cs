using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameContinue : MonoBehaviour
{
    public Button NewGame;
    public Button Continue;

    public GameObject PanelConfirmNewGame;

    void Update()
    {
        if(PlayerPrefs.GetInt("NewGameFirst") == 0)
        {
            Continue.interactable = false;
        }
        else
        {
            Continue.interactable = true;
        }
    }

    public void ConfirmNewGame()
    {
        if (PlayerPrefs.GetInt("NewGameFirst") == 1)
        {
            PanelConfirmNewGame.SetActive(true);
        }
    }

    public void SetNewGame()
    {
        PlayerPrefs.SetInt("NewGameFirst", 1);
    }
    public void ResetSetNewGame()
    {
        PlayerPrefs.SetInt("NewGameFirst", 0);
    }
}
