using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;
using TMPro;

public class TutorialEnergy : MonoBehaviour
{
    public static TutorialEnergy TutorialEnergyInstance;

    public GameObject DialogueBox;
    public RectTransform StartPos;
    public RectTransform EndPos;
    public float SpeedTransition;
    public GameObject BlackPanel;
    public TextMeshProUGUI dialogueText;
    [TextArea] public string insertTutorialText;

    public static bool TutorialEnergyBool;
    public bool DialogueActive;

    public int NumSkip;
    public int TutSkip;

    public KeyCode buttonToSkip1;
    public KeyCode buttonToSkip2;
    public KeyCode buttonToSkip3;
    private void Update()
    {
        //EnableTutorialEnergy();
        TutSkip = PlayerPrefs.GetInt("TutorialSkipEnergy");

        EnergyTrue();
        StartIn();
        StopInStartOut();
    }

    public void EnergyTrue()
    {
        if (PlayerPrefs.GetInt("TutorialSkipEnergy") >= NumSkip)
        {
            TutorialEnergyBool = true;
        }
    }

    public void StartIn()
    {
        if (TutorialEnergyBool == false && ChangeFollow.StaticPlayerTemp.GetComponent<PSMController>().CurrentEnergy == 100 && PlayerPrefs.GetInt("TutorialSkipEnergy") < NumSkip)
        {
            DialogueBox.GetComponent<RectTransform>().anchoredPosition = new Vector2(-630, -150);
            PSMController.disableAllInput = true;
            BlackPanel.SetActive(true);
            dialogueText.text = insertTutorialText;
            Time.timeScale = 0;
            DialogueBox.SetActive(true);
            StartCoroutine("DialogueIn");
        }
    }

    public void StopInStartOut()
    {
        if ((Input.GetKeyDown(buttonToSkip1) || (Input.GetKeyDown(buttonToSkip2) && CheckInput.XboxController == true) || (Input.GetKeyDown(buttonToSkip3) && CheckInput.PlaystationController == true)) && DialogueActive == true && TutorialEnergyBool == false)
        {
            PlayerPrefs.SetInt("TutorialSkipEnergy", NumSkip);
            TutorialEnergyBool = true;
            DialogueActive = false;
            StopCoroutine("DialogueIn");
            StartCoroutine("DialogueOut");
            PSMController.disableAllInput = false;
            Invoke("StopOut", 0.1f);
        }
    }

    private void StopOut()
    {
        StopCoroutine("DialogueOut");
        //gameObject.SetActive(false);
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
    public IEnumerator DialogueOut()
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
