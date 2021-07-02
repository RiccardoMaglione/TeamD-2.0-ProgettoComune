using SwordGame;
using System.Collections;
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
    [SerializeField] GameObject bossBar;
    [SerializeField] GameObject playerBar;

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
        Time.timeScale = 0;
        playerBar.SetActive(false);
        FindObjectOfType<BossEnabler>().ActiveBoss();
        bossfightImage.SetActive(true);
        yield return new WaitForSecondsRealtime(bossfightImageTime);
        PSMController.disableAllInput = false;
        bossfightImage.SetActive(false);
        bossBar.SetActive(true);
        playerBar.SetActive(true);
        Time.timeScale = 1;
    }
}
