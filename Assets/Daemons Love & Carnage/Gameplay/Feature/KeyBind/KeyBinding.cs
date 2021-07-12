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
    public Sprite SpriteStandardRB;
    public Sprite SpriteStandardLB;
    public Sprite SpriteStandardLeftLeftJoystick;
    public Sprite SpriteStandardLeftRightJoystick;
    public Sprite SpriteStandardLeftDownJoystick;

    public Sprite SpriteStandardPSSquare;
    public Sprite SpriteStandardPSX;
    public Sprite SpriteStandardPSCircle;
    public Sprite SpriteStandardPSTriangle;
    public Sprite SpriteStandardR1;
    public Sprite SpriteStandardL1;
    public Sprite SpriteStandardLeftLeftJoystickPlaystation;
    public Sprite SpriteStandardLeftRightJoystickPlaystation;
    public Sprite SpriteStandardLeftDownJoystickPlaystation;

    private void Awake()
    {
        GetStringKeyPrefs();
        AssignButtonContainer();
        AssignSpriteStringContainer();

        ControllerGetStringKeyPrefs();
        //PlaystationControllerGetStringKeyPrefs();
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
            AssignButtonContainer();
            AssignSpriteStringContainer();
        }
        else if (CheckInput.Controller == true)
        {
            if (CheckInput.XboxController == true)
            {
                ControllerAssignSpriteStringContainer();
                AxisControllerAssignSpriteStringContainer();
            }
            else if(CheckInput.PlaystationController == true)
            {
                PlaystationControllerAssignSpriteStringContainer();
                AxisPlaystationControllerAssignSpriteStringContainer();
            }
        }
        
        GetKeyUp();

        //Debug.LogError("2. " + ControllerStringKeyUp);
        //Debug.LogError("2. " + ControllerStringKeyDown);
        //Debug.LogError("2. " + ControllerStringKeyLeft);
        //Debug.LogError("2. " + ControllerStringKeyRight);
        //Debug.LogError("2. " + ControllerStringKeyDash);
        //Debug.LogError("2. " + ControllerStringKeyPossession);
        //Debug.LogError("2. " + ControllerStringKeyLightAttack);
        //Debug.LogError("2. " + ControllerStringKeyHeavyAttack);
        //Debug.LogError("2. " + ControllerStringKeySpecialAttack);
    }

    public void ListenerOnClik(Button ButtonKey)
    {
        if (CheckInput.PlaystationController == true /*&& Input.GetKeyDown(KeyCode.Joystick1Button1)*/)
        {
            ActivateGetKey = true;
            KeyText = ButtonKey.GetComponentInChildren<Text>();
            TempButton = ButtonKey;
            //TempButton.GetComponent<Image>().sprite = SpriteEmpty;
            PlayerPrefs.SetString(TempButton.name.ToString(), "");
            KeyText.text = "";
        }
        else if(CheckInput.PlaystationController == false)
        {
            ActivateGetKey = true;
            KeyText = ButtonKey.GetComponentInChildren<Text>();
            TempButton = ButtonKey;
            PlayerPrefs.SetString(TempButton.name.ToString(), "");
            //TempButton.GetComponent<Image>().sprite = SpriteEmpty;
            KeyText.text = "";
        }
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
                else if (Input.GetKey(vKey) && CheckInput.Controller == true/* && CheckInput.XboxController == true*/)
                {
                    ActivateGetKey = false;
                    ActivateCondition = false;
                    KeyText.text = vKey.ToString();
                    PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                    TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                    ControllerAssignSpriteStandardContainer(vKey);
                }
                //else if (Input.GetKey(vKey) && CheckInput.Controller == true && CheckInput.PlaystationController == true)
                //{
                //    ActivateGetKey = false;
                //    ActivateCondition = false;
                //    KeyText.text = vKey.ToString();
                //    PlayerPrefs.SetString(("PlaystationController" + TempButton.name.ToString()), KeyText.text);
                //    TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                //    PlaystationControllerAssignSpriteStandardContainer(vKey);
                //}
            }
            #region Axis xbox
            if (Input.GetAxisRaw("Horizontal") < -0.5f && CheckInput.Controller == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Left Left Joystick";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);
            }
            if (Input.GetAxisRaw("Horizontal") > 0.5f && CheckInput.Controller == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Left right Joystick";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);
            }
            if (Input.GetAxisRaw("Vertical") < -0.5f && CheckInput.Controller == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Left Down Joystick";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f && CheckInput.Controller == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Left Up";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);
            }

            if (Input.GetAxisRaw("DPad X") > 0.5f && CheckInput.Controller == true && CheckInput.XboxController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "DPad Left";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                //ControllerAssignSpriteStandardContainer(vKey);
            }
            if (Input.GetAxisRaw("DPad X") < -0.5f && CheckInput.Controller == true && CheckInput.XboxController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "DPad right";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                //ControllerAssignSpriteStandardContainer(vKey);
            }
            if (Input.GetAxisRaw("DPad Y") > 0.5f && CheckInput.Controller == true && CheckInput.XboxController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "DPad Down";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                //ControllerAssignSpriteStandardContainer(vKey);
            }
            if (Input.GetAxisRaw("DPad Y") < -0.5f && CheckInput.Controller == true && CheckInput.XboxController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "DPad Up";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                //ControllerAssignSpriteStandardContainer(vKey);
            }
            if (Input.GetAxisRaw("Left Trigger") > 0.5f && CheckInput.Controller == true && CheckInput.XboxController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Left Trigger";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                //ControllerAssignSpriteStandardContainer(vKey);
            }
            if (Input.GetAxisRaw("Right Trigger") > 0.5f && CheckInput.Controller == true && CheckInput.XboxController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Right Trigger";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                //ControllerAssignSpriteStandardContainer(vKey);
            }
            if (Input.GetAxisRaw("Right Stick X Axis") < -0.5f && CheckInput.Controller == true && CheckInput.XboxController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Left HRJ";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                //ControllerAssignSpriteStandardContainer(vKey);
            }
            if (Input.GetAxisRaw("Right Stick X Axis") > 0.5f && CheckInput.Controller == true && CheckInput.XboxController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Right HRJ";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                //ControllerAssignSpriteStandardContainer(vKey);
            }
            if (Input.GetAxisRaw("Right Stick Y Axis") < -0.5f && CheckInput.Controller == true && CheckInput.XboxController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Up VRJ";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                //ControllerAssignSpriteStandardContainer(vKey);
            }
            if (Input.GetAxisRaw("Right Stick Y Axis") > 0.5f && CheckInput.Controller == true && CheckInput.XboxController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Down VRJ";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                //ControllerAssignSpriteStandardContainer(vKey);
            }
            #endregion

            #region Axis Playstation
            if (Input.GetAxisRaw("PS DPad X") > 0.5f && CheckInput.Controller == true && CheckInput.PlaystationController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "PS DPad Left";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);
            }                    //7
            if (Input.GetAxisRaw("PS DPad X") < -0.5f && CheckInput.Controller == true && CheckInput.PlaystationController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "PS DPad right";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);
            }                   //7
            if (Input.GetAxisRaw("PS DPad Y") > 0.5f && CheckInput.Controller == true && CheckInput.PlaystationController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "PS DPad Down";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);
            }                    //8
            if (Input.GetAxisRaw("PS DPad Y") < -0.5f && CheckInput.Controller == true && CheckInput.PlaystationController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "PS DPad Up";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);
            }                   //8
            if (Input.GetAxisRaw("PS Right Stick X Axis") < -0.5f && CheckInput.Controller == true && CheckInput.PlaystationController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "PS Left HRJ";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);
            }       //3
            if (Input.GetAxisRaw("PS Right Stick X Axis") > 0.5f && CheckInput.Controller == true && CheckInput.PlaystationController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "PS Right HRJ";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);
            }        //3
            if (Input.GetAxisRaw("PS Right Stick Y Axis") < -0.5f && CheckInput.Controller == true && CheckInput.PlaystationController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "PS Up VRJ";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);
            }       //6
            if (Input.GetAxisRaw("PS Right Stick Y Axis") > 0.5f && CheckInput.Controller == true && CheckInput.PlaystationController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "PS Down VRJ";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);
            }        //6
            #endregion
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

        KeyUp.GetComponent<Image>().sprite = SpriteEmpty;
        KeyDown.GetComponent<Image>().sprite = SpriteEmpty;
        KeyLeft.GetComponent<Image>().sprite = SpriteEmpty;
        KeyRight.GetComponent<Image>().sprite = SpriteEmpty;
        KeyDash.GetComponent<Image>().sprite = SpriteEmpty;
        KeyPossession.GetComponent<Image>().sprite = SpriteEmpty;
        KeyLightAttack.GetComponent<Image>().sprite = SpriteEmpty;
        KeyHeavyAttack.GetComponent<Image>().sprite = SpriteEmpty;
        KeySpecialAttack.GetComponent<Image>().sprite = SpriteEmpty;


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
        AssignAllSpriteButton("", SpriteEmpty);
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

        ControllerAssingSpriteStandard(vKey, KeyCode.Joystick1Button4, SpriteStandardLB, TempButton);
        ControllerAssingSpriteStandard(vKey, KeyCode.Joystick1Button5, SpriteStandardRB, TempButton);
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
        ControllerAssignAllSpriteButton("Joystick1Button4", SpriteStandardLB);
        ControllerAssignAllSpriteButton("Joystick1Button5", SpriteStandardRB);

        //ControllerAssignAllSpriteButton("Horizontal", SpriteStandardLeftLeftJoystick);
        //ControllerAssignAllSpriteButton("Horizontal", SpriteStandardLeftRightJoystick);
        //ControllerAssignAllSpriteButton("Vertical", SpriteStandardLeftDownJoystick);
    }

    public void AxisControllerAssingSpriteStandard(string Axis, string StandardAxis, Sprite SpriteKey, Button ButtonKey)
    {
        if (Axis == StandardAxis && SpriteKey != null)
        {
            ButtonKey.GetComponent<Image>().sprite = SpriteKey;
            KeyText.text = "";
        }
    }
    public void ControllerAssignSpriteStandardContainer(string Axis)
    {
        AxisControllerAssingSpriteStandard(Axis, "Left Left Joystick", SpriteStandardA, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "Left right Joystick", SpriteStandardB, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "Left Down Joystick", SpriteStandardX, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "Left Up", SpriteStandardY, TempButton);

        //AxisControllerAssingSpriteStandard(Axis, "", SpriteStandardLB, TempButton);
        //AxisControllerAssingSpriteStandard(Axis, "", SpriteStandardRB, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "PS DPad Left", SpriteStandardA, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "PS DPad right", SpriteStandardB, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "PS DPad Down", SpriteStandardX, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "PS DPad Up", SpriteStandardY, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "PS Left HRJ", SpriteStandardA, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "PS Right HRJ", SpriteStandardB, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "PS Up VRJ", SpriteStandardX, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "PS Down VRJ", SpriteStandardY, TempButton);
    }

    public void AxisControllerAssingSpriteStringStandard(string KeyName, string Keystring, Button ButtonKey, Sprite SpriteKey)
    {
        if (KeyName == Keystring)
        {
            ButtonKey.GetComponent<Image>().sprite = SpriteKey;
            ButtonKey.GetComponentInChildren<Text>().text = "";
        }
    }

    public void AxisControllerAssignAllSpriteButton(string KeyName, Sprite SpriteStandard)
    {
        AxisControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyUp.name.ToString()), KeyUp, SpriteStandard);
        AxisControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyDown.name.ToString()), KeyDown, SpriteStandard);
        AxisControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyLeft.name.ToString()), KeyLeft, SpriteStandard);
        AxisControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyRight.name.ToString()), KeyRight, SpriteStandard);
        AxisControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyDash.name.ToString()), KeyDash, SpriteStandard);
        AxisControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyPossession.name.ToString()), KeyPossession, SpriteStandard);
        AxisControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyLightAttack.name.ToString()), KeyLightAttack, SpriteStandard);
        AxisControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeySpecialAttack.name.ToString()), KeySpecialAttack, SpriteStandard);
        AxisControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyHeavyAttack.name.ToString()), KeyHeavyAttack, SpriteStandard);
    }

    public void AxisControllerAssignSpriteStringContainer()
    {
        AxisControllerAssignAllSpriteButton("Left Left Joystick", SpriteStandardA);
        AxisControllerAssignAllSpriteButton("Left right Joystick", SpriteStandardB);
        AxisControllerAssignAllSpriteButton("Left Down Joystick", SpriteStandardX);
        AxisControllerAssignAllSpriteButton("Left Up", SpriteStandardY);
    }
    #endregion

    #region Playstation Controller
    //public void PlaystationControllerAssingSpriteStandard(KeyCode vKey, KeyCode StandardKeyCode, Sprite SpriteKey, Button ButtonKey)
    //{
    //    if (vKey == StandardKeyCode && SpriteKey != null)
    //    {
    //        ButtonKey.GetComponent<Image>().sprite = SpriteKey;
    //        KeyText.text = "";
    //    }
    //}
    //
    //public void PlaystationControllerAssignSpriteStandardContainer(KeyCode vKey)
    //{
    //    PlaystationControllerAssingSpriteStandard(vKey, KeyCode.Joystick1Button0, SpriteStandardPSSquare, TempButton);
    //    PlaystationControllerAssingSpriteStandard(vKey, KeyCode.Joystick1Button1, SpriteStandardPSX, TempButton);
    //    PlaystationControllerAssingSpriteStandard(vKey, KeyCode.Joystick1Button2, SpriteStandardPSCircle, TempButton);
    //    PlaystationControllerAssingSpriteStandard(vKey, KeyCode.Joystick1Button3, SpriteStandardPSTriangle, TempButton);
    //}

    public void PlaystationControllerAssingSpriteStringStandard(string KeyName, string Keystring, Button ButtonKey, Sprite SpriteKey)
    {
        if (KeyName == Keystring)
        {
            ButtonKey.GetComponent<Image>().sprite = SpriteKey;
            ButtonKey.GetComponentInChildren<Text>().text = "";
        }
    }

    public void PlaystationControllerAssignAllSpriteButton(string KeyName, Sprite SpriteStandard)
    {
        PlaystationControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyUp.name.ToString()), KeyUp, SpriteStandard);
        PlaystationControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyDown.name.ToString()), KeyDown, SpriteStandard);
        PlaystationControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyLeft.name.ToString()), KeyLeft, SpriteStandard);
        PlaystationControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyRight.name.ToString()), KeyRight, SpriteStandard);
        PlaystationControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyDash.name.ToString()), KeyDash, SpriteStandard);
        PlaystationControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyPossession.name.ToString()), KeyPossession, SpriteStandard);
        PlaystationControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyLightAttack.name.ToString()), KeyLightAttack, SpriteStandard);
        PlaystationControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeySpecialAttack.name.ToString()), KeySpecialAttack, SpriteStandard);
        PlaystationControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyHeavyAttack.name.ToString()), KeyHeavyAttack, SpriteStandard);
    }

    public void PlaystationControllerAssignSpriteStringContainer()
    {
        PlaystationControllerAssignAllSpriteButton("Joystick1Button0", SpriteStandardPSSquare);
        PlaystationControllerAssignAllSpriteButton("Joystick1Button1", SpriteStandardPSX);
        PlaystationControllerAssignAllSpriteButton("Joystick1Button2", SpriteStandardPSCircle);
        PlaystationControllerAssignAllSpriteButton("Joystick1Button3", SpriteStandardPSTriangle);
        PlaystationControllerAssignAllSpriteButton("Joystick1Button4", SpriteStandardL1);
        PlaystationControllerAssignAllSpriteButton("Joystick1Button5", SpriteStandardR1);
    }



   public void AxisPlaystationControllerAssingSpriteStringStandard(string KeyName, string Keystring, Button ButtonKey, Sprite SpriteKey)
    {
        if (KeyName == Keystring)
        {
            ButtonKey.GetComponent<Image>().sprite = SpriteKey;
            ButtonKey.GetComponentInChildren<Text>().text = "";
        }
    }

    public void AxisPlaystationControllerAssignAllSpriteButton(string KeyName, Sprite SpriteStandard)
    {
        PlaystationControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyUp.name.ToString()), KeyUp, SpriteStandard);
        PlaystationControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyDown.name.ToString()), KeyDown, SpriteStandard);
        PlaystationControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyLeft.name.ToString()), KeyLeft, SpriteStandard);
        PlaystationControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyRight.name.ToString()), KeyRight, SpriteStandard);
        PlaystationControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyDash.name.ToString()), KeyDash, SpriteStandard);
        PlaystationControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyPossession.name.ToString()), KeyPossession, SpriteStandard);
        PlaystationControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyLightAttack.name.ToString()), KeyLightAttack, SpriteStandard);
        PlaystationControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeySpecialAttack.name.ToString()), KeySpecialAttack, SpriteStandard);
        PlaystationControllerAssingSpriteStringStandard(KeyName, PlayerPrefs.GetString("Controller" + KeyHeavyAttack.name.ToString()), KeyHeavyAttack, SpriteStandard);
    }

    public void AxisPlaystationControllerAssignSpriteStringContainer()
    {
        PlaystationControllerAssignAllSpriteButton("", SpriteStandardPSSquare);
        PlaystationControllerAssignAllSpriteButton("", SpriteStandardPSX);
        PlaystationControllerAssignAllSpriteButton("", SpriteStandardPSCircle);
        PlaystationControllerAssignAllSpriteButton("", SpriteStandardPSTriangle);
        PlaystationControllerAssignAllSpriteButton("", SpriteStandardL1);
        PlaystationControllerAssignAllSpriteButton("", SpriteStandardR1);
    }/**/
    #endregion
}