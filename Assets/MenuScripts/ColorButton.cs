using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    public ColorBlock ColorBlockPc;
    public ColorBlock ColorBlockPcHover;

    public List<Button> ThisButtonList = new List<Button>();

    private void Start()
    {
        if (CheckInput.Controller == true)
        {
            for (int i = 0; i < ThisButtonList.Count; i++)
            {
                ThisButtonList[i].colors = ColorBlockPcHover;
            }
        }
        else
        {
            for (int i = 0; i < ThisButtonList.Count; i++)
            {
                ThisButtonList[i].colors = ColorBlockPc;
            }
        }
    }

    public void ResetColorBlockPcHover(Button ThisButton)
    {
        ThisButton.colors = ColorBlockPcHover;
    }

    public void ResetColorBlockPcDeHover(Button ThisButton)
    {
        ThisButton.colors = ColorBlockPc;
    }

    public void UpdateColorBlockDeHover(Button ThisButton)
    {
        if(CheckInput.Controller == true)
        {
            ThisButton.colors = ColorBlockPcHover;
        }
    }
}



//Potrebbe diventare uno script che gestisce il controller?