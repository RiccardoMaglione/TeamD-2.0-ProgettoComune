﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject GameTitle;
    public GameObject startingScreen;
    public GameObject options;
    public GameObject credits;
    public GameObject exitScreen;

    public void GoToGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void GoToStartingScreen()
    {      
        startingScreen.SetActive(true);
        GameTitle.SetActive(false);
        options.SetActive(false);
        credits.SetActive(false);
        exitScreen.SetActive(false);
    }

    public void GoToOption()
    {
        options.SetActive(true);
        startingScreen.SetActive(false);           
    }

    public void GoToExit()
    {
        exitScreen.SetActive(true);
        startingScreen.SetActive(false);
    }

    public void GoToCredits()
    {
        credits.SetActive(true);
        startingScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
