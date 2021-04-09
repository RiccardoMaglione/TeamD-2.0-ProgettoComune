using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    void Update()
    {
        if (DialogueManager.instance.isTalk)
            if (Input.anyKeyDown)
                DialogueManager.instance.DisplayNextSentence();
    }
}
