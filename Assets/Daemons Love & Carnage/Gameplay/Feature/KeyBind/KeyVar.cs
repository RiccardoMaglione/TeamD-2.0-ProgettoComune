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

    /*[HideInInspector]*/ public string ControllerStringKeyUp;
    /*[HideInInspector]*/ public string ControllerStringKeyDown;
    /*[HideInInspector]*/ public string ControllerStringKeyLeft;
    /*[HideInInspector]*/ public string ControllerStringKeyRight;
    /*[HideInInspector]*/ public string ControllerStringKeyDash;
    /*[HideInInspector]*/ public string ControllerStringKeyPossession;
    /*[HideInInspector]*/ public string ControllerStringKeyLightAttack;
    /*[HideInInspector]*/ public string ControllerStringKeyHeavyAttack;
    /*[HideInInspector]*/ public string ControllerStringKeySpecialAttack;

    ///*[HideInInspector]*/ public string PlaystationControllerStringKeyUp;
    ///*[HideInInspector]*/ public string PlaystationControllerStringKeyDown;
    ///*[HideInInspector]*/ public string PlaystationControllerStringKeyLeft;
    ///*[HideInInspector]*/ public string PlaystationControllerStringKeyRight;
    ///*[HideInInspector]*/ public string PlaystationControllerStringKeyDash;
    ///*[HideInInspector]*/ public string PlaystationControllerStringKeyPossession;
    ///*[HideInInspector]*/ public string PlaystationControllerStringKeyLightAttack;
    ///*[HideInInspector]*/ public string PlaystationControllerStringKeyHeavyAttack;
    ///*[HideInInspector]*/ public string PlaystationControllerStringKeySpecialAttack;

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

    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    #region Controller
    /// <summary>
    /// Funzione generalizzata che assegna a una variabile la stringa di testo corrispondente del pulsante
    /// </summary>
    /// <param name="KeyString"></param>
    /// <param name="KeyButton"></param>
    /// <returns></returns>
    public string ControllerAssignString(string ControllerKeyString, Button KeyButton)
    {
        if (ControllerKeyString == null)
        {
            return ControllerKeyString = KeyButton.GetComponentInChildren<Text>().text.ToString();
        }
        else
        {
            return ControllerKeyString = PlayerPrefs.GetString(("Controller" + KeyButton.name.ToString()));
        }
    }

    /// <summary>
    /// Metodo contenitore di tutte le assegnazioni di AssignString
    /// </summary>
    public void ControllerAssignStringContainer()
    {
        ControllerStringKeyUp = ControllerAssignString(ControllerStringKeyUp, KeyUp);
        ControllerStringKeyDown = ControllerAssignString(ControllerStringKeyDown, KeyDown);
        ControllerStringKeyLeft = ControllerAssignString(ControllerStringKeyLeft, KeyLeft);
        ControllerStringKeyRight = ControllerAssignString(ControllerStringKeyRight, KeyRight);
        ControllerStringKeyDash = ControllerAssignString(ControllerStringKeyDash, KeyDash);
        ControllerStringKeyPossession = ControllerAssignString(ControllerStringKeyPossession, KeyPossession);
        ControllerStringKeyLightAttack = ControllerAssignString(ControllerStringKeyLightAttack, KeyLightAttack);
        ControllerStringKeyHeavyAttack = ControllerAssignString(ControllerStringKeyHeavyAttack, KeyHeavyAttack);
        ControllerStringKeySpecialAttack = ControllerAssignString(ControllerStringKeySpecialAttack, KeySpecialAttack);
    }

    public void ControllerGetStringKeyPrefs()
    {
        ControllerStringKeyUp = PlayerPrefs.GetString(("Controller" + KeyUp.name.ToString()));
        ControllerStringKeyDown = PlayerPrefs.GetString(("Controller" + KeyDown.name.ToString()));
        ControllerStringKeyLeft = PlayerPrefs.GetString(("Controller" + KeyLeft.name.ToString()));
        ControllerStringKeyRight = PlayerPrefs.GetString(("Controller" + KeyRight.name.ToString()));
        ControllerStringKeyDash = PlayerPrefs.GetString(("Controller" + KeyDash.name.ToString()));
        ControllerStringKeyPossession = PlayerPrefs.GetString(("Controller" + KeyPossession.name.ToString()));
        ControllerStringKeyLightAttack = PlayerPrefs.GetString(("Controller" + KeyLightAttack.name.ToString()));
        ControllerStringKeyHeavyAttack = PlayerPrefs.GetString(("Controller" + KeyHeavyAttack.name.ToString()));
        ControllerStringKeySpecialAttack = PlayerPrefs.GetString(("Controller" + KeySpecialAttack.name.ToString()));
    }

    public void ControllerAssignButton(Button KeyButton, string ControllerKeyString)
    {
        KeyButton.GetComponentInChildren<Text>().text = ControllerKeyString;
    }
    public void ControllerAssignButtonContainer()
    {
        ControllerAssignButton(KeyUp, ControllerStringKeyUp);
        ControllerAssignButton(KeyDown, ControllerStringKeyDown);
        ControllerAssignButton(KeyLeft, ControllerStringKeyLeft);
        ControllerAssignButton(KeyRight, ControllerStringKeyRight);
        ControllerAssignButton(KeyDash, ControllerStringKeyDash);
        ControllerAssignButton(KeyPossession, ControllerStringKeyPossession);
        ControllerAssignButton(KeyLightAttack, ControllerStringKeyLightAttack);
        ControllerAssignButton(KeyHeavyAttack, ControllerStringKeyHeavyAttack);
        ControllerAssignButton(KeySpecialAttack, ControllerStringKeySpecialAttack);
    }
    #endregion

    #region Playstation Controller
    /// <summary>
    /// Funzione generalizzata che assegna a una variabile la stringa di testo corrispondente del pulsante
    /// </summary>
    /// <param name="KeyString"></param>
    /// <param name="KeyButton"></param>
    /// <returns></returns>
    public string PlaystationControllerAssignString(string PlaystationControllerKeyString, Button KeyButton)
    {
        if (PlaystationControllerKeyString == null)
        {
            return PlaystationControllerKeyString = KeyButton.GetComponentInChildren<Text>().text.ToString();
        }
        else
        {
            return PlaystationControllerKeyString = PlayerPrefs.GetString(("PlaystationController" + KeyButton.name.ToString()));
        }
    }

    /// <summary>
    /// Metodo contenitore di tutte le assegnazioni di AssignString
    /// </summary>
    //public void PlaystationControllerAssignStringContainer()
    //{
    //    PlaystationControllerStringKeyUp = PlaystationControllerAssignString(PlaystationControllerStringKeyUp, KeyUp);
    //    PlaystationControllerStringKeyDown = PlaystationControllerAssignString(PlaystationControllerStringKeyDown, KeyDown);
    //    PlaystationControllerStringKeyLeft = PlaystationControllerAssignString(PlaystationControllerStringKeyLeft, KeyLeft);
    //    PlaystationControllerStringKeyRight = PlaystationControllerAssignString(PlaystationControllerStringKeyRight, KeyRight);
    //    PlaystationControllerStringKeyDash = PlaystationControllerAssignString(PlaystationControllerStringKeyDash, KeyDash);
    //    PlaystationControllerStringKeyPossession = PlaystationControllerAssignString(PlaystationControllerStringKeyPossession, KeyPossession);
    //    PlaystationControllerStringKeyLightAttack = PlaystationControllerAssignString(PlaystationControllerStringKeyLightAttack, KeyLightAttack);
    //    PlaystationControllerStringKeyHeavyAttack = PlaystationControllerAssignString(PlaystationControllerStringKeyHeavyAttack, KeyHeavyAttack);
    //    PlaystationControllerStringKeySpecialAttack = PlaystationControllerAssignString(PlaystationControllerStringKeySpecialAttack, KeySpecialAttack);
    //}
    //
    //public void PlaystationControllerGetStringKeyPrefs()
    //{
    //    PlaystationControllerStringKeyUp = PlayerPrefs.GetString(("PlaystationController" + KeyUp.name.ToString()));
    //    PlaystationControllerStringKeyDown = PlayerPrefs.GetString(("PlaystationController" + KeyDown.name.ToString()));
    //    PlaystationControllerStringKeyLeft = PlayerPrefs.GetString(("PlaystationController" + KeyLeft.name.ToString()));
    //    PlaystationControllerStringKeyRight = PlayerPrefs.GetString(("PlaystationController" + KeyRight.name.ToString()));
    //    PlaystationControllerStringKeyDash = PlayerPrefs.GetString(("PlaystationController" + KeyDash.name.ToString()));
    //    PlaystationControllerStringKeyPossession = PlayerPrefs.GetString(("PlaystationController" + KeyPossession.name.ToString()));
    //    PlaystationControllerStringKeyLightAttack = PlayerPrefs.GetString(("PlaystationController" + KeyLightAttack.name.ToString()));
    //    PlaystationControllerStringKeyHeavyAttack = PlayerPrefs.GetString(("PlaystationController" + KeyHeavyAttack.name.ToString()));
    //    PlaystationControllerStringKeySpecialAttack = PlayerPrefs.GetString(("PlaystationController" + KeySpecialAttack.name.ToString()));
    //}
    //
    //public void PlaystationControllerAssignButton(Button KeyButton, string ControllerKeyString)
    //{
    //    KeyButton.GetComponentInChildren<Text>().text = ControllerKeyString;
    //}
    //public void PlaystationControllerAssignButtonContainer()
    //{
    //    PlaystationControllerAssignButton(KeyUp, PlaystationControllerStringKeyUp);
    //    PlaystationControllerAssignButton(KeyDown, PlaystationControllerStringKeyDown);
    //    PlaystationControllerAssignButton(KeyLeft, PlaystationControllerStringKeyLeft);
    //    PlaystationControllerAssignButton(KeyRight, PlaystationControllerStringKeyRight);
    //    PlaystationControllerAssignButton(KeyDash, PlaystationControllerStringKeyDash);
    //    PlaystationControllerAssignButton(KeyPossession, PlaystationControllerStringKeyPossession);
    //    PlaystationControllerAssignButton(KeyLightAttack, PlaystationControllerStringKeyLightAttack);
    //    PlaystationControllerAssignButton(KeyHeavyAttack, PlaystationControllerStringKeyHeavyAttack);
    //    PlaystationControllerAssignButton(KeySpecialAttack, PlaystationControllerStringKeySpecialAttack);
    //}
    #endregion
}
