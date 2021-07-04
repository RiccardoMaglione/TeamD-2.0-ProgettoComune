using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusicManager : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.Stop("MainMenuMusic");
        AudioManager.instance.Play("GameplayOST1");
    }
}
