using System.Collections;
using UnityEngine;

public class FeedbackManager : MonoBehaviour
{
    [Header("TIME STOP VALUES")]
    public float stopTimeLightDuration;
    public float stopTimeHeavyDuration;
    
    public static FeedbackManager instance;


    public IEnumerator StopTimeLight()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(stopTimeLightDuration);
        Time.timeScale = 1;
    }

    public IEnumerator StopTimeHeavy()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(stopTimeHeavyDuration);
        Time.timeScale = 1;
    }


    void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
