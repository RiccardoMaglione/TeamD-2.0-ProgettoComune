using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerGameplay : MonoBehaviour
{
    public float Timer;

    public float Seconds;
    public int Minutes;
    public int Hours;

    public string HoursZero;
    public float speedTimer;
    void Update()
    {
        TimeGame();
    }

    public void TimeGame()
    {
        Seconds += Time.deltaTime * speedTimer;
        Timer += Time.deltaTime;
        if(Seconds > 59)
        {
            Seconds = 0;
            Minutes++;
            if(Minutes > 59)
            {
                Minutes = 0;
                Hours++;
            }
        }

        if (Hours <= 9)
        {
            HoursZero = "0";
        }
        else
        {
            HoursZero = "";
        }

        //print(HoursZero + Hours + ":" + Minutes.ToString("00") + ":" + Seconds.ToString("00"));

        PlayerPrefs.SetString("StringTimerGameplay", HoursZero + Hours + ":" + Minutes.ToString("00") + ":" + Seconds.ToString("00"));

        PlayerPrefs.SetFloat("TimerGameplay", Timer);
    }
}
