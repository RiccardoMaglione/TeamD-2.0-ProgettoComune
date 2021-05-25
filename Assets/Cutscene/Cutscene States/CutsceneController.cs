using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] Animator bossImpAnim;
    [SerializeField] Animator cutscene;
    public Dialogue dialogue;

    public void EnterTrigger()
    {
        Time.timeScale = 0;
        bossImpAnim.SetTrigger("GoToSurprise");
        cutscene.SetTrigger("GoToTalk");
    }

    public void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
