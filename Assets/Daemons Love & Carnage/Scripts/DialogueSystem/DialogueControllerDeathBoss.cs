using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueControllerDeathBoss : MonoBehaviour
{
    void Update()
    {
        if (DialogueManagerDeathBoss.instance.isTalk)
            if (Input.anyKeyDown)
                DialogueManagerDeathBoss.instance.DisplayNextSentence();
    }
}
