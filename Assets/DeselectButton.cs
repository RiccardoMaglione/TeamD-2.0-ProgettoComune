using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeselectButton : MonoBehaviour
{
    public void DeselectClickedButton(GameObject button)
    {
        if (EventSystem.current.currentSelectedGameObject == button && CheckInput.Controller == false)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}
