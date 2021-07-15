using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStats : MonoBehaviour
{
    public void ResetStatsGame()
    {
        PlayerPrefs.SetInt("ObtainSkull", 0);
        PlayerPrefs.SetFloat("BestTimer", 0);
        PlayerPrefs.SetString("StringTimerGameplay", "00:00:00");
        PlayerPrefs.SetFloat("TimerGameplay", 0);
        PlayerPrefs.SetInt("CountPossession", 0);
    }
    public void FirstResetStatsGame()
    {
        if (PlayerPrefs.GetInt("NewGameFirst") == 0)
        {
            PlayerPrefs.SetInt("ObtainSkull", 0);
            PlayerPrefs.SetFloat("BestTimer", 0);
            PlayerPrefs.SetString("StringTimerGameplay", "00:00:00");
            PlayerPrefs.SetFloat("TimerGameplay", 0);
            PlayerPrefs.SetInt("CountPossession", 0);
        }
    }
}
