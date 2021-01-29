using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int Life;

    public int LightDamage;
    public int HeavyDamage;
    public int SpecialDamage;

    public bool isStun = false;
    public float timerStun = 0;
    public float DurationStun = 5;


    public bool isPossessed = false;
    void Update()
    {
        if(Life <= 0)
        {
            isStun = true;
            if(isStun == true && isPossessed == false)
            {
                timerStun += Time.deltaTime;
                if(timerStun >= DurationStun)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
