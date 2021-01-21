using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;
public class ReturnPlayer : MonoBehaviour
{

    public static GameObject LastDetect;
    public static bool CanDestroy = false;
    public static float timerDestroy;
    public float timerDestroyInspector;
    public float timerLimit = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerDestroyInspector = timerDestroy;
        if(CanDestroy == true)
        {
            timerDestroy += Time.deltaTime;
            if(timerDestroy >= timerLimit)
            {
                Destroy(LastDetect);
                timerDestroy = timerLimit;
                CanDestroy = false;
            }
        }
        if (LastDetect != null && LastDetect.tag == "Player")
        {
            timerDestroy = 0;
            CanDestroy = false;
            print("DSAD");
        }
    }

}
