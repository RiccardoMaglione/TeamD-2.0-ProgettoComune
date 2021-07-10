using SwordGame;
using UnityEngine;

public class TrapSpike : MonoBehaviour
{
    [Tooltip("conto alla rovescia per il ricaricamento")]
    [ReadOnly]
    public float cooldownTrap = 0f;

    [Tooltip("tempo ricarica della trappola")]
    public float rechargeTime;

    public bool cooldownIsActive;
    public int damageToPlayer;
    public int damageToEnemy;


    private void Start()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && cooldownIsActive == false && cooldownTrap <= 0f)
        {
            collision.gameObject.GetComponent<PSMController>().CurrentHealth -= damageToPlayer;
            GetHitScript.getHitScript.gameObject.SetActive(false);
            GetHitScript.getHitScript.gameObject.SetActive(true);

            if (AudioManager.instance != null)
            {
                switch (collision.gameObject.GetComponent<PSMController>().TypeCharacter)
                {
                    case TypePlayer.FatKnight:
                        AudioManager.instance.Play("Sfx_FK_hit");
                        break;

                    case TypePlayer.BoriousKnight:
                        AudioManager.instance.Play("Sfx_BK_hit");
                        break;

                    case TypePlayer.Babushka:
                        AudioManager.instance.Play("Sfx_B_hit");
                        break;

                    case TypePlayer.Thief:
                        AudioManager.instance.Play("Sfx_T_hit");
                        break;

                    default:
                        break;
                }
            }

                cooldownIsActive = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyData>().Life -= damageToEnemy;
            collision.GetComponent<Animator>().SetTrigger("DamageReceived");
            collision.GetComponentInParent<Animator>().SetFloat("Life", collision.GetComponent<EnemyData>().Life);

        }

    }

    void Update()
    {
        if (cooldownIsActive)
        {
            cooldownTrap += Time.deltaTime;

            if (cooldownTrap >= rechargeTime)
            {
                cooldownIsActive = false;
                cooldownTrap = cooldownTrap = 0f;
            }
        }
    }
}
