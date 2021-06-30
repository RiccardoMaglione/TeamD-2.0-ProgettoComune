using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidBoss : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int rand = Random.Range(1, 3);
        if(rand == 1)
            animator.SetTrigger("GoToStagger1");

        if (rand == 2)
            animator.SetTrigger("GoToStagger2");

        GetComponent<ButtonMashCounter>().attack++;
    }
}
