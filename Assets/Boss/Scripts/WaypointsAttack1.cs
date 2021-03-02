﻿using UnityEngine;

public class WaypointsAttack1 : MonoBehaviour
{
    public GameObject[] waypoints;
    public int i = 0;
    public float[] speed;
    float WPradius = 0.1f;
    
    public void Attack1()
    {
        if (i < waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[i].transform.position, Time.deltaTime * speed[i]);

            if ((Vector3.Distance(waypoints[i].transform.position, transform.position) < WPradius) && i < waypoints.Length)
            {
                i++;
            }
        }
    }
}
