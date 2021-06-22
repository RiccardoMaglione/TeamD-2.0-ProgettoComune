using Cinemachine;
using System.Collections;
using UnityEngine;
using XInputDotNetPure;

public class FeedbackManager : MonoBehaviour
{
    public CinemachineVirtualCamera[] cam;
    [Header("ZOOM")]
    public float speed;
    public float endPosition;

    PlayerIndex playerIndex;
    [Header("CONTROLLER VIBRATION")]
    [Range(0f, 1f)]
    public float leftMotor;
    [Range(0f, 1f)]
    public float rightMotor;
    public float vibrationDuration;


    [Header("TIME STOP")]
    public float stopTimeLightDuration;
    public float stopTimeHeavyDuration;
    public float playerStopTimeDuration;

    [Header("CUT IN")]
    public float cutInDuration;
    public GameObject cutInBabushkaImage;
    public GameObject cutInThiefImage;
    public GameObject cutInBoriusImage;
    public GameObject cutInFatImage;
    [HideInInspector]
    public bool isCutIn = false;

    public static FeedbackManager instance;

    [HideInInspector]
    public bool isTimeStopped = false;

    public GameObject CircleWipeGameObject;
    [HideInInspector]
    public bool PlayerDieZoom = false;

    public IEnumerator StopTimeLight()
    {
        Time.timeScale = 0;
        isTimeStopped = true;
        yield return new WaitForSecondsRealtime(stopTimeLightDuration);
        Time.timeScale = 1;
        isTimeStopped = false;
    }

    public IEnumerator StopTimeHeavy()
    {
        Time.timeScale = 0;
        isTimeStopped = true;
        yield return new WaitForSecondsRealtime(stopTimeHeavyDuration);
        Time.timeScale = 1;
        isTimeStopped = false;
    }

    public IEnumerator StopTimePlayer()
    {
        Time.timeScale = 0;
        isTimeStopped = true;
        yield return new WaitForSecondsRealtime(playerStopTimeDuration);
        Time.timeScale = 1;
        isTimeStopped = false;
    }

    public IEnumerator CutInFat()
    {
        isCutIn = true;
        cutInFatImage.SetActive(true);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(cutInDuration);
        Time.timeScale = 1;
        cutInFatImage.SetActive(false);
        isCutIn = false;
    }

    public IEnumerator CutInBabushka()
    {
        isCutIn = true;
        cutInBabushkaImage.SetActive(true);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(cutInDuration);
        Time.timeScale = 1;
        cutInBabushkaImage.SetActive(false);
        isCutIn = false;
    }

    public IEnumerator CutInBorius()
    {
        isCutIn = true;
        cutInBoriusImage.SetActive(true);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(cutInDuration);
        Time.timeScale = 1;
        cutInBoriusImage.SetActive(false);
        isCutIn = false;
    }

    public IEnumerator CutInThief()
    {
        isCutIn = true;
        cutInThiefImage.SetActive(true);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(cutInDuration);
        Time.timeScale = 1;
        cutInThiefImage.SetActive(false);
        isCutIn = false;
    }

    public void StartVibration()
    {
        GamePad.SetVibration(playerIndex, leftMotor, rightMotor);
    }

    public void StopVibration()
    {
        GamePad.SetVibration(playerIndex, 0f, 0f);
    }

    public IEnumerator Vibration()
    {
        StartVibration();
        yield return new WaitForSecondsRealtime(vibrationDuration);
        StopVibration();
    }

    public void Zoom()
    {
        PlayerDieZoom = true;
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
