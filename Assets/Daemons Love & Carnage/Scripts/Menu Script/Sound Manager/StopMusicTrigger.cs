using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusicTrigger : MonoBehaviour
{
    bool isEntered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isEntered == false && collision.gameObject.CompareTag("Player"))
        {
            isEntered = true;
            AudioManager.instance.FadeOut("GameplayOST2");
            AudioManager.instance.FadeOut("GameplayOST1");
        }
    }
}
