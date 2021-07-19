using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPortrait : MonoBehaviour
{
    public Image Portrait;
    public static Image StaticPortrait;

    private void Awake()
    {
        StaticPortrait = Portrait;
    }
}
