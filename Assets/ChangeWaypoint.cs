using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWaypoint : MonoBehaviour
{
    public List<GameObject> ListWaypoint = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyData>().WaypointEnemy.Clear();
            for (int i = 0; i < ListWaypoint.Count; i++)
            {
                collision.GetComponent<EnemyData>().WaypointEnemy.Add(ListWaypoint[i]);
            }
        }
    }
}
