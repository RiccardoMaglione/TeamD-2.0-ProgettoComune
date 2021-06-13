using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyVar : MonoBehaviour
{
    /*[HideInInspector]*/ public string StringKeyUp;
    /*[HideInInspector]*/ public string StringKeyDown;
    /*[HideInInspector]*/ public string StringKeyLeft;
    /*[HideInInspector]*/ public string StringKeyRight;
    /*[HideInInspector]*/ public string StringKeyDash;
    /*[HideInInspector]*/ public string StringKeyPossession;
    /*[HideInInspector]*/ public string StringKeyLightAttack;
    /*[HideInInspector]*/ public string StringKeyHeavyAttack;
    /*[HideInInspector]*/ public string StringKeySpecialAttack;

    public Button KeyUp;
    public Button KeyDown;
    public Button KeyLeft;
    public Button KeyRight;
    public Button KeyDash;
    public Button KeyPossession;
    public Button KeyLightAttack;
    public Button KeyHeavyAttack;
    public Button KeySpecialAttack;

    /// <summary>
    /// Funzione generalizzata che assegna a una variabile la stringa di testo corrispondente del pulsante
    /// </summary>
    /// <param name="KeyString"></param>
    /// <param name="KeyButton"></param>
    /// <returns></returns>
    public string AssignString(string KeyString, Button KeyButton)
    {
        if(KeyString == null)
        {
            return KeyString = KeyButton.GetComponentInChildren<Text>().text.ToString();
        }
        else
        {
            return KeyString = PlayerPrefs.GetString(KeyButton.name.ToString());
        }
    }

    /// <summary>
    /// Metodo contenitore di tutte le assegnazioni di AssignString
    /// </summary>
    public void AssignStringContainer()
    {
        StringKeyUp = AssignString(StringKeyUp, KeyUp);
        StringKeyDown = AssignString(StringKeyDown, KeyDown);
        StringKeyLeft = AssignString(StringKeyLeft, KeyLeft);
        StringKeyRight = AssignString(StringKeyRight, KeyRight);
        StringKeyDash = AssignString(StringKeyDash, KeyDash);
        StringKeyPossession = AssignString(StringKeyPossession, KeyPossession);
        StringKeyLightAttack = AssignString(StringKeyLightAttack, KeyLightAttack);
        StringKeyHeavyAttack = AssignString(StringKeyHeavyAttack, KeyHeavyAttack);
        StringKeySpecialAttack = AssignString(StringKeySpecialAttack, KeySpecialAttack);
    }

    public void GetStringKeyPrefs()
    {
        StringKeyUp = PlayerPrefs.GetString(KeyUp.name.ToString());
        StringKeyDown = PlayerPrefs.GetString(KeyDown.name.ToString());
        StringKeyLeft = PlayerPrefs.GetString(KeyLeft.name.ToString());
        StringKeyRight = PlayerPrefs.GetString(KeyRight.name.ToString());
        StringKeyDash = PlayerPrefs.GetString(KeyDash.name.ToString());
        StringKeyPossession = PlayerPrefs.GetString(KeyPossession.name.ToString());
        StringKeyLightAttack = PlayerPrefs.GetString(KeyLightAttack.name.ToString());
        StringKeyHeavyAttack = PlayerPrefs.GetString(KeyHeavyAttack.name.ToString());
        StringKeySpecialAttack = PlayerPrefs.GetString(KeySpecialAttack.name.ToString());
    }
    
    public void AssignButton(Button KeyButton, string KeyString)
    {
        KeyButton.GetComponentInChildren<Text>().text = KeyString;
    }
    public void AssignButtonContainer()
    {
        AssignButton(KeyUp, StringKeyUp);
        AssignButton(KeyDown, StringKeyDown);
        AssignButton(KeyLeft, StringKeyLeft);
        AssignButton(KeyRight, StringKeyRight);
        AssignButton(KeyDash, StringKeyDash);
        AssignButton(KeyPossession, StringKeyPossession);
        AssignButton(KeyLightAttack, StringKeyLightAttack);
        AssignButton(KeyHeavyAttack, StringKeyHeavyAttack);
        AssignButton(KeySpecialAttack, StringKeySpecialAttack);
    }
}
