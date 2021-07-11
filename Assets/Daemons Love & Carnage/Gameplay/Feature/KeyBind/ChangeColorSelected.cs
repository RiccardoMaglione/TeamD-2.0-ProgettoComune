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
    [HideInInspector] public Toggle ThisToggle;
    [HideInInspector] public Slider ThisSlider;

    private void Awake()
    {
        if(gameObject.GetComponent<Button>() != null)
        {
            ThisButton = gameObject.GetComponent<Button>();

            NormalSelectedColorBlock = ThisButton.colors;
            NormalSelectedColorBlock.selectedColor = NormalSelectedColor;

            ControllerSelectedColorBlock = ThisButton.colors;
            ControllerSelectedColorBlock.selectedColor = ControllerSelectedColor;
        }

        if(gameObject.GetComponent<Toggle>() != null)
        {
            ThisToggle = gameObject.GetComponent<Toggle>();

            NormalSelectedColorBlock = ThisToggle.colors;
            NormalSelectedColorBlock.selectedColor = NormalSelectedColor;

            ControllerSelectedColorBlock = ThisToggle.colors;
            ControllerSelectedColorBlock.selectedColor = ControllerSelectedColor;
        }

        if(gameObject.GetComponent<Slider>() != null)
        {
            ThisSlider = gameObject.GetComponent<Slider>();

            NormalSelectedColorBlock = ThisSlider.colors;
            NormalSelectedColorBlock.selectedColor = NormalSelectedColor;

            ControllerSelectedColorBlock = ThisSlider.colors;
            ControllerSelectedColorBlock.selectedColor = ControllerSelectedColor;
        }
    }

    private void Update()
    {
        if (CheckInput.Controller == false)
        {
            if(ThisButton != null)
                ThisButton.colors = NormalSelectedColorBlock;
            if(ThisToggle != null)
                ThisToggle.colors = NormalSelectedColorBlock;
            if(ThisSlider != null)
                ThisSlider.colors = NormalSelectedColorBlock;
        }
        if (CheckInput.Controller == true)
        {
            if (ThisButton != null)
                ThisButton.colors = ControllerSelectedColorBlock;
            if (ThisToggle != null)
                ThisToggle.colors = ControllerSelectedColorBlock;
            if (ThisSlider != null)
                ThisSlider.colors = ControllerSelectedColorBlock;
        }
    }
}
