using SwordGame;
using System.Collections;
using UnityEngine;
public class AttackSystem : MonoBehaviour
{
    //[Tooltip("Timer Collider Acceso - Tempo in cui il collider di attacco è attivo")]
    //[SerializeField] float attackTimer;

    //PlayerInput playerInput;

    [SerializeField] int LightDamage;
    [SerializeField] int HeavyDamage;
    [SerializeField] int SpecialDamage;

    [SerializeField] float stopTime;

    [SerializeField] GameObject hitAnimation; //25/03/21

    public IEnumerator StartTimeAgain()
    {
        Debug.LogError("stop");
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(stopTime);
        Time.timeScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Passa qui HIT" + collision.name);
        if (collision.gameObject.tag == "Enemy")
        {
            //StartCoroutine("StartTimeAgain");
            if(hitAnimation != null) //27/03/21
                hitAnimation.SetActive(true); //25/03/21
            if(collision.gameObject.GetComponent<EnemyData>().bloodPS != null)//27/03/21
                collision.gameObject.GetComponent<EnemyData>().bloodPS.Play();//25/03/21

            Knockback.ActiveKnockback = true;
            if (GetComponentInParent<PSMController>().IsLightAttack == true)
            {
                //GetComponentInParent<PSMController>().IsLightAttack = false;
                collision.GetComponent<EnemyData>().Life -= LightDamage;
                collision.GetComponent<EnemyData>().CountHit++;
                collision.GetComponent<EnemyData>().CountPoiseEnemy++;
                collision.GetComponent<Animator>().SetTrigger("DamageReceived");
                collision.GetComponentInParent<Animator>().SetInteger("Life", collision.GetComponent<EnemyData>().Life);
                if (collision.GetComponent<EnemyData>().CountPoiseEnemy >= collision.GetComponent<EnemyData>().MaxCountPoiseEnemy)
                {
                    collision.GetComponentInParent<Animator>().SetBool("PSM-IsStagger", true);
                }
                print("Light");
                GetComponentInParent<PSMController>().CurrentEnergy += GetComponentInParent<PSMController>().LightEnergyAmount;
                print("Energy" + GetComponentInParent<PSMController>().CurrentEnergy);
            }
            if (GetComponentInParent<PSMController>().IsHeavyAttack == true)
            {
                //GetComponentInParent<PSMController>().IsHeavyAttack = false;
                collision.GetComponent<EnemyData>().Life -= HeavyDamage;
                collision.GetComponent<EnemyData>().CountHit++;
                collision.GetComponent<EnemyData>().CountPoiseEnemy++;
                collision.GetComponent<Animator>().SetTrigger("DamageReceived");
                collision.GetComponentInParent<Animator>().SetInteger("Life", collision.GetComponent<EnemyData>().Life);
                if (collision.GetComponent<EnemyData>().CountPoiseEnemy >= collision.GetComponent<EnemyData>().MaxCountPoiseEnemy)
                {
                    collision.GetComponentInParent<Animator>().SetBool("PSM-IsStagger", true);
                }
                print("Heavy");
                GetComponentInParent<PSMController>().CurrentEnergy += GetComponentInParent<PSMController>().HeavyEnergyAmount;
                print("Energy" + GetComponentInParent<PSMController>().CurrentEnergy);
            }
            if (GetComponentInParent<PSMController>().IsSpecialAttack == true)
            {
                //GetComponentInParent<PSMController>().IsSpecialAttack = false;
                collision.GetComponent<EnemyData>().Life -= SpecialDamage;
                if (collision.GetComponent<EnemyData>().Life <= 0)
                {
                    FindObjectOfType<ScoreSystem>(true).SpecialType = true;
                }
                collision.GetComponent<EnemyData>().CountHit++;
                collision.GetComponent<EnemyData>().CountPoiseEnemy++;
                collision.GetComponent<Animator>().SetTrigger("DamageReceived");
                collision.GetComponentInParent<Animator>().SetInteger("Life", collision.GetComponent<EnemyData>().Life);
                if (collision.GetComponent<EnemyData>().CountPoiseEnemy >= collision.GetComponent<EnemyData>().MaxCountPoiseEnemy)
                {
                    collision.GetComponentInParent<Animator>().SetBool("PSM-IsStagger", true);
                }
                print("Special");
                GetComponentInParent<PSMController>().CurrentEnergy += GetComponentInParent<PSMController>().SpecialEnergyAmount;
                print("Energy" + GetComponentInParent<PSMController>().CurrentEnergy);
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponentInParent<PSMController>().IsLightAttack = false;
        GetComponentInParent<PSMController>().IsHeavyAttack = false;
        GetComponentInParent<PSMController>().IsSpecialAttack = false;

        if(hitAnimation != null)    //27/03/21
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
