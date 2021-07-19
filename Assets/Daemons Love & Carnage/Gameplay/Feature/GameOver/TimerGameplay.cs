using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimerGameplay : MonoBehaviour
{
    public float Timer;
    public float Seconds;

    public int Minutes;
    public int Hours;

    public string HoursZero;
    public float speedTimer;

    public bool Once;

    private void Start()
    {
        //Debug.Log("Inizio ora "+DateTime.Now.ToString());
    }
    void Update()
    {
        TimeGame();
    }

    /// <summary>
    /// Inconsistent Time with speedTimer 1/2 sec
    /// </summary>
    public void TimeGame()
    {

        Seconds += Time.deltaTime * speedTimer;
        Timer += Time.deltaTime;

        if (Seconds > 60)
        {
            //Debug.Log(DateTime.Now.ToString());
            Seconds = 0;
            Minutes++;
        }
        
        if(Minutes > 60)
        {
            //Debug.Log("E' passata 1 ora " + DateTime.Now.ToString());
            Minutes = 0;
            Hours++;
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
