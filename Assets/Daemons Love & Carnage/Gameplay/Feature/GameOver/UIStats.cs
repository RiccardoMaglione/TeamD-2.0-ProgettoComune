using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIStats : MonoBehaviour
{
    public TextMeshProUGUI BestScore;
    public TextMeshProUGUI BestTime;
    public TextMeshProUGUI NumberPossession;

    void Start()
    {
        UpdateStats();
    }

    public void UpdateStats()
    {
        if (PlayerPrefs.GetFloat("TimerGameplay") < PlayerPrefs.GetFloat("BestTimer", float.MaxValue))
        {
            PlayerPrefs.SetFloat("BestTimer", PlayerPrefs.GetFloat("TimerGameplay"));
        }

        BestTime.text = PlayerPrefs.GetString("StringTimerGameplay", "00:00:00");


        NumberPossession.text = PlayerPrefs.GetInt("CountPossession").ToString();
    }
}
