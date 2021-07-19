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
        //PlayerPrefs.DeleteKey(KeyUp.name.ToString());
        //PlayerPrefs.DeleteKey(KeyDown.name.ToString());
        //PlayerPrefs.DeleteKey(KeyLeft.name.ToString());
        //PlayerPrefs.DeleteKey(KeyRight.name.ToString());
        //PlayerPrefs.DeleteKey(KeyDash.name.ToString());
        //PlayerPrefs.DeleteKey(KeyPossession.name.ToString());
        //PlayerPrefs.DeleteKey(KeyLightAttack.name.ToString());
        //PlayerPrefs.DeleteKey(KeyHeavyAttack.name.ToString());
        //PlayerPrefs.DeleteKey(KeySpecialAttack.name.ToString());

        StringKeyUp = PlayerPrefs.GetString(KeyUp.name.ToString(),"UpArrow");
        StringKeyDown = PlayerPrefs.GetString(KeyDown.name.ToString(), "DownArrow");
        StringKeyLeft = PlayerPrefs.GetString(KeyLeft.name.ToString(), "LeftArrow");
        StringKeyRight = PlayerPrefs.GetString(KeyRight.name.ToString(), "RightArrow");
        StringKeyDash = PlayerPrefs.GetString(KeyDash.name.ToString(), "LeftControl");
        StringKeyPossession = PlayerPrefs.GetString(KeyPossession.name.ToString(), "Space");
        StringKeyLightAttack = PlayerPrefs.GetString(KeyLightAttack.name.ToString(), "Z");
        StringKeyHeavyAttack = PlayerPrefs.GetString(KeyHeavyAttack.name.ToString(), "X");
        StringKeySpecialAttack = PlayerPrefs.GetString(KeySpecialAttack.name.ToString(), "C");

        PlayerPrefs.SetString(KeyUp.name.ToString(), StringKeyUp);
        PlayerPrefs.SetString(KeyDown.name.ToString(), StringKeyDown);
        PlayerPrefs.SetString(KeyLeft.name.ToString(), StringKeyLeft);
        PlayerPrefs.SetString(KeyRight.name.ToString(), StringKeyRight);
        PlayerPrefs.SetString(KeyDash.name.ToString(), StringKeyDash);
        PlayerPrefs.SetString(KeyPossession.name.ToString(), StringKeyPossession);
        PlayerPrefs.SetString(KeyLightAttack.name.ToString(), StringKeyLightAttack);
        PlayerPrefs.SetString(KeyHeavyAttack.name.ToString(), StringKeyHeavyAttack);
        PlayerPrefs.SetString(KeySpecialAttack.name.ToString(), StringKeySpecialAttack);
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
        //PlayerPrefs.DeleteKey("Controller" + KeyUp.name.ToString());
        //PlayerPrefs.DeleteKey("Controller" + KeyDown.name.ToString());
        //PlayerPrefs.DeleteKey("Controller" + KeyLeft.name.ToString());
        //PlayerPrefs.DeleteKey("Controller" + KeyRight.name.ToString());
        //PlayerPrefs.DeleteKey("Controller" + KeyDash.name.ToString());
        //PlayerPrefs.DeleteKey("Controller" + KeyPossession.name.ToString());
        //PlayerPrefs.DeleteKey("Controller" + KeyLightAttack.name.ToString());
        //PlayerPrefs.DeleteKey("Controller" + KeyHeavyAttack.name.ToString());
        //PlayerPrefs.DeleteKey("Controller" + KeySpecialAttack.name.ToString());


        ControllerStringKeyUp = PlayerPrefs.GetString(("Controller" + KeyUp.name.ToString()), "Joystick1Button0");
        ControllerStringKeyDown = PlayerPrefs.GetString(("Controller" + KeyDown.name.ToString()), "Left Down Joystick");
        ControllerStringKeyLeft = PlayerPrefs.GetString(("Controller" + KeyLeft.name.ToString()), "Left Left Joystick");
        ControllerStringKeyRight = PlayerPrefs.GetString(("Controller" + KeyRight.name.ToString()), "Left Right Joystick");
        ControllerStringKeyDash = PlayerPrefs.GetString(("Controller" + KeyDash.name.ToString()), "Joystick1Button4");
        ControllerStringKeyPossession = PlayerPrefs.GetString(("Controller" + KeyPossession.name.ToString()), "Joystick1Button5");
        ControllerStringKeyLightAttack = PlayerPrefs.GetString(("Controller" + KeyLightAttack.name.ToString()), "Joystick1Button2");
        ControllerStringKeyHeavyAttack = PlayerPrefs.GetString(("Controller" + KeyHeavyAttack.name.ToString()), "Joystick1Button1");
        ControllerStringKeySpecialAttack = PlayerPrefs.GetString(("Controller" + KeySpecialAttack.name.ToString()), "Joystick1Button3");

        //Debug.LogError(ControllerStringKeyUp);
        //Debug.LogError(ControllerStringKeyDown);
        //Debug.LogError(ControllerStringKeyLeft);
        //Debug.LogError(ControllerStringKeyRight);
        //Debug.LogError(ControllerStringKeyDash);
        //Debug.LogError(ControllerStringKeyPossession);
        //Debug.LogError(ControllerStringKeyLightAttack);
        //Debug.LogError(ControllerStringKeyHeavyAttack);
        //Debug.LogError(ControllerStringKeySpecialAttack);

        PlayerPrefs.SetString("Controller" + KeyUp.name.ToString(), ControllerStringKeyUp);
        PlayerPrefs.SetString("Controller" + KeyDown.name.ToString(), ControllerStringKeyDown);
        PlayerPrefs.SetString("Controller" + KeyLeft.name.ToString(), ControllerStringKeyLeft);
        PlayerPrefs.SetString("Controller" + KeyRight.name.ToString(), ControllerStringKeyRight);
        PlayerPrefs.SetString("Controller" + KeyDash.name.ToString(), ControllerStringKeyDash);
        PlayerPrefs.SetString("Controller" + KeyPossession.name.ToString(), ControllerStringKeyPossession);
        PlayerPrefs.SetString("Controller" + KeyLightAttack.name.ToString(), ControllerStringKeyLightAttack);
        PlayerPrefs.SetString("Controller" + KeyHeavyAttack.name.ToString(), ControllerStringKeyHeavyAttack);
        PlayerPrefs.SetString("Controller" + KeySpecialAttack.name.ToString(), ControllerStringKeySpecialAttack);

        //Debug.LogError("1. "+ControllerStringKeyUp);
        //Debug.LogError("1. "+ControllerStringKeyDown);
        //Debug.LogError("1. "+ControllerStringKeyLeft);
        //Debug.LogError("1. "+ControllerStringKeyRight);
        //Debug.LogError("1. "+ControllerStringKeyDash);
        //Debug.LogError("1. "+ControllerStringKeyPossession);
        //Debug.LogError("1. "+ControllerStringKeyLightAttack);
        //Debug.LogError("1. "+ControllerStringKeyHeavyAttack);
        //Debug.LogError("1. "+ControllerStringKeySpecialAttack);
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
