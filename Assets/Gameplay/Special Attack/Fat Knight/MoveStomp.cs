using UnityEngine;

public class MoveStomp : MonoBehaviour
{
    SpecialAttack specialAttack;
    [SerializeField] float speed;
    [SerializeField] int damage;
    Vector2 direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            collision.GetComponent<EnemyData>().Life -= damage;
        //direction = new Vector2(0, 1);

    }
    private void Awake()
    {
        direction = new Vector2(0, -1);
        specialAttack = FindObjectOfType<SpecialAttack>();
    }

    void Update()
    {
        if (transform.position.y < specialAttack.enemyList[specialAttack.i].transform.position.y - 1 + 4 && specialAttack.enemyList[specialAttack.i] != null)
            direction = new Vector2(0, 1);
        transform.position = new Vector2(specialAttack.enemyList[specialAttack.i].transform.position.x, transform.position.y);


        transform.Translate(direction * speed * Time.deltaTime);
        if (transform.position.y >= 30)
        {
            Destroy(gameObject);
            specialAttack.i++;
            specialAttack.animator.SetTrigger("Repeat");
        }

    }
}
