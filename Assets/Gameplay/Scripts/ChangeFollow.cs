using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using SwordGame;

public class ChangeFollow : MonoBehaviour
{
    public List<CinemachineVirtualCamera> CamList = new List<CinemachineVirtualCamera>();
    public GameObject NewPlayer;
    public static GameObject StaticPlayerTemp;
    void Update()
    {
        for (int i = 0; i < CamList.Count; i++)
        {
            if(NewPlayer != null)
            {
                CamList[i].Follow = NewPlayer.transform;
                StaticPlayerTemp = NewPlayer;
                NewPlayer.GetComponent<PSMController>().MaxHealth = 2147483647;
                NewPlayer.GetComponent<PSMController>().CurrentHealth = 2147483647;
            }
        }
    }
}
