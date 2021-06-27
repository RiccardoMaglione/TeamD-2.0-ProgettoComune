using UnityEngine;
using System.Collections;

public class CutsceneControllerDeathBoss : MonoBehaviour
{
    public Dialogue dialogue;

    public IEnumerator TriggerDialogue(float time)
    {
        yield return new WaitForSeconds(time);
        DialogueManagerDeathBoss.instance.StartDialogue(dialogue);
    }
}
