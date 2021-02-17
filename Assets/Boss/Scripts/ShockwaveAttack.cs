using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveAttack : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float height;
    bool isPatrol = false;

    IEnumerator Patrol()
    {
        isPatrol = true;
        
        yield return new WaitForSeconds(3);
    }


    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, height, transform.position.z);
        if (isPatrol == false)
        {
            StartCoroutine(Patrol());
        }
    }
}
