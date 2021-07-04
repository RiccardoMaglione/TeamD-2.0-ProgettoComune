using SwordGame;
using System.Collections;
using UnityEngine;

public class SpecialBabushka : MonoBehaviour
{
    public ParticleSystem rageAuraParticle;
    [SerializeField] float time;
    [SerializeField] Animator animator;
    [SerializeField] GameObject attack1;
    [SerializeField] GameObject attack2;

    #region Speed Animation Special
    public float SpecialPlayerIdleSpeed = 1;
    public float SpecialPlayerMoveSpeed = 1;
    public float SpecialPlayerDashSpeed = 1;
    public float SpecialPlayerFallSpeed = 1;
    public float SpecialPlayerDashFallSpeed = 1;
    public float SpecialPlayerJumpSpeed = 1;
    public float SpecialPlayerDieSpeed = 1;
    public float SpecialPlayerStaggerSpeed = 1;
    public float SpecialPlayerLightAttackSpeed = 1;
    public float SpecialPlayerHeavyAttackSpeed = 1;
    public float SpecialPlayerSpecialAttackSpeed = 1;
    #endregion


    public AnimatorOverrideController OriginalBabushkaOverride;
    public AnimatorOverrideController SpecialBabushkaOverride;

    public bool DecreaseEnergy;
    public static bool BabuskaSpecial;
    private void Update()
    {
        if (DecreaseEnergy == true)
        {
            GetComponentInParent<PSMController>().CurrentEnergy -= Time.deltaTime * ((GetComponentInParent<PSMController>().MaxEnergy / time));
        }
    }

    public IEnumerator Attack()
    {
        DecreaseEnergy = true;
        BabuskaSpecial = true;
        GetComponentInParent<PSMController>().GetComponent<Animator>().runtimeAnimatorController = SpecialBabushkaOverride;

        GameObject originalLight;
        GameObject originalHeavy;
        originalLight = GetComponentInParent<PSMController>().LightAttackCollider;
        originalHeavy = GetComponentInParent<PSMController>().HeavyAttackCollider;
        GetComponentInParent<PSMController>().LightAttackCollider = attack1;
        GetComponentInParent<PSMController>().HeavyAttackCollider = attack2;
        animator.GetComponentInParent<PSMController>().GetComponent<Animator>().SetBool("PSM-SpecialAttack", false);
        InitializeSpeedAnimationSpecial();
        yield return new WaitForSeconds(time);
        DecreaseEnergy = false;
        BabuskaSpecial = false;
        GetComponentInParent<PSMController>().CurrentEnergy = (int)GetComponentInParent<PSMController>().CurrentEnergy;
        StopRageAura();
        GetComponentInParent<PSMController>().LightAttackCollider = originalLight;
        GetComponentInParent<PSMController>().HeavyAttackCollider = originalHeavy;
        animator.SetBool("IsAttack", false);

        if(GetComponentInParent<PSMController>().isActiveAndEnabled)
        {
            GetComponentInParent<PSMController>().GetComponent<Animator>().runtimeAnimatorController = OriginalBabushkaOverride;
        }
        GetComponentInParent<PSMController>().InitializeSpeedAnimation();
    }
    public void InitializeSpeedAnimationSpecial()
    {
        GetComponentInParent<PSMController>().GetComponent<Animator>().SetFloat("PlayerIdleSpeed", SpecialPlayerIdleSpeed);
        GetComponentInParent<PSMController>().GetComponent<Animator>().SetFloat("PlayerMoveSpeed", SpecialPlayerMoveSpeed);
        GetComponentInParent<PSMController>().GetComponent<Animator>().SetFloat("PlayerDashSpeed", SpecialPlayerDashSpeed);
        GetComponentInParent<PSMController>().GetComponent<Animator>().SetFloat("PlayerFallSpeed", SpecialPlayerFallSpeed);
        GetComponentInParent<PSMController>().GetComponent<Animator>().SetFloat("PlayerDashFallSpeed", SpecialPlayerDashFallSpeed);
        GetComponentInParent<PSMController>().GetComponent<Animator>().SetFloat("PlayerJumpSpeed", SpecialPlayerJumpSpeed);
        GetComponentInParent<PSMController>().GetComponent<Animator>().SetFloat("PlayerDieSpeed", SpecialPlayerDieSpeed);
        GetComponentInParent<PSMController>().GetComponent<Animator>().SetFloat("PlayerStaggerSpeed", SpecialPlayerStaggerSpeed);
        GetComponentInParent<PSMController>().GetComponent<Animator>().SetFloat("PlayerLightAttackSpeed", SpecialPlayerLightAttackSpeed);
        GetComponentInParent<PSMController>().GetComponent<Animator>().SetFloat("PlayerHeavyAttackSpeed", SpecialPlayerHeavyAttackSpeed);
        GetComponentInParent<PSMController>().GetComponent<Animator>().SetFloat("PlayerSpecialAttackSpeed", SpecialPlayerSpecialAttackSpeed);
    }
    public void StopRageAura()
    {
        rageAuraParticle.Stop();
    }

}
