using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    public GameObject SelectionPanel;
    
    public GameObject[] WaypointChooseImage = new GameObject[4];
    public GameObject ArrowChoose;
    int i = 0;
    public static int IDChoosePlayer;


    private void Update()
    {
        SelectionPlayer();
        ChoosePlayer();
    }
    public void SelectionPlayer()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (i > 0)
            {
                i -= 1;
                ArrowChoose.transform.position = WaypointChooseImage[i].transform.position;
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    IDChoosePlayer = i;
                    SelectionPanel.SetActive(false);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(i < 3)
            {
                i += 1;
                ArrowChoose.transform.position = WaypointChooseImage[i].transform.position;
            }
        }
    }

    public void ChoosePlayer()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            IDChoosePlayer = i;
            SelectionPanel.SetActive(false);
        }
    }
}
