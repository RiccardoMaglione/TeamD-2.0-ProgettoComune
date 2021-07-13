using System.Collections;
using System.Collections.Generic;
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

    public List<string> ListInsertTutorialText = new List<string>();

    public string FinalString;

    public bool Left;
    public bool Right;
    public bool Up;
    public bool Down;
    public bool Dash;
    public bool Possession;
    public bool Light;
    public bool Heavy;

    [SerializeField] public KeyCode buttonToSkip1;
    [SerializeField] public KeyCode buttonToSkip2;
    [SerializeField] public KeyCode buttonToSkip3;
    [SerializeField] public KeyCode buttonToSkip4;
    [SerializeField] public KeyCode ControllerButtonToSkip1;
    [SerializeField] public KeyCode ControllerButtonToSkip2;
    [SerializeField] public KeyCode ControllerButtonToSkip3;
    [SerializeField] public KeyCode ControllerButtonToSkip4;


    public bool dialogueActive = false;

    public int NumTutorial;
    public static int StaticTutorial;

    public int NumTutorial2;
    public static int StaticTutorial2;

    public int NumSkip;
    public bool IsEnableSkip;
    //0 default
    //1 ad          Se è 0 o 1 o 2 o 3 o 4 o 5
    //2 jump        Se è 0 o 2 o 3 o 4 o 5
    //3 ui          Se è 0 o 3 o 4 o 5
    //4 s           Se è 0 o 4 o 5
    //5 shift       Se è 0 o 5
    int Count;
    public void TemplateScritta()
    {
        Count = 0;
        FinalString = "";

        if (Count < ListInsertTutorialText.Count)
        {
            if (Left == true)
            {
                if (CheckInput.Controller == false)
                {
                    FinalString += ListInsertTutorialText[Count] + KeyBinding.KeyBindSet(KeyBinding.KeyBindInstance.StringKeyLeft).ToString();
                }
                else
                {
                    FinalString += ListInsertTutorialText[Count] + KeyBinding.KeyBindSetController(KeyBinding.KeyBindInstance.ControllerStringKeyLeft);
                }
                Count++;
            }
            if (Right == true)
            {
                if (CheckInput.Controller == false)
                {
                    FinalString += ListInsertTutorialText[Count] + KeyBinding.KeyBindSet(KeyBinding.KeyBindInstance.StringKeyRight).ToString();
                }
                else
                {
                    FinalString += ListInsertTutorialText[Count] + KeyBinding.KeyBindSetController(KeyBinding.KeyBindInstance.ControllerStringKeyRight);
                }
                Count++;
            }
            if (Up == true)
            {
                if (CheckInput.Controller == false)
                {
                    FinalString += ListInsertTutorialText[Count] + KeyBinding.KeyBindSet(KeyBinding.KeyBindInstance.StringKeyUp).ToString();
                }
                else
                {
                    FinalString += ListInsertTutorialText[Count] + KeyBinding.KeyBindSetController(KeyBinding.KeyBindInstance.ControllerStringKeyUp);
                }
                Count++;
            }
            if (Down == true)
            {
                if (CheckInput.Controller == false)
                {
                    FinalString += ListInsertTutorialText[Count] + KeyBinding.KeyBindSet(KeyBinding.KeyBindInstance.StringKeyDown).ToString();
                }
                else
                {
                    FinalString += ListInsertTutorialText[Count] + KeyBinding.KeyBindSetController(KeyBinding.KeyBindInstance.ControllerStringKeyDown);
                }
                Count++;
            }
            if (Dash == true)
            {
                if (CheckInput.Controller == false)
                {
                    FinalString += ListInsertTutorialText[Count] + KeyBinding.KeyBindSet(KeyBinding.KeyBindInstance.StringKeyDash).ToString();
                }
                else
                {
                    FinalString += ListInsertTutorialText[Count] + KeyBinding.KeyBindSetController(KeyBinding.KeyBindInstance.ControllerStringKeyDash);
                }
                Count++;
            }
            if (Possession == true)
            {
                if (CheckInput.Controller == false)
                {
                    FinalString += ListInsertTutorialText[Count] + KeyBinding.KeyBindSet(KeyBinding.KeyBindInstance.StringKeyPossession).ToString();
                }
                else
                {
                    FinalString += ListInsertTutorialText[Count] + KeyBinding.KeyBindSetController(KeyBinding.KeyBindInstance.ControllerStringKeyPossession);
                }
                Count++;
            }
            if (Light == true)
            {
                if (CheckInput.Controller == false)
                {
                    FinalString += ListInsertTutorialText[Count] + KeyBinding.KeyBindSet(KeyBinding.KeyBindInstance.StringKeyLightAttack).ToString();
                }
                else
                {
                    FinalString += ListInsertTutorialText[Count] + KeyBinding.KeyBindSetController(KeyBinding.KeyBindInstance.ControllerStringKeyLightAttack);
                }
                Count++;
            }
            if (Heavy == true)
            {
                if(CheckInput.Controller == false)
                {
                    FinalString += ListInsertTutorialText[Count] + KeyBinding.KeyBindSet(KeyBinding.KeyBindInstance.StringKeyHeavyAttack).ToString();
                }
                else
                {
                    FinalString += ListInsertTutorialText[Count] + KeyBinding.KeyBindSetController(KeyBinding.KeyBindInstance.ControllerStringKeyHeavyAttack);
                }
                Count++;
            }
        }
        if(Count < ListInsertTutorialText.Count)
        {
            FinalString += ListInsertTutorialText[ListInsertTutorialText.Count-1];
        }
        if(FinalString != "")
        {
            insertTutorialText = FinalString;
        }
        else
        {
            FinalString = insertTutorialText;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && PlayerPrefs.GetInt("TutorialSkip") < NumSkip)
        {
            TemplateScritta();
            dialogueBox.GetComponent<RectTransform>().anchoredPosition = new Vector2(-630, -150);

            blackPanel.SetActive(true);
            dialogueText.text = insertTutorialText;

            Time.timeScale = 0;
            dialogueBox.SetActive(true);
            StartCoroutine("DialogueIn");
            StaticTutorial = NumTutorial;
            StaticTutorial2 = NumTutorial2;
            print("Numero tutorial è " + StaticTutorial);
        }
    }

    private void DestroyCollider()
    {
        StaticTutorial++;
        StaticTutorial2++;
        print("Numero tutorial è " + StaticTutorial);
        print("2 Numero tutorial è " + StaticTutorial2);
        StopCoroutine("DialogueOut");
        Destroy(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(buttonToSkip1) && dialogueActive == true || Input.GetKeyDown(buttonToSkip2) && dialogueActive == true || Input.GetKeyDown(buttonToSkip3) && dialogueActive == true || Input.GetKeyDown(buttonToSkip4) && dialogueActive == true || Input.GetKeyDown(ControllerButtonToSkip1) && dialogueActive == true || Input.GetKeyDown(ControllerButtonToSkip2) && dialogueActive == true || Input.GetKeyDown(ControllerButtonToSkip3) && dialogueActive == true || Input.GetKeyDown(ControllerButtonToSkip4) && dialogueActive == true)
        {
            dialogueActive = false;
            StopCoroutine("DialogueIn");
            StartCoroutine("DialogueOut");
            if (IsEnableSkip == true)
            {
                PlayerPrefs.SetInt("TutorialSkip", NumSkip);
            }
            Invoke("DestroyCollider", 0.1f);

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
