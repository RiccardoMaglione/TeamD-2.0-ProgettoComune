using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject destinationScreen;
    [SerializeField] GameObject currentScreen;

    public void GameTitleStart()
    {
        if (Input.anyKey)
        {
            destinationScreen.SetActive(true);
            currentScreen.SetActive(false);
        }
    }

    void Update()
    {
        GameTitleStart();
    }
}
