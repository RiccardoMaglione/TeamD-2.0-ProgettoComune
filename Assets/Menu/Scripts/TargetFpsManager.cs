using UnityEngine;

public class TargetFpsManager : MonoBehaviour
{
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        if (PlayerPrefs.GetInt("StartGame", 0) == 0)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("StartGame", 1);
        }   
    }
}
