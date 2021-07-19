using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestTutorialEnergy : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox;
    [SerializeField] RectTransform startPos;
    [SerializeField] RectTransform endPos;
    [SerializeField] float speedTransition;
    [SerializeField] GameObject blackPanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [TextArea]
    [SerializeField] private string insertTutorialText;

    public bool dialogueActive = false;

    public void MethodTest()
    {

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            dialogueBox.GetComponent<RectTransform>().anchoredPosition = new Vector2(-630, -150);

            blackPanel.SetActive(true);
            dialogueText.text = insertTutorialText;
            Time.timeScale = 0;
            dialogueBox.SetActive(true);
            StartCoroutine("DialogueIn");
        }
        if (Input.GetKeyDown(KeyCode.L) && dialogueActive == true)
        {
            dialogueActive = false;
            StopCoroutine("DialogueIn");
            StartCoroutine("DialogueOut");
        }
    }
    private IEnumerator DialogueIn()
    {
        while (dialogueBox.GetComponent<RectTransform>().anchoredPosition.x != endPos.position.x)
        {
            dialogueBox.GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(new Vector2(dialogueBox.GetComponent<RectTransform>().anchoredPosition.x, dialogueBox.GetComponent<RectTransform>().anchoredPosition.y), new Vector2(-130, -150), speedTransition * Time.unscaledDeltaTime);
            if (dialogueBox.GetComponent<RectTransform>().anchoredPosition == new Vector2(-130, -150))
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
            dialogueBox.GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(new Vector2(dialogueBox.GetComponent<RectTransform>().anchoredPosition.x, dialogueBox.GetComponent<RectTransform>().anchoredPosition.y), new Vector2(-630, -150), speedTransition * Time.unscaledDeltaTime);
            if (dialogueBox.GetComponent<RectTransform>().anchoredPosition == new Vector2(-630, -150))
            {
                Time.timeScale = 1;
                blackPanel.SetActive(false);

            }

            yield return null;
        }
    }

}
