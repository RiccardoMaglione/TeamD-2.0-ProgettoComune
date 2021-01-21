using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;
public class ReturnPlayer : MonoBehaviour
{

    public static GameObject LastDetect;
    public static bool CanDestroy = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CanDestroy == true)
        {
            Invoke("DestroyPlayer", 5);
        }
        if (LastDetect != null && LastDetect.tag == "Player")
        {
            CanDestroy = false;
            CancelInvoke("DestroyPlayer");
        }
        print(CanDestroy);
    }

    public void DestroyPlayer()
    {
        Destroy(LastDetect);
    }
}
