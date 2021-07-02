using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeButton : MonoBehaviour
{
    Button ThisButton;
    public static Button PrecedentButton;

    void Start()
    {
        ThisButton = GetComponent<Button>();
    }

    public void InteractableButtonGameObject(GameObject FirstSelectableObject)
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            //ThisButton.interactable = false;
            PrecedentButton = ThisButton;
            EventSystem.current.SetSelectedGameObject(FirstSelectableObject);
        }
    }
    public void InteractableButtonNull()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            //ThisButton.interactable = false;
            PrecedentButton = ThisButton;
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    public void InteractableButtonsdfaaaaaaaaa(GameObject FirstSelectableObject)
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            PrecedentButton = ThisButton;
            FirstSelectableObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(FirstSelectableObject);
        }
    }
}
