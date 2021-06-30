using System.Collections;
using UnityEngine;
using SwordGame;

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
        PSMController.disableAllInput = true;
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
        FindObjectOfType<BossEnabler>().ActiveBoss();
        bossfightImage.SetActive(true);
        yield return new WaitForSecondsRealtime(bossfightImageTime);
        PSMController.disableAllInput = false;
        bossfightImage.SetActive(false);
    }
}
