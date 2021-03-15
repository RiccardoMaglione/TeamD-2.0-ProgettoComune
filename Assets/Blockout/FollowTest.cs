using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTest : MonoBehaviour
{

    public EnemyData enemyData;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 8 )
        {
            Debug.Log("Entrato nel trigger");
        }
    }
}
