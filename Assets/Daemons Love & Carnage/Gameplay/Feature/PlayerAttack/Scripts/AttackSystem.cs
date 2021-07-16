using SwordGame;
using UnityEngine;
public class AttackSystem : MonoBehaviour
{
    //[Tooltip("Timer Collider Acceso - Tempo in cui il collider di attacco è attivo")]
    //[SerializeField] float attackTimer;

    //PlayerInput playerInput;

    [SerializeField] float LightDamage;
    [SerializeField] float HeavyDamage;
    [SerializeField] float SpecialDamage;

    [SerializeField] GameObject hitAnimation; //25/03/21

    BasePlayerParticles playerParticles;

    Transform enemyHitTransform;
    public bool OnlyOnce;
    public static bool SoundOnlyOnceEnergy;
    private void Awake()
    {
        playerParticles = this.gameObject.transform.root.GetComponentInChildren<BasePlayerParticles>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Breakable") //10/04
        {
            Knockback.ActiveKnockback = true;//10/04
            if (OnlyOnce == true)
            {
                OnlyOnce = false;
                PlayerPrefs.SetInt("TutorialSkip", 3);
            }

            GameObject go = collision.gameObject;
            playerParticles.PlayHit(go);
        }

        if (collision.gameObject.tag == "Boss" && Boss.instance.canGetDamage == true) //16/04
        {
            GameObject go = collision.gameObject;
            playerParticles.PlayHit(go);

            ColorChangeController colorChangeController = collision.GetComponent<ColorChangeController>();
            colorChangeController.isAttacked = true;

            if (GetComponentInParent<PSMController>().IsLightAttack == true)
            {
                collision.GetComponent<Boss>().life -= LightDamage * collision.GetComponent<Boss>().DMG_Reduction;
                AudioManager.instance.Play("Sfx_boss_damage_light");
                if ((SpecialBabushka.BabuskaSpecial == false) & !(collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Stun") || collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Possession") || collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Death")))
                {
                    if (GetComponentInParent<PSMController>().CurrentEnergy + GetComponentInParent<PSMController>().LightEnergyAmount > GetComponentInParent<PSMController>().MaxEnergy)
                    {
                        GetComponentInParent<PSMController>().CurrentEnergy = GetComponentInParent<PSMController>().MaxEnergy;
                    }
                    else
                    {
                        GetComponentInParent<PSMController>().CurrentEnergy += GetComponentInParent<PSMController>().LightEnergyAmount;
                    }
                }
            }


            if (GetComponentInParent<PSMController>().IsHeavyAttack == true)
            {
                collision.GetComponent<Boss>().life -= HeavyDamage * collision.GetComponent<Boss>().DMG_Reduction;
                AudioManager.instance.Play("Sfx_boss_damage_heavy");
                if ((SpecialBabushka.BabuskaSpecial == false) & !(collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Stun") || collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Possession") || collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Death")))
                {
                    if (GetComponentInParent<PSMController>().CurrentEnergy + GetComponentInParent<PSMController>().HeavyEnergyAmount > GetComponentInParent<PSMController>().MaxEnergy)
                    {
                        GetComponentInParent<PSMController>().CurrentEnergy = GetComponentInParent<PSMController>().MaxEnergy;
                    }
                    else
                    {
                        GetComponentInParent<PSMController>().CurrentEnergy += GetComponentInParent<PSMController>().HeavyEnergyAmount;
                    }
                }
            }
            if (GetComponentInParent<PSMController>().IsSpecialAttack == true)
            {
                if (gameObject.transform.root.GetComponentInChildren<BoriousKnightSpecialAttack>() != null && gameObject.transform.root.GetComponentInChildren<BoriousKnightSpecialAttack>().SpecialActivated == true)
                {
                    collision.GetComponent<Boss>().life -= SpecialDamage * (collision.GetComponent<Boss>().DMG_Reduction / 2);
                }
                else
                    collision.GetComponent<Boss>().life -= SpecialDamage * collision.GetComponent<Boss>().DMG_Reduction;
            }


        }

        //Debug.Log("Passa qui HIT" + collision.name);
        if (collision.gameObject.tag == "Enemy")
        {
            ColorChangeController colorChangeController = collision.GetComponent<ColorChangeController>();
            colorChangeController.isAttacked = true;

            if (hitAnimation != null) //27/03/21
                hitAnimation.SetActive(true); //25/03/21

            collision.GetComponentInChildren<EnemyParticleController>().PlayBlood();

            Knockback.ActiveKnockback = true;

            GameObject go = collision.gameObject;
            playerParticles.PlayHit(go);


            if (GetComponentInParent<PSMController>().IsLightAttack == true)
            {
                if (AudioManager.instance != null)
                {
                    switch (GetComponentInParent<PSMController>().TypeCharacter)
                    {
                        case TypePlayer.FatKnight:
                            AudioManager.instance.Play("Sfx_FK_p_L_atk");
                            break;

                        case TypePlayer.BoriousKnight:
                            AudioManager.instance.Play("Sfx_BK_p_L_atk");
                            break;

                        case TypePlayer.Babushka:
                            if (AudioManager.instance != null && SpecialBabushka.BabuskaSpecial == false)
                            {
                                AudioManager.instance.Play("Sfx_B_L_atk");
                            }
                            else if (AudioManager.instance != null && SpecialBabushka.BabuskaSpecial == true)
                            {
                                AudioManager.instance.Play("Sfx_B_LV_atk");
                            }
                            break;

                        default:
                            break;
                    }
                }

                if (FeedbackManager.instance.isTimeStopped == false)
                {
                    //StartCoroutine(FeedbackManager.instance.StopTimeLight());
                }
                //GetComponentInParent<PSMController>().IsLightAttack = false;
                collision.GetComponent<EnemyData>().Life -= LightDamage * collision.GetComponent<EnemyData>().EnemyCoeffReduceDamageLight;
                collision.GetComponent<EnemyData>().CountHit++;
                collision.GetComponent<EnemyData>().CountPoiseEnemy += GetComponentInParent<PSMController>().ValuePoiseLight;
                collision.GetComponent<Animator>().SetTrigger("DamageReceived");
                //collision.GetComponentInParent<Animator>().SetInteger("Life", collision.GetComponent<EnemyData>().Life);
                collision.GetComponentInParent<Animator>().SetFloat("Life", collision.GetComponent<EnemyData>().Life);
                if (collision.GetComponent<EnemyData>().CountPoiseEnemy >= collision.GetComponent<EnemyData>().MaxCountPoiseEnemy)
                {
                    collision.GetComponentInParent<Animator>().SetBool("IsStagger", true);
                }

                if ((SpecialBabushka.BabuskaSpecial == false) & !(collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Stun") || collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Possession") || collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Death")))
                {
                    if (GetComponentInParent<PSMController>().CurrentEnergy + GetComponentInParent<PSMController>().LightEnergyAmount > GetComponentInParent<PSMController>().MaxEnergy)
                    {
                        GetComponentInParent<PSMController>().CurrentEnergy = GetComponentInParent<PSMController>().MaxEnergy;
                        if (AudioManager.instance != null && SoundOnlyOnceEnergy == false)
                        {
                            AudioManager.instance.Play("Sfx_special_bar_fill");
                            SoundOnlyOnceEnergy = true;
                        }
                    }
                    else
                    {
                        GetComponentInParent<PSMController>().CurrentEnergy += GetComponentInParent<PSMController>().LightEnergyAmount;
                    }
                    //print("Energy" + GetComponentInParent<PSMController>().CurrentEnergy);
                }
            }
            if (GetComponentInParent<PSMController>().IsHeavyAttack == true)
            {
                if (AudioManager.instance != null)
                {
                    switch (GetComponentInParent<PSMController>().TypeCharacter)
                    {
                        case TypePlayer.FatKnight:
                            AudioManager.instance.Play("Sfx_FK_p_H_atk");
                            break;

                        case TypePlayer.BoriousKnight:
                            AudioManager.instance.Play("Sfx_BK_p_H_atk");
                            break;

                        case TypePlayer.Babushka:
                            AudioManager.instance.Play("Sfx_B_H_atk");
                            break;

                        case TypePlayer.Thief:
                            AudioManager.instance.Play("Sfx_T_p_H_atk");
                            break;

                        default:
                            break;
                    }
                }

                if (FeedbackManager.instance.isTimeStopped == false)
                {
                    //StartCoroutine(FeedbackManager.instance.StopTimeHeavy());
                }

                //GetComponentInParent<PSMController>().IsHeavyAttack = false;
                collision.GetComponent<EnemyData>().Life -= HeavyDamage * collision.GetComponent<EnemyData>().EnemyCoeffReduceDamageHeavy;
                collision.GetComponent<EnemyData>().CountHit += GetComponentInParent<PSMController>().ValuePoiseHeavy;
                collision.GetComponent<EnemyData>().CountPoiseEnemy++;
                collision.GetComponent<Animator>().SetTrigger("DamageReceived");
                //collision.GetComponentInParent<Animator>().SetInteger("Life", collision.GetComponent<EnemyData>().Life);
                collision.GetComponentInParent<Animator>().SetFloat("Life", collision.GetComponent<EnemyData>().Life);
                if (collision.GetComponent<EnemyData>().CountPoiseEnemy >= collision.GetComponent<EnemyData>().MaxCountPoiseEnemy)
                {
                    collision.GetComponentInParent<Animator>().SetBool("IsStagger", true);
                }
                //print("Heavy");
                if ((SpecialBabushka.BabuskaSpecial == false) & !(collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Stun") || collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Possession") || collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Death")))
                {
                    if (GetComponentInParent<PSMController>().CurrentEnergy + GetComponentInParent<PSMController>().HeavyEnergyAmount > GetComponentInParent<PSMController>().MaxEnergy)
                    {
                        GetComponentInParent<PSMController>().CurrentEnergy = GetComponentInParent<PSMController>().MaxEnergy;
                        if (AudioManager.instance != null && SoundOnlyOnceEnergy == false)
                        {
                            AudioManager.instance.Play("Sfx_special_bar_fill");
                            SoundOnlyOnceEnergy = true;
                        }
                    }
                    else
                    {
                        GetComponentInParent<PSMController>().CurrentEnergy += GetComponentInParent<PSMController>().HeavyEnergyAmount;
                    }
                    //print("Energy" + GetComponentInParent<PSMController>().CurrentEnergy);
                }
            }
            if (GetComponentInParent<PSMController>().IsSpecialAttack == true)
            {
                //GetComponentInParent<PSMController>().IsSpecialAttack = false;
                collision.GetComponent<EnemyData>().Life -= SpecialDamage * collision.GetComponent<EnemyData>().EnemyCoeffReduceDamageSpecial;
                if (collision.GetComponent<EnemyData>().Life <= 0)
                {
                    FindObjectOfType<ScoreSystem>(true).SpecialType = true;
                }
                collision.GetComponent<EnemyData>().CountHit++;
                collision.GetComponent<EnemyData>().CountPoiseEnemy += GetComponentInParent<PSMController>().ValuePoiseSpecial;
                collision.GetComponent<Animator>().SetTrigger("DamageReceived");
                //collision.GetComponentInParent<Animator>().SetInteger("Life", collision.GetComponent<EnemyData>().Life);
                collision.GetComponentInParent<Animator>().SetFloat("Life", collision.GetComponent<EnemyData>().Life);
                if (collision.GetComponent<EnemyData>().CountPoiseEnemy >= collision.GetComponent<EnemyData>().MaxCountPoiseEnemy)
                {
                    collision.GetComponentInParent<Animator>().SetBool("IsStagger", true);
                }
                print("Special");

                if (!collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Stun") | !collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Possession") | !collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Death"))
                {
                    if (GetComponentInParent<PSMController>().CurrentEnergy + GetComponentInParent<PSMController>().SpecialEnergyAmount > GetComponentInParent<PSMController>().MaxEnergy)
                    {
                        GetComponentInParent<PSMController>().CurrentEnergy = GetComponentInParent<PSMController>().MaxEnergy;
                        if (AudioManager.instance != null && SoundOnlyOnceEnergy == false)
                        {
                            AudioManager.instance.Play("Sfx_special_bar_fill");
                            SoundOnlyOnceEnergy = true;
                        }
                    }
                    else
                    {
                        GetComponentInParent<PSMController>().CurrentEnergy += GetComponentInParent<PSMController>().SpecialEnergyAmount;
                    }
                    print("Energy" + GetComponentInParent<PSMController>().CurrentEnergy);
                }
            }

        }

        if (collision.gameObject.tag == "ImpBoss")
        {
            if (GetComponentInParent<PSMController>().IsLightAttack == true)
            {
                if (AudioManager.instance != null)
                {
                    switch (GetComponentInParent<PSMController>().TypeCharacter)
                    {
                        case TypePlayer.FatKnight:
                            AudioManager.instance.Play("Sfx_FK_p_L_atk");
                            break;

                        case TypePlayer.BoriousKnight:
                            AudioManager.instance.Play("Sfx_BK_p_L_atk");
                            break;

                        case TypePlayer.Babushka:
                            AudioManager.instance.Play("Sfx_B_L_atk");
                            break;

                        default:
                            break;
                    }
                }
            }

            if (GetComponentInParent<PSMController>().IsHeavyAttack == true)
            {
                if (AudioManager.instance != null)
                {
                    switch (GetComponentInParent<PSMController>().TypeCharacter)
                    {
                        case TypePlayer.FatKnight:
                            AudioManager.instance.Play("Sfx_FK_p_H_atk");
                            break;

                        case TypePlayer.BoriousKnight:
                            AudioManager.instance.Play("Sfx_BK_p_H_atk");
                            break;

                        case TypePlayer.Babushka:
                            AudioManager.instance.Play("Sfx_B_H_atk");
                            break;

                        case TypePlayer.Thief:
                            AudioManager.instance.Play("Sfx_T_p_H_atk");
                            break;

                        default:
                            break;
                    }
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Boss")
        {
            GetComponentInParent<PSMController>().IsLightAttack = false;
            GetComponentInParent<PSMController>().IsHeavyAttack = false;
            GetComponentInParent<PSMController>().IsSpecialAttack = false;
        }
        if (hitAnimation != null)    //27/03/21
            hitAnimation.SetActive(false); //25/03/21
    }
    //IEnumerator Attack()
    //{
    //    yield return new WaitForSeconds(attackTimer);
    //    playerInput.CooldownAttack = true;
    //    gameObject.SetActive(false);
    //}
    //
    //
    //void Awake()
    //{
    //    playerInput = FindObjectOfType<PlayerInput>();
    //}
    //
    //void OnEnable()
    //{
    //    StartCoroutine(Attack());
    //}
}
