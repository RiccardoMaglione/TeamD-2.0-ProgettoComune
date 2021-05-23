using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class SpecialBabushka : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] Animator animator;
    [SerializeField] GameObject attack1;
    [SerializeField] GameObject attack2;



    public AnimatorOverrideController OriginalBabushkaOverride;
    public AnimatorOverrideController SpecialBabushkaOverride;
    public IEnumerator Attack()
    {
        GetComponentInParent<PSMController>().GetComponent<Animator>().runtimeAnimatorController = SpecialBabushkaOverride;

        GameObject originalLight;
        GameObject originalHeavy;
        originalLight = GetComponentInParent<PSMController>().LightAttackCollider;
        originalHeavy = GetComponentInParent<PSMController>().HeavyAttackCollider;
        GetComponentInParent<PSMController>().LightAttackCollider = attack1;
        GetComponentInParent<PSMController>().HeavyAttackCollider = attack2;
        animator.GetComponentInParent<PSMController>().GetComponent<Animator>().SetBool("PSM-SpecialAttack", false);
        yield return new WaitForSeconds(time);
        GetComponentInParent<PSMController>().LightAttackCollider = originalLight;
        GetComponentInParent<PSMController>().HeavyAttackCollider = originalHeavy;
        animator.SetBool("IsAttack", false);


        GetComponentInParent<PSMController>().GetComponent<Animator>().runtimeAnimatorController = OriginalBabushkaOverride;
    }
}
