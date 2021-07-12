using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;
using TMPro;

public class TutorialEnergy : MonoBehaviour
{
    public static bool TutorialEnergyBool;

    public static TutorialEnergy TutorialEnergyInstance;

    public GameObject DialogueBox;
    public RectTransform StartPos;
    public RectTransform EndPos;
    public float SpeedTransition;
    public GameObject BlackPanel;
    public TextMeshProUGUI dialogueText;
    [TextArea] public string insertTutorialText;

    public bool DialogueActive;

    public int NumSkip;
    public int TutSkip;
    private void Update()
    {
        EnableTutorialEnergy();
        TutSkip = PlayerPrefs.GetInt("TutorialSkipEnergy");
    }

    public void EnableTutorialEnergy()
    {
        if(TutorialEnergyBool == false && ChangeFollow.StaticPlayerTemp.GetComponent<PSMController>().CurrentEnergy == 100 && PlayerPrefs.GetInt("TutorialSkipEnergy") < NumSkip)
        {
            BlackPanel.SetActive(true);
            dialogueText.text = insertTutorialText;
            Time.timeScale = 0;
            DialogueBox.SetActive(true);
            StartCoroutine(DialogueIn());
            Debug.Log("Passa in dialogue in");
        }
        else if(PlayerPrefs.GetInt("TutorialSkipEnergy") >= NumSkip)
        {
            TutorialEnergyBool = true;
        }

        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && DialogueActive == true && TutorialEnergyBool == false)
        {
            TutorialEnergyBool = true;
            PlayerPrefs.SetInt("TutorialSkipEnergy", NumSkip);

            DialogueActive = false;
            StopCoroutine("DialogueIn");
            StartCoroutine(DialogueOut());
            Debug.Log("Passa in dialogue out");
            //PanelTutorial.SetActive(false);
        }
    }

    public IEnumerator DialogueIn()
    {
        while (DialogueBox.GetComponent<RectTransform>().anchoredPosition.x != EndPos.position.x)
        {
            DialogueBox.GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(new Vector2(DialogueBox.GetComponent<RectTransform>().anchoredPosition.x, DialogueBox.GetComponent<RectTransform>().anchoredPosition.y), new Vector2(-130, -150), SpeedTransition * Time.unscaledDeltaTime);
            if (DialogueBox.GetComponent<RectTransform>().anchoredPosition == new Vector2(-130, -150))
            {
                DialogueActive = true;
            }
            yield return null;
        }
    }
    private IEnumerator DialogueOut()
    {
        while (DialogueBox.GetComponent<RectTransform>().anchoredPosition.x != StartPos.position.x)
        {
            DialogueBox.GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(new Vector2(DialogueBox.GetComponent<RectTransform>().anchoredPosition.x, DialogueBox.GetComponent<RectTransform>().anchoredPosition.y), new Vector2(-630, -150), SpeedTransition * Time.unscaledDeltaTime);
            if (DialogueBox.GetComponent<RectTransform>().anchoredPosition == new Vector2(-630, -150))
            {
                Time.timeScale = 1;
                BlackPanel.SetActive(false);
            }

            yield return null;
        }
    }
}
