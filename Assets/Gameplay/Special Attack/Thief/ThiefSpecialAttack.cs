using SwordGame;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ThiefSpecialAttack : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float time;
    public bool isSpecialActive = false;

    public static ThiefSpecialAttack instance;

    public bool DecreaseEnergy;

    public AnimatorOverrideController OriginalThiefOverride;
    public AnimatorOverrideController SpecialThiefOverride;

    #region Speed Animation Special
    public float SpecialPlayerIdleSpeed = 15;
    public float SpecialPlayerMoveSpeed = 15;
    public float SpecialPlayerDashSpeed = 15;
    public float SpecialPlayerFallSpeed = 15;
    public float SpecialPlayerDashFallSpeed = 15;
    public float SpecialPlayerJumpSpeed = 15;
    public float SpecialPlayerDieSpeed = 15;
    public float SpecialPlayerStaggerSpeed = 15;
    public float SpecialPlayerLightAttackSpeed = 15;
    public float SpecialPlayerHeavyAttackSpeed = 15;
    public float SpecialPlayerSpecialAttackSpeed = 15;
    #endregion

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
    public IEnumerator Attack()
    {
        GetComponentInParent<PSMController>().GetComponent<Animator>().runtimeAnimatorController = SpecialThiefOverride;
        DecreaseEnergy = true;
        isSpecialActive = true;
        InitializeSpeedAnimationSpecial();
        yield return new WaitForSeconds(time);
        if (GetComponentInParent<PSMController>().isActiveAndEnabled)
        {
            GetComponentInParent<PSMController>().GetComponent<Animator>().runtimeAnimatorController = OriginalThiefOverride;
        }
        DecreaseEnergy = false;
        GetComponentInParent<PSMController>().CurrentEnergy = (int)GetComponentInParent<PSMController>().CurrentEnergy;
        isSpecialActive = false;
        animator.SetBool("IsAttack", false);
        animator.GetComponentInParent<PSMController>().GetComponent<Animator>().SetBool("PSM-SpecialAttack", false);
        GetComponentInParent<PSMController>().InitializeSpeedAnimation();
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (DecreaseEnergy == true)
        {
            GetComponentInParent<PSMController>().CurrentEnergy -= Time.deltaTime * ((GetComponentInParent<PSMController>().MaxEnergy / time));
            EnergyBar.EBInstance.glowing.GetComponent<Image>().fillAmount -= (Time.deltaTime * ((GetComponentInParent<PSMController>().MaxEnergy / time)) / 100);

        }
    }
}
