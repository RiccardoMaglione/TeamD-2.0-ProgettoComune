using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class ThiefSpecialAttack : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float time;

    public IEnumerator Attack()
    {     
        yield return new WaitForSeconds(time);
        animator.SetBool("IsAttack", false);
        animator.GetComponentInParent<PSMController>().GetComponent<Animator>().SetBool("PSM-SpecialAttack", false);
    }
}
