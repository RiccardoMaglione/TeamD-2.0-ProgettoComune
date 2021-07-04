using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameplayMusicController : MonoBehaviour
{
    bool isEntered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isEntered == false && collision.gameObject.CompareTag("Player"))
        {
            isEntered = true;
            AudioManager.instance.Stop("GameplayOST1");
            AudioManager.instance.Play("GameplayOST2");
        }       
    }
}
