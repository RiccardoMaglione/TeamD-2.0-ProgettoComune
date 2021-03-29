using System.Collections;
using UnityEngine;
using XInputDotNetPure;

public class FeedbackManager : MonoBehaviour
{
    PlayerIndex playerIndex;

    [Header("CONTROLLER VIBRATION VALUES")]
    [Range(0f, 1f)]
    public float leftMotor;
    [Range(0f, 1f)]
    public float rightMotor;
    public float vibrationDuration;


    [Header("TIME STOP VALUES")]
    public float stopTimeLightDuration;
    public float stopTimeHeavyDuration;

    public static FeedbackManager instance;

    [HideInInspector]
    public bool isTimeStopped = false;


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

    public IEnumerator Vibration()
    {
        GamePad.SetVibration(playerIndex, leftMotor, rightMotor);
        yield return new WaitForSecondsRealtime(vibrationDuration);
        GamePad.SetVibration(playerIndex, 0f, 0f);
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
