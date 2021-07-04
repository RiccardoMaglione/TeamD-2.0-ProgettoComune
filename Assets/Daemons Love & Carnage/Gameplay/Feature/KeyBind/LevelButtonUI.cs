using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonUI : MonoBehaviour
{
    public Sprite LevelButtonNormal;
    public Sprite LevelButtonHover;

    public void HoverSkull()
    {
        GetComponent<Image>().sprite = LevelButtonHover;
        GetComponent<RectTransform>().localScale = new Vector3(4.3057f, 4.3057f, 4.3057f);
    }
    public void DeHoverSkull()
    {
        GetComponent<Image>().sprite = LevelButtonNormal;
        GetComponent<RectTransform>().localScale = new Vector3(3.3057f, 3.3057f, 3.3057f);
    }
}
