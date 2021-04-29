using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] Toggle toggle;

    public void SetWindow()
    {
        if (toggle.isOn == false)
        {
            Screen.fullScreen = true;
            PlayerPrefs.SetInt("Fullscreen", 1);
        }

        if (toggle.isOn == true)
        {
            Screen.fullScreen = false;
            PlayerPrefs.SetInt("Fullscreen", 0);
        }
    }

    void Awake()
    {
        if (PlayerPrefs.GetInt("Fullscreen") == 0)
            toggle.isOn = true;
        else
            toggle.isOn = false;
    }
}
