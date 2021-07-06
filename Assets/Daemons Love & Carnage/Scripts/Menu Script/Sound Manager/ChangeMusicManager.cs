using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusicManager : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.FadeOut("MainMenuMusic");
        AudioManager.instance.FadeIn("GameplayOST1");
    }
}
