using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckInput : MonoBehaviour
{
    public static bool Controller = false;

    public static bool XboxController = false;
    public static bool PlaystationController = false;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        foreach (KeyCode vKey in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyUp(vKey))
            {
                if (vKey >= KeyCode.JoystickButton0)
                {
                    Controller = true;
                    print("Joystick");
                }
                else
                {
                    XboxController = false;
                    PlaystationController = false;
                    Controller = false;
                    print("Mouse and keyboard");
                }
            }
            else if((Input.GetAxisRaw("DPad X") > 0 || Input.GetAxisRaw("DPad X") < 0 || Input.GetAxisRaw("DPad Y") > 0 || Input.GetAxisRaw("DPad Y") < 0) && XboxController == true)   //joystick 6th axis
            {
                Controller = true;
                print("Joystick Axis");
            }
        }

        CheckController();
    }

    public void CheckController()
    {
        string NameController;
        string[] names = Input.GetJoystickNames();

        for (int i = 0; i < names.Length; i++)
        {
            Debug.LogError(names[i]);
            NameController = names[i];
            if (NameController.Contains("Xbox"))
            {
                Debug.Log("E' il controller dell'xbox");
                XboxController = true;
                PlaystationController = false;
            }
            else if (NameController.Contains("Wireless") &! NameController.Contains("Xbox"))
            {
                Debug.Log("E' il controller della playstation");
                PlaystationController = true;
                XboxController = false;
            }
        }
    }
}
