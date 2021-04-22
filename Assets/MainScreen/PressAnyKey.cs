﻿using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressAnyKey : MonoBehaviour
{
    public float flickerSpeed = 1f;
    public TextMeshProUGUI TMP;
    void Start()
    {
        StartCoroutine("Flickering");
    }
    IEnumerator Flickering()
    {
        while (true)
        {
            yield return new WaitForSeconds(flickerSpeed);
            TMP.enabled = true;
            yield return new WaitForSeconds(flickerSpeed);
            TMP.enabled = false;
        }
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            FindObjectOfType<FadeInOutTransition>().BlackPanelAppears();
            FindObjectOfType<FadeInOutTransition>().FadeIn();
            Invoke("ToMainMenu", 0.5f);
        }
    }

    void ToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
