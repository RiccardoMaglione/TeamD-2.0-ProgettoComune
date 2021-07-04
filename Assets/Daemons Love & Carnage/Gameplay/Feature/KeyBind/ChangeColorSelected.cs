using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorSelected : MonoBehaviour
{
    public Color NormalSelectedColor;
    public Color ControllerSelectedColor;

    ColorBlock NormalSelectedColorBlock;
    ColorBlock ControllerSelectedColorBlock;

    [HideInInspector] public Button ThisButton;
    
    private void Awake()
    {
        ThisButton = gameObject.GetComponent<Button>();

        NormalSelectedColorBlock = ThisButton.colors;
        NormalSelectedColorBlock.selectedColor = NormalSelectedColor;

        ControllerSelectedColorBlock = ThisButton.colors;
        ControllerSelectedColorBlock.selectedColor = ControllerSelectedColor;
    }

    private void Update()
    {
        if (CheckInput.Controller == false)
        {
            ThisButton.colors = NormalSelectedColorBlock;
        }
        if (CheckInput.Controller == true)
        {
            ThisButton.colors = ControllerSelectedColorBlock;
        }
    }
}
