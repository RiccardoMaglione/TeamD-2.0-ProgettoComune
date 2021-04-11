using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueType1 : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox;
    [SerializeField] RectTransform startPos;
    [SerializeField] RectTransform endPos;
    [SerializeField] float speedTransition;
    [SerializeField] GameObject blackPanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [TextArea]
    [SerializeField] private string insertTutorialText;
    [SerializeField] public KeyCode buttonToSkip1;
    [SerializeField] public KeyCode buttonToSkip2;

    public bool dialogueActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueBox.GetComponent<RectTransform>().anchoredPosition = new Vector2(-600, -240);

            blackPanel.SetActive(true);
            dialogueText.text = insertTutorialText;
            Time.timeScale = 0;
            dialogueBox.SetActive(true);
            StartCoroutine("DialogueIn");
        }
    }

    private void DestroyCollider()
    {
        StopCoroutine("DialogueOut");
        Destroy(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(buttonToSkip1) && dialogueActive == true || Input.GetKeyDown(buttonToSkip2) && dialogueActive == true)
        {
            blackPanel.SetActive(false);
            Time.timeScale = 1;
            dialogueActive = false;
            StopCoroutine("DialogueIn");
            StartCoroutine("DialogueOut");

            Invoke("DestroyCollider", 0.4f);

        }
    }
    private IEnumerator DialogueIn()
    {
        while (dialogueBox.GetComponent<RectTransform>().anchoredPosition.x != endPos.position.x)
        {
            dialogueBox.GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(new Vector2(dialogueBox.GetComponent<RectTransform>().anchoredPosition.x, dialogueBox.GetComponent<RectTransform>().anchoredPosition.y), new Vector2(30, -240), speedTransition * Time.unscaledDeltaTime);
            if (dialogueBox.GetComponent<RectTransform>().anchoredPosition == new Vector2(30, -240))
            {
                dialogueActive = true;
            }
            yield return null;
        }
    }
    private IEnumerator DialogueOut()
    {
        while (dialogueBox.GetComponent<RectTransform>().anchoredPosition.x != startPos.position.x)
        {
            dialogueBox.GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(new Vector2(dialogueBox.GetComponent<RectTransform>().anchoredPosition.x, dialogueBox.GetComponent<RectTransform>().anchoredPosition.y), new Vector2(-600, -240), speedTransition * Time.unscaledDeltaTime);
            yield return null;
        }
    }

}
