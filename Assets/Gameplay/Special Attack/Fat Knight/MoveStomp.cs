using UnityEngine;
using SwordGame;

public class MoveStomp : MonoBehaviour
{
    FatKnightSpecialAttack specialAttack;
    [SerializeField] float speed;
    [SerializeField] int damage;

    bool isUp = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyData>().Life -= damage;
            collision.GetComponent<Animator>().SetTrigger("DamageReceived");
            collision.GetComponent<Animator>().SetFloat("Life", collision.GetComponent<EnemyData>().Life);
            if (specialAttack.GetComponentInParent<PSMController>().TypeCharacter == TypePlayer.FatKnight)
            {
                if (AudioManager.instance != null)
                {
                    AudioManager.instance.Play("Sfx_FK_S_atk");
                }
            }
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            if(collision.GetComponentInParent<Boss>().canGetDamage == true)
                collision.GetComponentInParent<Boss>().life -= damage;
        }
    }


    private void Awake()
    {
        specialAttack = FindObjectOfType<FatKnightSpecialAttack>();
    }

    void Update()
    {
        if(isUp == false)
            transform.position = Vector3.MoveTowards(transform.position, specialAttack.enemyList[specialAttack.i].transform.position, speed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 30, transform.position.z), speed * Time.deltaTime);

        if (gameObject.transform.position == specialAttack.enemyList[specialAttack.i].transform.position)
        {
            isUp = true;      
        }

        if (transform.position.y == 30)
        {
            if (specialAttack.i < specialAttack.enemyList.Count - 1)
            {
                specialAttack.i++;
                specialAttack.animator.SetTrigger("Repeat");
            }

            else
            {
                specialAttack.i = 0;                
                specialAttack.animator.SetTrigger("Stop");
            }
            
             Destroy(gameObject);
        }
            
    }
}
