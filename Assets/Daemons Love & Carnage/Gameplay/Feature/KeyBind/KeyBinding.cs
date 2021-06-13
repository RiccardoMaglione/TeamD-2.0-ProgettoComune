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

    private void Awake()
    {
        GetStringKeyPrefs();

        KeyBindInstance = this;

        KeyBindSet = SetKeyBind;
        SetListener = ListenerOnClik;

        SetAddListener();
    }
    private void Update()
    {
        ButtonKeyListener();
        AssignStringContainer();
    }

    public void ListenerOnClik(Button ButtonKey)
    {
        ActivateGetKey = true;
        KeyText = ButtonKey.GetComponentInChildren<Text>();
        TempButton = ButtonKey;
        KeyText.text = "None";
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
        if (ActivateGetKey == true)
        {
            foreach (KeyCode vKey in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vKey))
                {
                    ActivateGetKey = false;
                    KeyText.text = vKey.ToString();
                    PlayerPrefs.SetString(TempButton.name.ToString(), KeyText.text);
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
}