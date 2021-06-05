using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] Animator bossImpAnim;
    [SerializeField] Animator cutscene;
    [SerializeField] GameObject ballBoss;

    [SerializeField] GameObject bossfightImage;
    [SerializeField] float bossfightImageTime;
    public Dialogue dialogue;

    [SerializeField] float bossDelayStomp;

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

    public IEnumerator InstantiateBoss()
    {      
        yield return new WaitForSecondsRealtime(bossDelayStomp);
        ballBoss.SetActive(true);
    }

    public IEnumerator ShowBossfightImage()
    {
        Time.timeScale = 0;
        bossfightImage.SetActive(true);
        yield return new WaitForSecondsRealtime(bossfightImageTime);
        bossfightImage.SetActive(false);
        Time.timeScale = 1;
    }
}
