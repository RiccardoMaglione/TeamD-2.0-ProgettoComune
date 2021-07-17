using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class KeyBinding : KeyVar
{
    public static KeyBinding KeyBindInstance;

    public static Func<string, KeyCode> KeyBindSet;
    public static Func<string, KeyCode> KeyBindSetController;
    public static Func<string, string> KeyBindSetControllerAxis;
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
    [Header("Numbers -----------------------------------")]
    public Sprite SpriteStandardKeyZero;
    public Sprite SpriteStandardKeyOne;
    public Sprite SpriteStandardKeyTwo;
    public Sprite SpriteStandardKeyThree;
    public Sprite SpriteStandardKeyFour;
    public Sprite SpriteStandardKeyFive;
    public Sprite SpriteStandardKeySix;
    public Sprite SpriteStandardKeySeven;
    public Sprite SpriteStandardKeyEight;
    public Sprite SpriteStandardKeyNine;
    [Header("Symbols -----------------------------------")]
    //public Sprite SpriteStandardKeyApostrophe;
    //public Sprite SpriteStandardKeyMinus;
    //public Sprite SpriteStandardKeyBackslash;
    //public Sprite SpriteStandardKeyDoubleDot;
    //public Sprite SpriteStandardKeyComma;
    //public Sprite SpriteStandardKeyDot;
    //public Sprite SpriteStandardKeyDotComma;
    //public Sprite SpriteStandardKeyUnderscore;
    //public Sprite SpriteStandardKeyPlus;
    public Sprite SpriteStandardKeyAlt;
    public Sprite SpriteStandardKeyCaps;
    public Sprite SpriteStandardKeyTab;
    public Sprite SpriteStandardKeyMouseDX;
    public Sprite SpriteStandardKeyMouseWheel;

    public Sprite SpriteStandardKeyBackQuote;
    public Sprite SpriteStandardKeyBackslash;
    public Sprite SpriteStandardKeyComma;
    public Sprite SpriteStandardKeyEquals;
    public Sprite SpriteStandardKeyRightBracket;
    public Sprite SpriteStandardKeySemicolon;
    public Sprite SpriteStandardKeyLeftBracket;
    public Sprite SpriteStandardKeyMinus;
    public Sprite SpriteStandardKeyPeriod;
    public Sprite SpriteStandardKeyQuote;
    public Sprite SpriteStandardKeySlash;

    [Header("Special Alphabet -----------------------------------")]
    public Sprite SpriteStandard_à;
    public Sprite SpriteStandard_è;
    public Sprite SpriteStandard_ì;
    public Sprite SpriteStandard_ò;
    public Sprite SpriteStandard_ù;
    [Header("Alphabet -----------------------------------")]
    public Sprite SpriteStandard_A;
    public Sprite SpriteStandard_B;
    //public Sprite SpriteStandard_C;
    public Sprite SpriteStandard_D;
    public Sprite SpriteStandard_E;
    public Sprite SpriteStandard_F;
    public Sprite SpriteStandard_G;
    public Sprite SpriteStandard_H;
    public Sprite SpriteStandard_I;
    public Sprite SpriteStandard_J;
    public Sprite SpriteStandard_K;
    public Sprite SpriteStandard_L;
    public Sprite SpriteStandard_M;
    public Sprite SpriteStandard_N;
    public Sprite SpriteStandard_O;
    public Sprite SpriteStandard_P;
    public Sprite SpriteStandard_Q;
    public Sprite SpriteStandard_R;
    public Sprite SpriteStandard_S;
    public Sprite SpriteStandard_T;
    public Sprite SpriteStandard_U;
    //public Sprite SpriteStandard_V;
    public Sprite SpriteStandard_W;
    //public Sprite SpriteStandard_X;
    public Sprite SpriteStandard_Y;
    //public Sprite SpriteStandard_Z;
    [Header("-----------------------------------")]
    public Sprite SpriteEmpty;
    public bool ActivateCondition;

    [Header("Xbox -----------------------------------")]
    public Sprite SpriteStandardA;
    public Sprite SpriteStandardB;
    public Sprite SpriteStandardX;
    public Sprite SpriteStandardY;

    public Sprite SpriteStandardRB;
    public Sprite SpriteStandardLB;
    public Sprite SpriteStandardRT;
    public Sprite SpriteStandardLT;

    public Sprite SpriteStandardLeftLeftJoystick;
    public Sprite SpriteStandardLeftRightJoystick;
    public Sprite SpriteStandardLeftDownJoystick;
    public Sprite SpriteStandardLeftUpJoystick;

    public Sprite SpriteStandardRightLeftJoystick;
    public Sprite SpriteStandardRightRightJoystick;
    public Sprite SpriteStandardRightDownJoystick;
    public Sprite SpriteStandardRightUpJoystick;

    public Sprite SpriteStandardLeftClickJoystick;
    public Sprite SpriteStandardRightClickJoystick;

    public Sprite SpriteStandardDPadLeft;
    public Sprite SpriteStandardDPadRight;
    public Sprite SpriteStandardDPadDown;
    public Sprite SpriteStandardDPadUp;

    public Sprite SpriteStandardXboxShare;
    public Sprite SpriteStandardXboxStart;

    [Header("Playstation -----------------------------------")]
    public Sprite SpriteStandardPSSquare;
    public Sprite SpriteStandardPSX;
    public Sprite SpriteStandardPSCircle;
    public Sprite SpriteStandardPSTriangle;
    public Sprite SpriteStandardR1;
    public Sprite SpriteStandardL1;
    public Sprite SpriteStandardLeftLeftJoystickPlaystation;
    public Sprite SpriteStandardLeftRightJoystickPlaystation;
    public Sprite SpriteStandardLeftDownJoystickPlaystation;

    public static KeyBinding KeyBind;

    public static bool LockBack;

    private void Awake()
    {
        KeyBind = this;

        GetStringKeyPrefs();
        AssignButtonContainer();
        AssignSpriteStringContainer();

        ControllerGetStringKeyPrefs();
        //PlaystationControllerGetStringKeyPrefs();
        //ControllerAssignSpriteStringContainer();

        KeyBindInstance = this;

        KeyBindSet = SetKeyBind;
        KeyBindSetController = SetKeyBindController;
        KeyBindSetControllerAxis = SetKeyBindControllerAxis;
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
        print("Dovrebbe funzionare "+SetKeyBindControllerAxis(ControllerStringKeyLeft));//Funziona ma da il testo e non l'asse preciso
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
        if (CheckInput.Controller == true /*&& Input.GetKeyDown(KeyCode.Joystick1Button1)*/)     //Prima era CheckInput.PlaystationController == true
        {
            ActivateGetKey = true;
            KeyText = ButtonKey.GetComponentInChildren<Text>();
            TempButton = ButtonKey;
            //TempButton.GetComponent<Image>().sprite = SpriteEmpty;
            EventSystem.current.SetSelectedGameObject(TempButton.gameObject);
            PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), "");
            KeyText.text = "";
            LockBack = true;
        }
        else if(CheckInput.Controller == false)      //Prima era CheckInput.PlaystationController == false
        {
            ActivateGetKey = true;
            KeyText = ButtonKey.GetComponentInChildren<Text>();
            TempButton = ButtonKey;
            EventSystem.current.SetSelectedGameObject(TempButton.gameObject);
            PlayerPrefs.SetString(TempButton.name.ToString(), "");
            //TempButton.GetComponent<Image>().sprite = SpriteEmpty;
            KeyText.text = "";
            LockBack = true;
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
                    print("Passi qua?");
                    ActivateGetKey = false;
                    ActivateCondition = false;
                    KeyText.text = vKey.ToString();
                    PlayerPrefs.SetString(TempButton.name.ToString(), KeyText.text);
                    TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                    AssignSpriteStandardContainer(vKey);

                    StartCoroutine(ResetLockBack());
                }
                else if (Input.GetKey(vKey) && CheckInput.Controller == true/* && CheckInput.XboxController == true*/)
                {
                    ActivateGetKey = false;
                    ActivateCondition = false;
                    KeyText.text = vKey.ToString();
                    PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                    TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                    ControllerAssignSpriteStandardContainer(vKey);

                    StartCoroutine(ResetLockBack());
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

                StartCoroutine(ResetLockBack());
            }
            if (Input.GetAxisRaw("Horizontal") > 0.5f && CheckInput.Controller == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Left Right Joystick";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }
            if (Input.GetAxisRaw("Vertical") < -0.5f && CheckInput.Controller == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Left Down Joystick";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f && CheckInput.Controller == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Left Up Joystick";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }

            if (Input.GetAxisRaw("DPad X") > 0.5f && CheckInput.Controller == true && CheckInput.XboxController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "DPad Left";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }
            if (Input.GetAxisRaw("DPad X") < -0.5f && CheckInput.Controller == true && CheckInput.XboxController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "DPad Right";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }
            if (Input.GetAxisRaw("DPad Y") > 0.5f && CheckInput.Controller == true && CheckInput.XboxController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "DPad Down";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }
            if (Input.GetAxisRaw("DPad Y") < -0.5f && CheckInput.Controller == true && CheckInput.XboxController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "DPad Up";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }
            
            if (Input.GetAxisRaw("Left Trigger") > 0.5f && CheckInput.Controller == true && CheckInput.XboxController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Left Trigger";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }
            if (Input.GetAxisRaw("Right Trigger") > 0.5f && CheckInput.Controller == true && CheckInput.XboxController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Right Trigger";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }

            if (Input.GetAxisRaw("Right Stick X Axis") < -0.5f && CheckInput.Controller == true && CheckInput.XboxController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Left HRJ";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }
            if (Input.GetAxisRaw("Right Stick X Axis") > 0.5f && CheckInput.Controller == true && CheckInput.XboxController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Right HRJ";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }
            if (Input.GetAxisRaw("Right Stick Y Axis") < -0.5f && CheckInput.Controller == true && CheckInput.XboxController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Up VRJ";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);
            }
            if (Input.GetAxisRaw("Right Stick Y Axis") > 0.5f && CheckInput.Controller == true && CheckInput.XboxController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Down VRJ";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }


            #region Playstation on Big Picture Steam
            if (Input.GetAxisRaw("DPad X") > 0.5f && CheckInput.Controller == true && CheckInput.XboxController == false && CheckInput.PlaystationController == false)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "DPad Left";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }
            if (Input.GetAxisRaw("DPad X") < -0.5f && CheckInput.Controller == true && CheckInput.XboxController == false && CheckInput.PlaystationController == false)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "DPad Right";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }
            if (Input.GetAxisRaw("DPad Y") > 0.5f && CheckInput.Controller == true && CheckInput.XboxController == false && CheckInput.PlaystationController == false)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "DPad Down";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }
            if (Input.GetAxisRaw("DPad Y") < -0.5f && CheckInput.Controller == true && CheckInput.XboxController == false && CheckInput.PlaystationController == false)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "DPad Up";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }
            if (Input.GetAxisRaw("Left Trigger") > 0.5f && CheckInput.Controller == true && CheckInput.XboxController == false && CheckInput.PlaystationController == false)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Left Trigger";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }
            if (Input.GetAxisRaw("Right Trigger") > 0.5f && CheckInput.Controller == true && CheckInput.XboxController == false && CheckInput.PlaystationController == false)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Right Trigger";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }
            if (Input.GetAxisRaw("Right Stick X Axis") < -0.5f && CheckInput.Controller == true && CheckInput.XboxController == false && CheckInput.PlaystationController == false)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Left HRJ";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }
            if (Input.GetAxisRaw("Right Stick X Axis") > 0.5f && CheckInput.Controller == true && CheckInput.XboxController == false && CheckInput.PlaystationController == false)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Right HRJ";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }
            if (Input.GetAxisRaw("Right Stick Y Axis") < -0.5f && CheckInput.Controller == true && CheckInput.XboxController == false && CheckInput.PlaystationController == false)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Up VRJ";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }
            if (Input.GetAxisRaw("Right Stick Y Axis") > 0.5f && CheckInput.Controller == true && CheckInput.XboxController == false && CheckInput.PlaystationController == false)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "Down VRJ";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }
            #endregion

            //Manca il tasto start = 7
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

                StartCoroutine(ResetLockBack());
            }                    //7
            if (Input.GetAxisRaw("PS DPad X") < -0.5f && CheckInput.Controller == true && CheckInput.PlaystationController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "PS DPad right";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }                   //7
            if (Input.GetAxisRaw("PS DPad Y") > 0.5f && CheckInput.Controller == true && CheckInput.PlaystationController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "PS DPad Down";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }                    //8
            if (Input.GetAxisRaw("PS DPad Y") < -0.5f && CheckInput.Controller == true && CheckInput.PlaystationController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "PS DPad Up";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }                   //8
            if (Input.GetAxisRaw("PS Right Stick X Axis") < -0.5f && CheckInput.Controller == true && CheckInput.PlaystationController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "PS Left HRJ";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }       //3
            if (Input.GetAxisRaw("PS Right Stick X Axis") > 0.5f && CheckInput.Controller == true && CheckInput.PlaystationController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "PS Right HRJ";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }        //3
            if (Input.GetAxisRaw("PS Right Stick Y Axis") < -0.5f && CheckInput.Controller == true && CheckInput.PlaystationController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "PS Up VRJ";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }       //6
            if (Input.GetAxisRaw("PS Right Stick Y Axis") > 0.5f && CheckInput.Controller == true && CheckInput.PlaystationController == true)
            {
                ActivateGetKey = false;
                ActivateCondition = false;
                KeyText.text = "PS Down VRJ";
                PlayerPrefs.SetString(("Controller" + TempButton.name.ToString()), KeyText.text);
                TempButton.GetComponent<Image>().sprite = SpriteEmpty;
                ControllerAssignSpriteStandardContainer(KeyText.text);

                StartCoroutine(ResetLockBack());
            }        //6
            #endregion
        }
    }

    public IEnumerator ResetLockBack()
    {
        yield return new WaitForEndOfFrame();
        LockBack = false;
    }

    #region Call Function in Another Scripts
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
        if (ActivateGetKey == false && (KeyValue != "Left Left Joystick" && KeyValue != "Left Right Joystick" && KeyValue != "Left Up Joystick" && KeyValue != "Left Down Joystick" && KeyValue != "DPad Left" && KeyValue != "DPad Right" && KeyValue != "DPad Up" && KeyValue != "Left Trigger" && KeyValue != "Right Trigger" && KeyValue != "Left HRJ" && KeyValue != "Right HRJ" && KeyValue != "Up VRJ" && KeyValue != "Down VRJ" && KeyValue != "PS DPad Left" && KeyValue != "PS DPad right" && KeyValue != "PS DPad Down" && KeyValue != "PS DPad Up" && KeyValue != "PS Left HRJ" && KeyValue != "PS Right HRJ" && KeyValue != "PS Up VRJ" && KeyValue != "PS Down VRJ"))
        {
            KeyCode NewKey = (KeyCode)Enum.Parse(typeof(KeyCode), KeyValue);
            print(NewKey.ToString());
            return NewKey;
        }
        return KeyCode.None;
    }
    public string SetKeyBindControllerAxis(string AxisValue)
    {
        if (ActivateGetKey == false)
        {
            string DefAxis;
            string NewAxis = AxisValue;

            if(NewAxis == "Left Left Joystick" || NewAxis == "Left Right Joystick")
            {
                DefAxis = "Horizontal";
            }
            else if (NewAxis == "Left Down Joystick" || NewAxis == "Left Up Joystick")
            {
                DefAxis = "Vertical";
            }
            else if (NewAxis == "DPad Left" || NewAxis == "DPad Right")
            {
                DefAxis = "DPad X";
            }
            else if (NewAxis == "DPad Down" || NewAxis == "DPad Up")
            {
                DefAxis = "DPad Y";
            }
            else if (NewAxis == "Left Trigger")
            {
                DefAxis = "Left Trigger";
            }
            else if (NewAxis == "Right Trigger")
            {
                DefAxis = "Right Trigger";
            }
            else if (NewAxis == "Left HRJ" || NewAxis == "Right HRJ")
            {
                DefAxis = "Right Stick X Axis";
            }
            else if (NewAxis == "Up VRJ" || NewAxis == "Down VRJ")
            {
                DefAxis = "Right Stick Y Axis";
            }
            else if (NewAxis == "PS DPad Left" || NewAxis == "PS DPad right")
            {
                DefAxis = "PS DPad X";
            }
            else if (NewAxis == "PS DPad Down" || NewAxis == "PS DPad Up")
            {
                DefAxis = "PS DPad Y";
            }
            else if (NewAxis == "PS Left HRJ" || NewAxis == "PS Right HRJ")
            {
                DefAxis = "PS Right Stick X Axis";
            }
            else if (NewAxis == "PS Up VRJ" || NewAxis == "PS Down VRJ")
            {
                DefAxis = "PS Right Stick Y Axis";
            }
            else
            {
                DefAxis = null;
            }
            
            print(NewAxis.ToString());
            return DefAxis;
        }
        return null;
    }

    #endregion

    public void AssingSpriteStandard(KeyCode vKey, KeyCode StandardKeyCode, Sprite SpriteKey, Button ButtonKey)
    {
        if (vKey == StandardKeyCode && SpriteKey != null && ButtonKey != null)      //Aggiunto buttonkey != null
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



        //Aggiungere righe qua per nuovi tasti


        //Numbers
        AssingSpriteStandard(vKey, KeyCode.Alpha0, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.Alpha1, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.Alpha2, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.Alpha3, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.Alpha4, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.Alpha5, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.Alpha6, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.Alpha7, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.Alpha8, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.Alpha9, SpriteStandardKeyEsc, TempButton);

        //Special Alphabet

        //Alphabet
        AssingSpriteStandard(vKey, KeyCode.A, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.B, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.D, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.E, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.F, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.G, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.H, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.I, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.J, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.K, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.L, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.M, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.N, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.O, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.P, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.Q, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.R, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.S, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.T, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.U, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.V, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.W, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.Y, SpriteStandardKeyEsc, TempButton);

        //Special Symbols
        AssingSpriteStandard(vKey, KeyCode.Semicolon, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.Equals, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.BackQuote, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.Quote, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.Slash, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.Comma, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.Period, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.Minus, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.LeftBracket, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.RightBracket, SpriteStandardKeyEsc, TempButton);
        AssingSpriteStandard(vKey, KeyCode.Backslash, SpriteStandardKeyEsc, TempButton);

        AssingSpriteStandard(vKey, KeyCode.None, SpriteEmpty, TempButton);      //Aggiunto il 16/07/21
    }

    public void AssingSpriteStringStandard(string KeyName, string Keystring, Button ButtonKey, Sprite SpriteKey)
    {
        if (KeyName == Keystring && ButtonKey != null)      //Aggiunto il 16/07/21
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


        //Aggiungere qui nuovi tasti

        AssignAllSpriteButton("Alpha0", SpriteStandardKeyZero);
        AssignAllSpriteButton("Alpha1", SpriteStandardKeyOne);
        AssignAllSpriteButton("Alpha2", SpriteStandardKeyTwo);
        AssignAllSpriteButton("Alpha3", SpriteStandardKeyThree);
        AssignAllSpriteButton("Alpha4", SpriteStandardKeyFour);
        AssignAllSpriteButton("Alpha5", SpriteStandardKeyFive);
        AssignAllSpriteButton("Alpha6", SpriteStandardKeySix);
        AssignAllSpriteButton("Alpha7", SpriteStandardKeySeven);
        AssignAllSpriteButton("Alpha8", SpriteStandardKeyEight);
        AssignAllSpriteButton("Alpha9", SpriteStandardKeyNine);

        AssignAllSpriteButton("A", SpriteStandard_A);
        AssignAllSpriteButton("B", SpriteStandard_B);
        AssignAllSpriteButton("D", SpriteStandard_D);
        AssignAllSpriteButton("E", SpriteStandard_E);
        AssignAllSpriteButton("F", SpriteStandard_F);
        AssignAllSpriteButton("G", SpriteStandard_G);
        AssignAllSpriteButton("H", SpriteStandard_H);
        AssignAllSpriteButton("I", SpriteStandard_I);
        AssignAllSpriteButton("J", SpriteStandard_J);
        AssignAllSpriteButton("K", SpriteStandard_K);
        AssignAllSpriteButton("L", SpriteStandard_L);
        AssignAllSpriteButton("M", SpriteStandard_M);
        AssignAllSpriteButton("N", SpriteStandard_N);
        AssignAllSpriteButton("O", SpriteStandard_O);
        AssignAllSpriteButton("P", SpriteStandard_P);
        AssignAllSpriteButton("Q", SpriteStandard_Q);
        AssignAllSpriteButton("R", SpriteStandard_R);
        AssignAllSpriteButton("S", SpriteStandard_S);
        AssignAllSpriteButton("T", SpriteStandard_T);
        AssignAllSpriteButton("U", SpriteStandard_U);
        AssignAllSpriteButton("W", SpriteStandard_W);
        AssignAllSpriteButton("Y", SpriteStandard_Y);

        AssignAllSpriteButton("Semicolon", SpriteStandardKeySemicolon);
        AssignAllSpriteButton("Equals", SpriteStandardKeyEquals);
        AssignAllSpriteButton("BackQuote", SpriteStandardKeyBackQuote);
        AssignAllSpriteButton("Quote", SpriteStandardKeyQuote);
        AssignAllSpriteButton("Slash", SpriteStandardKeySlash);
        AssignAllSpriteButton("Comma", SpriteStandardKeyComma);
        AssignAllSpriteButton("Period", SpriteStandardKeyPeriod);
        AssignAllSpriteButton("Minus", SpriteStandardKeyMinus);
        AssignAllSpriteButton("LeftBracket", SpriteStandardKeyLeftBracket);
        AssignAllSpriteButton("RightBracket", SpriteStandardKeyRightBracket);
        AssignAllSpriteButton("Backslash", SpriteStandardKeyBackslash);

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
        ControllerAssingSpriteStandard(vKey, KeyCode.Joystick1Button6, SpriteStandardXboxShare, TempButton);
        ControllerAssingSpriteStandard(vKey, KeyCode.Joystick1Button7, SpriteStandardXboxStart, TempButton);
        ControllerAssingSpriteStandard(vKey, KeyCode.Joystick1Button8, SpriteStandardLeftClickJoystick, TempButton);
        ControllerAssingSpriteStandard(vKey, KeyCode.Joystick1Button9, SpriteStandardRightClickJoystick, TempButton);

        //Aggiungere qui nuovi tasti controller che non siano assi

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
        ControllerAssignAllSpriteButton("Joystick1Button6", SpriteStandardXboxShare);
        ControllerAssignAllSpriteButton("Joystick1Button7", SpriteStandardXboxStart);
        ControllerAssignAllSpriteButton("Joystick1Button8", SpriteStandardLeftClickJoystick);
        ControllerAssignAllSpriteButton("Joystick1Button9", SpriteStandardRightClickJoystick);
        //ControllerAssignAllSpriteButton("Horizontal", SpriteStandardLeftLeftJoystick);
        //ControllerAssignAllSpriteButton("Horizontal", SpriteStandardLeftRightJoystick);
        //ControllerAssignAllSpriteButton("Vertical", SpriteStandardLeftDownJoystick);

        //Aggiungere nuovi tasti controller che non siano assi
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
        AxisControllerAssingSpriteStandard(Axis, "Left Left Joystick", SpriteStandardLeftLeftJoystick, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "Left Right Joystick", SpriteStandardLeftRightJoystick, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "Left Down Joystick", SpriteStandardLeftDownJoystick, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "Left Up Joystick", SpriteStandardLeftUpJoystick, TempButton);

        AxisControllerAssingSpriteStandard(Axis, "Left Trigger", SpriteStandardLT, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "Right Trigger", SpriteStandardRT, TempButton);

        AxisControllerAssingSpriteStandard(Axis, "DPad Left", SpriteStandardDPadLeft, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "DPad Right", SpriteStandardDPadRight, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "DPad Up", SpriteStandardDPadUp, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "DPad Down", SpriteStandardDPadDown, TempButton);

        AxisControllerAssingSpriteStandard(Axis, "Left HRJ", SpriteStandardRightLeftJoystick, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "Right HRJ", SpriteStandardRightRightJoystick, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "Up VRJ", SpriteStandardRightUpJoystick, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "Down VRJ", SpriteStandardRightDownJoystick, TempButton);



        //AxisControllerAssingSpriteStandard(Axis, "", SpriteStandardLB, TempButton);
        //AxisControllerAssingSpriteStandard(Axis, "", SpriteStandardRB, TempButton);

        AxisControllerAssingSpriteStandard(Axis, "PS DPad Left", SpriteStandardDPadLeft, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "PS DPad Right", SpriteStandardDPadRight, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "PS DPad Down", SpriteStandardDPadDown, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "PS DPad Up", SpriteStandardDPadUp, TempButton);

        AxisControllerAssingSpriteStandard(Axis, "PS Left HRJ", SpriteStandardLeftLeftJoystick, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "PS Right HRJ", SpriteStandardLeftRightJoystick, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "PS Up VRJ", SpriteStandardX, TempButton);
        AxisControllerAssingSpriteStandard(Axis, "PS Down VRJ", SpriteStandardLeftDownJoystick, TempButton);

        //Aggiungere tasti controller
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
        AxisControllerAssignAllSpriteButton("Left Left Joystick", SpriteStandardLeftLeftJoystick);
        AxisControllerAssignAllSpriteButton("Left Right Joystick", SpriteStandardLeftRightJoystick);
        AxisControllerAssignAllSpriteButton("Left Down Joystick", SpriteStandardLeftDownJoystick);
        AxisControllerAssignAllSpriteButton("Left Up", SpriteStandardLeftUpJoystick);

        AxisControllerAssignAllSpriteButton("Left Trigger", SpriteStandardLT);
        AxisControllerAssignAllSpriteButton("Right Trigger", SpriteStandardRT);

        AxisControllerAssignAllSpriteButton("DPad Left", SpriteStandardDPadLeft);
        AxisControllerAssignAllSpriteButton("DPad Right", SpriteStandardDPadRight);
        AxisControllerAssignAllSpriteButton("DPad Up", SpriteStandardDPadUp);
        AxisControllerAssignAllSpriteButton("DPad Down", SpriteStandardDPadDown);

        AxisControllerAssignAllSpriteButton("Left HRJ", SpriteStandardRightDownJoystick);
        AxisControllerAssignAllSpriteButton("Right HRJ", SpriteStandardRightRightJoystick);
        AxisControllerAssignAllSpriteButton("Up VRJ", SpriteStandardRightUpJoystick);
        AxisControllerAssignAllSpriteButton("Down VRJ", SpriteStandardRightDownJoystick);


        //Aggiungere tasti qui controller
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

        //Aggiungere tasti qui controller
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

        //Aggiungere tasti qui controller
    }/**/
    #endregion
}