using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameTutorial : MonoBehaviour
{
    public void ResetTutorial()
    {
        PlayerPrefs.SetInt("TutorialSkip", 0);
    }
}
