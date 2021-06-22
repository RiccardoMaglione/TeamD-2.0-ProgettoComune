using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class ThiefSpecialAttack : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float time;
    public bool isSpecialActive = false;

    public static ThiefSpecialAttack instance;

    public IEnumerator Attack()
    {
        isSpecialActive = true;
        yield return new WaitForSeconds(time);
        isSpecialActive = false;
        animator.SetBool("IsAttack", false);
        animator.GetComponentInParent<PSMController>().GetComponent<Animator>().SetBool("PSM-SpecialAttack", false);
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
