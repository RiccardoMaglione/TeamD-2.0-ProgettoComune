using UnityEngine;
using System.Collections;
using SwordGame;

public class CutsceneControllerDeathBoss : MonoBehaviour
{
    public Dialogue dialogue;
    public static bool isCutsceneEnabled;

    public IEnumerator TriggerDialogue(float time)
    {
        yield return new WaitForSeconds(time);
        DialogueManagerDeathBoss.instance.StartDialogue(dialogue);
    }

    void Awake()
    {
        FindObjectOfType<PSMController>().enabled = false;
        isCutsceneEnabled = true;
        AudioManager.instance.Stop("MainMenuMusic");
    }
}
