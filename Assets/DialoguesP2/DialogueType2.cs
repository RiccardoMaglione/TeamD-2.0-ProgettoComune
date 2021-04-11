using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueType2 : MonoBehaviour
{
    [SerializeField] GameObject playerDialogueBox;
    [SerializeField] GameObject bossDialogueBox;

    [SerializeField] RectTransform startPos;
    [SerializeField] RectTransform endPos;
    [SerializeField] RectTransform bossStartPos;
    [SerializeField] RectTransform bossEndPos;

    [SerializeField] float speedTransition;
    [SerializeField] private TextMeshProUGUI playerDialogueText;
    [SerializeField] private TextMeshProUGUI bossDialogueText;

    [TextArea]
    [SerializeField] private string insertBossText;
    [TextArea]
    [SerializeField] private string insertPlayerText;

    [SerializeField] float dialogueUpTime;

    public bool dialogueStarted = false;

    public int killToActivateDialogue;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && dialogueStarted == false && killToActivateDialogue <= FindObjectOfType<KilledEnemyCounter>().killedEnemyCounter)
        {
            dialogueStarted = true;

            playerDialogueBox.GetComponent<RectTransform>().anchoredPosition = new Vector2(-600, -240);
            bossDialogueBox.GetComponent<RectTransform>().anchoredPosition = new Vector2(2020, -240);

            bossDialogueText.text = insertBossText;
            playerDialogueText.text = insertPlayerText;

            playerDialogueBox.SetActive(true);
            StartCoroutine("BossDialogueIn");
        }
    }

    private void DestroyCollider()
    {
        StopCoroutine("PlayerDialogueOut");
        dialogueStarted = false;
        Destroy(this);
    }

    private IEnumerator PlayerDialogueIn()
    {
        while (playerDialogueBox.GetComponent<RectTransform>().anchoredPosition.x != endPos.position.x)
        {
            playerDialogueBox.GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(new Vector2(playerDialogueBox.GetComponent<RectTransform>().anchoredPosition.x, playerDialogueBox.GetComponent<RectTransform>().anchoredPosition.y), new Vector2(30, -240), speedTransition * Time.unscaledDeltaTime);
            if (playerDialogueBox.GetComponent<RectTransform>().anchoredPosition == new Vector2(30, -240))
            {
                yield return new WaitForSecondsRealtime(dialogueUpTime);
                StopCoroutine("PlayerDialogueIn");
                StartCoroutine("PlayerDialogueOut");
                Invoke("DestroyCollider", 0.4f);
            }

            yield return null;
        }
    }
    private IEnumerator PlayerDialogueOut()
    {
        while (playerDialogueBox.GetComponent<RectTransform>().anchoredPosition.x != startPos.position.x)
        {
            playerDialogueBox.GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(new Vector2(playerDialogueBox.GetComponent<RectTransform>().anchoredPosition.x, playerDialogueBox.GetComponent<RectTransform>().anchoredPosition.y), new Vector2(-600, -240), speedTransition * Time.unscaledDeltaTime);
            yield return null;
        }
    }
    private IEnumerator BossDialogueIn()
    {
        while (bossDialogueBox.GetComponent<RectTransform>().anchoredPosition.x != bossEndPos.position.x)
        {
            bossDialogueBox.GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(new Vector2(bossDialogueBox.GetComponent<RectTransform>().anchoredPosition.x, bossDialogueBox.GetComponent<RectTransform>().anchoredPosition.y), new Vector2(1390, -240), speedTransition * Time.unscaledDeltaTime);
            if (bossDialogueBox.GetComponent<RectTransform>().anchoredPosition == new Vector2(1390, -240))
            {
                yield return new WaitForSecondsRealtime(dialogueUpTime);
                StopCoroutine("BossDialogueIn");
                StartCoroutine("BossDialogueOut");
            }

            yield return null;
        }
    }
    private IEnumerator BossDialogueOut()
    {
        while (bossDialogueBox.GetComponent<RectTransform>().anchoredPosition.x != bossStartPos.position.x)
        {
            bossDialogueBox.GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(new Vector2(bossDialogueBox.GetComponent<RectTransform>().anchoredPosition.x, bossDialogueBox.GetComponent<RectTransform>().anchoredPosition.y), new Vector2(2020, -240), speedTransition * Time.unscaledDeltaTime);
            if (bossDialogueBox.GetComponent<RectTransform>().anchoredPosition == new Vector2(2020, -240))
            {
                yield return new WaitForSeconds(1);
                StartCoroutine("PlayerDialogueIn");
            }

            yield return null;
        }
    }

}
