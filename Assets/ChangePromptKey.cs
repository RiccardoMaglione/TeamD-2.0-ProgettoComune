using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePromptKey : MonoBehaviour
{
    void Update()
    {
        ChangePrompt();
    }

    public void ChangePrompt()
    {
        GetComponent<SpriteRenderer>().sprite = KeyBinding.KeyBind.KeyPossession.GetComponent<Image>().sprite;
    }
}
