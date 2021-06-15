using UnityEngine;

public class MoveStomp : MonoBehaviour
{
    FatKnightSpecialAttack specialAttack;
    [SerializeField] float speed;
    [SerializeField] int damage;
    //Vector2 direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyData>().Life -= damage;
            collision.GetComponent<Animator>().SetTrigger("DamageReceived");
            collision.GetComponent<Animator>().SetFloat("Life", collision.GetComponent<EnemyData>().Life);
        }
    }
    private void Awake()
    {
        specialAttack = FindObjectOfType<FatKnightSpecialAttack>();
    }

    void Update()
    {
        this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, specialAttack.enemyList[specialAttack.i].transform.position, speed * Time.deltaTime);
        if (this.gameObject.transform.position == specialAttack.enemyList[specialAttack.i].transform.position)
        {
            //Destroy(this.gameObject);
            specialAttack.animator.SetTrigger("Repeat");
        }
    }
}
