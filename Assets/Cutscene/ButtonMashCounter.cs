using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMashCounter : MonoBehaviour
{
    public int attack = 0;
    [SerializeField] int target;

    void Update()
    {
        if (attack >= target)
        {
            VictoryScreen.win = true;
            PlayerPrefs.SetInt("CompletedLevel", 1);
        }
    }
}
