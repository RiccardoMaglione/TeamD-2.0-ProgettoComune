using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefSpecialAttack : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float time;

    public IEnumerator Attack()
    {     
        yield return new WaitForSeconds(time);      
        animator.SetBool("IsAttack", false);
    }
}
