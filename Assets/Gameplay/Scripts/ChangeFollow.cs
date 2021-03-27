using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeFollow : MonoBehaviour
{
    public List<CinemachineVirtualCamera> CamList = new List<CinemachineVirtualCamera>();
    public static GameObject NewPlayer;

    void Update()
    {
        for (int i = 0; i < CamList.Count; i++)
        {
            if(NewPlayer != null)
            {
                CamList[i].Follow = NewPlayer.transform;
            }
        }
    }
}
