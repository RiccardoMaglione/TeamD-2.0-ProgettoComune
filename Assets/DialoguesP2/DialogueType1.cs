using System.Collections;
using UnityEngine;

public class DialogueType1 : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox;
    [SerializeField] RectTransform startPos;
    [SerializeField] RectTransform endPos;
    [SerializeField] float speedTransition;
    [SerializeField] GameObject blackPanel;

    public bool dialogueActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            blackPanel.SetActive(true);
            Time.timeScale = 0;
            dialogueActive = true;
            dialogueBox.SetActive(true);
            StartCoroutine("DialogueIn");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopCoroutine("DialogueOut");
            dialogueBox.SetActive(false);
            Destroy(this);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dialogueActive == true)
        {
            blackPanel.SetActive(false);
            Time.timeScale = 1;
            dialogueActive = false;
            StopCoroutine("DialogueIn");
            StartCoroutine("DialogueOut");
        }
    }
    private IEnumerator DialogueIn()
    {
        while (dialogueBox.GetComponent<RectTransform>().anchoredPosition.x != endPos.position.x)
        {
            dialogueBox.GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(new Vector2(dialogueBox.GetComponent<RectTransform>().anchoredPosition.x, dialogueBox.GetComponent<RectTransform>().anchoredPosition.y), new Vector2(30, -100), speedTransition * Time.unscaledDeltaTime);
            yield return null;
        }
    }
    private IEnumerator DialogueOut()
    {
        while (dialogueBox.GetComponent<RectTransform>().anchoredPosition.x != startPos.position.x)
        {
            dialogueBox.GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(new Vector2(dialogueBox.GetComponent<RectTransform>().anchoredPosition.x, dialogueBox.GetComponent<RectTransform>().anchoredPosition.y), new Vector2(-600, -100), speedTransition * Time.unscaledDeltaTime);
            yield return null;
        }
    }

}
