using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCutsceneEntry : MonoBehaviour
{
    private void Awake()
    {
        AudioManager.instance.FadeOut("BossOST");
    }
}
