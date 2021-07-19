using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeControllerSprite : MonoBehaviour
{
    public GameObject Select;
    public GameObject BackClose;

    public Sprite PCSelectSprite;
    public Sprite PCBackCloseSprite;

    public Sprite XboxSelectSprite;
    public Sprite XboxBackCloseSprite;

    public Sprite PlaystationSelectSprite;
    public Sprite PlaystationBackCloseSprite;

    public Sprite StandardControllerSelectSprite;
    public Sprite StandardControllerBackCloseSprite;

    private void Update()
    {
        ChangeSprite();
    }

    public void ChangeSprite()
    {
        if (CheckInput.Controller == true)
        {
            if(CheckInput.XboxController == true && CheckInput.PlaystationController == false)
            {
                if(Select != null)
                    Select.GetComponent<Image>().sprite = XboxSelectSprite;
                if(BackClose != null)
                    BackClose.GetComponent<Image>().sprite = XboxBackCloseSprite;
            }
            else if(CheckInput.PlaystationController == true && CheckInput.XboxController == false)
            {
                if (Select != null)
                    Select.GetComponent<Image>().sprite = PlaystationSelectSprite;
                if (BackClose != null)
                    BackClose.GetComponent<Image>().sprite = PlaystationBackCloseSprite;
            }
            else if(CheckInput.PlaystationController == false && CheckInput.XboxController == false)
            {
                if (Select != null)
                    Select.GetComponent<Image>().sprite = StandardControllerSelectSprite;
                if (BackClose != null)
                    BackClose.GetComponent<Image>().sprite = StandardControllerBackCloseSprite;
            }
        }
        else if(CheckInput.Controller == false)
        {
            if (Select != null)
                Select.GetComponent<Image>().sprite = PCSelectSprite;
            if (BackClose != null)
                BackClose.GetComponent<Image>().sprite = PCBackCloseSprite;
        }
    }
}
