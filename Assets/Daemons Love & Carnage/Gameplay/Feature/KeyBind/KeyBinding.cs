using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class KeyBinding : KeyVar
{
    public static KeyBinding KeyBindInstance;

    public static Func<string, KeyCode> KeyBindSet;
    public static Action<Button> SetListener;

    [HideInInspector] public Text KeyText;
    [HideInInspector] public bool ActivateGetKey;

    Button TempButton;

    public Sprite SpriteStandardKeyUp;
    public Sprite SpriteStandardKeyDown;
    public Sprite SpriteStandardKeyLeft;
    public Sprite SpriteStandardKeyRight;
    public Sprite SpriteStandardKeyDashShift;
    public Sprite SpriteStandardKeyDashCtrl;
    public Sprite SpriteStandardKeyPossession;
    public Sprite SpriteStandardKeyLightAttack;
    public Sprite SpriteStandardKeyHeavyAttack;
    public Sprite SpriteStandardKeySpecialAttack;

    public Sprite SpriteStandardKeyEsc;
    public Sprite SpriteStandardKeySpace;
    public Sprite SpriteStandardKeyLeftClick;

    public Sprite SpriteEmpty;
    public bool ActivateCondition;


    public Sprite SpriteStandardA;
    public Sprite SpriteStandardB;
    public Sprite SpriteStandardX;
    public Sprite SpriteStandardY;



    private void Awake()
    {
        GetStringKeyPrefs();
        AssignButtonContainer();
        AssignSpriteStringContainer();

        ControllerGetStringKeyPrefs();
        //ControllerAssignSpriteStringContainer();

        KeyBindInstance = this;

        KeyBindSet = SetKeyBind;
        SetListener = ListenerOnClik;

        SetAddListener();
    }
    private void Update()
    {
        ButtonKeyListener();

        AssignStringContainer();
        ControllerAssignStringContainer();

        if (CheckInput.Controller == false)
        {
            AssignSpriteStringContainer();
            print("metti sprite tastiera");
        }
        else if (CheckInput.Controller == true)
        {
            ControllerAssignSpriteStringContainer();
            print("metti sprite joystick");
        }
        
        GetKeyUp();
    }

    public void ListenerOnClik(Button ButtonKey)
    {
        ActivateGetKey = true;
        KeyText = ButtonKey.GetComponentInChildren<Text>();
        TempButton = ButtonKey;
        //TempButton.GetComponent<Image>().sprite = SpriteEmpty;
        KeyText.text = "";
    }

    public void SetAddListener()
    {
        if (KeyUp != null)
            KeyUp.onClick.AddListener(delegate { ListenerOnClik(KeyUp); });
        if (KeyDown != null)
            KeyDown.onClick.AddListener(delegate { ListenerOnClik(KeyDown); });
        if (KeyLeft != null)
            KeyLeft.onClick.AddListener(delegate { ListenerOnClik(KeyLeft); });
        if (KeyRight != null)
            KeyRight.onClick.AddListener(delegate { ListenerOnClik(KeyRight); });
        if (KeyDash != null)
            KeyDash.onClick.AddListener(delegate { ListenerOnClik(KeyDash); });
        if (KeyPossession != null)
            KeyPossession.onClick.AddListener(delegate { ListenerOnClik(KeyPossession); });
        if (KeyLightAttack != null)
            KeyLightAttack.onClick.AddListener(delegate { ListenerOnClik(KeyLightAttack); });
        if (KeyHeavyAttack != null)
            KeyHeavyAttack.onClick.AddListener(delegate { ListenerOnClik(KeyHeavyAttack); });
        if (KeySpecialAttack != null)
            KeySpecialAttack.onClick.AddListener(delegate { ListenerOnClik(KeySpecialAttack); });
    }

    public void ButtonKeyListener()
    {
        if (ActivateGetKey == true && ActivateCondition == true)
        {
            foreach (KeyCode vKey in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vKey) && CheckInput.Controller == false)
                {
                    ActivateGetKey = false;
                    ActivateCondition = false;
                    KeyText.text = vKey.ToString();
                    PlayerPrefs.SetString(TempButton.name.ToString(), KeyText.text);
                    TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                    AssignSpriteStandardContainer(vKey);
                }
                else if (Input.GetKey(vKey) && CheckInput.Controller == true)
                {
                    ActivateGetKey = false;
                    ActivateCondition = false;
                    KeyText.text = vKey.ToString();
                    PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                    TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                    ControllerAssignSpriteStandardContainer(vKey);
                }
            }
        }
    }

    public KeyCode SetKeyBind(string KeyValue)
    {
        if(ActivateGetKey == false)
        {
            KeyCode NewKey = (KeyCode)Enum.Parse(typeof(KeyCode), KeyValue);
            print(NewKey.ToString());
            return NewKey;
        }
        return KeyCode.None;
    }
    public KeyCode SetKeyBindController(string KeyValue)
    {
        if (ActivateGetKey == false)
        {
            KeyCode NewKey = (KeyCode)Enum.Parse(typeof(KeyCode), KeyValue);
            print(NewKey.ToString());
            return NewKey;
        }
        return KeyCode.None;
    }
    public void AssingSpriteStandard(KeyCode vKey, KeyCode StandardKeyCode, Sprite SpriteKey, Button ButtonKey)
    {
        if (vKey == StandardKeyCode && SpriteKey != null)
        {
            ButtonKey.GetComponent<Image>().sprite = SpriteKey;
            KeyText.text = "";
        }
    }

    public void AssignSpriteStandardContainer(KeyCode vKey)
    {
        AssingSpriteStandard(vKey, KeyCode.UpArrow, SpriteStandardKeyUp, TempButton);
        AssingSpriteStandard(vKey, KeyCode.DownArrow, SpriteStandardKeyDown, TempButton);
        AssingSpriteStandard(vKey, KeyCode.RightArrow, SpriteStandardKeyRight, TempButton);
        AssingSpriteStandard(vKey, KeyCode.LeftArrow, SpriteStandardKeyLeft, TempButton);

        AssingSpriteStandard(vKey, KeyCode.LeftShift, SpriteStandardKeyDashShift, TempButton);
        AssingSpriteStandard(vKey, KeyCode.LeftControl, SpriteStandardKeyDashCtrl, TempButton);
        
        AssingSpriteStandard(vKey, KeyCode.Z, SpriteStandardKeyLightAttack, TempButton);
        AssingSpriteStandard(vKey, KeyCode.X, SpriteStandardKeyHeavyAttack, TempButton);
        AssingSpriteStandard(vKey, KeyCode.C, SpriteStandardKeySpecialAttack, TempButton);
        AssingSpriteStandard(vKey, KeyCode.V, SpriteStandardKeyPossession, TempButton);

        AssingSpriteStandard(vKey, KeyCode.Mouse0, SpriteStandardKeyLeftClick, TempButton);
        AssingSpriteStandard(vKey, KeyCode.Space, SpriteStandardKeySpace, TempButton);
        AssingSpriteStandard(vKey, KeyCode.Escape, SpriteStandardKeyEsc, TempButton);
    }

    public void AssingSpriteStringStandard(string KeyName, string Keystring, Button ButtonKey, Sprite SpriteKey)
    {
        if (KeyName == Keystring)
        {
            ButtonKey.GetComponent<Image>().sprite = SpriteKey;
            ButtonKey.GetComponentInChildren<Text>().text = "";
        }
    }

    public void AssignAllSpriteButton(string KeyName, Sprite SpriteStandard)
    {
        AssingSpriteStringStandard(KeyName, PlayerPrefs.GetString(KeyUp.name.ToString()), KeyUp, SpriteStandard);
        AssingSpriteStringStandard(KeyName, PlayerPrefs.GetString(KeyDown.name.ToString()), KeyDown, SpriteStandard);
        AssingSpriteStringStandard(KeyName, PlayerPrefs.GetString(KeyLeft.name.ToString()), KeyLeft, SpriteStandard);
        AssingSpriteStringStandard(KeyName, PlayerPrefs.GetString(KeyRight.name.ToString()), KeyRight, SpriteStandard);
        AssingSpriteStringStandard(KeyName, PlayerPrefs.GetString(KeyDash.name.ToString()), KeyDash, SpriteStandard);
        AssingSpriteStringStandard(KeyName, PlayerPrefs.GetString(KeyPossession.name.ToString()), KeyPossession, SpriteStandard);
        AssingSpriteStringStandard(KeyName, PlayerPrefs.GetString(KeyLightAttack.name.ToString()), KeyLightAttack, SpriteStandard);
        AssingSpriteStringStandard(KeyName, PlayerPrefs.GetString(KeyHeavyAttack.name.ToString()), KeyHeavyAttack, SpriteStandard);
        AssingSpriteStringStandard(KeyName, PlayerPrefs.GetString(KeySpecialAttack.name.ToString()), KeySpecialAttack, SpriteStandard);
    }

    public void AssignSpriteStringContainer()
    {
        AssignAllSpriteButton("UpArrow", SpriteStandardKeyUp);
        AssignAllSpriteButton("DownArrow", SpriteStandardKeyDown);
        AssignAllSpriteButton("RightArrow", SpriteStandardKeyRight);
        AssignAllSpriteButton("LeftArrow", SpriteStandardKeyLeft);
        AssignAllSpriteButton("LeftShift", SpriteStandardKeyDashShift);
        AssignAllSpriteButton("LeftControl", SpriteStandardKeyDashCtrl);
        AssignAllSpriteButton("Z", SpriteStandardKeyLightAttack);
        AssignAllSpriteButton("X", SpriteStandardKeyHeavyAttack);
        AssignAllSpriteButton("C", SpriteStandardKeySpecialAttack);
        AssignAllSpriteButton("V", SpriteStandardKeyPossession);
        AssignAllSpriteButton("Mouse0", SpriteStandardKeyLeftClick);
        AssignAllSpriteButton("Space", SpriteStandardKeySpace);
        AssignAllSpriteButton("Escape", SpriteStandardKeyEsc);
    }

    public void GetKeyUp()
    {
        if (ActivateGetKey == true)
        {
            foreach (KeyCode vKey in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyUp(vKey))
                {
                    ActivateCondition = true;
                }
            }
        }
    }






    #region Controller
    public void ControllerAssingSpriteStandard(KeyCode vKey, KeyCode StandardKeyCode, Sprite SpriteKey, Button ButtonKey)
    {
        if (vKey == StandardKeyCode && SpriteKey != null)
        {
            ButtonKey.GetComponent<Image>().sprite = SpriteKey;
            KeyText.text = "";
        }
    }

    public void ControllerAssignSpriteStandardContainer(KeyCode vKey)
    {
        ControllerAssingSpriteStandard(vKey, KeyCode.Joystick1Button0, SpriteStandardA, TempButton);
        ControllerAssingSpriteStandard(vKey, KeyCode.Joystick1Button1, SpriteStandardB, TempButton);
        ControllerAssingSpriteStandard(vKey, KeyCode.Joystick1Button2, SpriteStandardX, TempButton);
        ControllerAssingSpriteStandard(vKey, KeyCode.Joystick1Button3, SpriteStandardY, TempButton);
    }

    public void ControllerAssingSpriteStringStandard(string KeyName, string Keystring, Button ButtonKey, Sprite SpriteKey)
    {
        if (KeyName == Keystring)
        {
            ButtonKey.GetComponent<Image>().sprite = SpriteKey;
            ButtonKey.GetComponentInChildren<Text>().text = "";
        }
    }

    public void ControllerAssignAllSpriteButton(string KeyName, Sprite SpriteStandard)
    {
        ControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyUp.name.ToString()), KeyUp, SpriteStandard);
        ControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyDown.name.ToString()), KeyDown, SpriteStandard);
        ControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyLeft.name.ToString()), KeyLeft, SpriteStandard);
        ControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyRight.name.ToString()), KeyRight, SpriteStandard);
        ControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyDash.name.ToString()), KeyDash, SpriteStandard);
        ControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyPossession.name.ToString()), KeyPossession, SpriteStandard);
        ControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyLightAttack.name.ToString()), KeyLightAttack, SpriteStandard);
        ControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeySpecialAttack.name.ToString()), KeySpecialAttack, SpriteStandard);
        ControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyHeavyAttack.name.ToString()), KeyHeavyAttack, SpriteStandard);
    }

    public void ControllerAssignSpriteStringContainer()
    {
        ControllerAssignAllSpriteButton("Joystick1Button0", SpriteStandardA);
        ControllerAssignAllSpriteButton("Joystick1Button1", SpriteStandardB);
        ControllerAssignAllSpriteButton("Joystick1Button2", SpriteStandardX);
        ControllerAssignAllSpriteButton("Joystick1Button3", SpriteStandardY);
    }
    #endregion
}