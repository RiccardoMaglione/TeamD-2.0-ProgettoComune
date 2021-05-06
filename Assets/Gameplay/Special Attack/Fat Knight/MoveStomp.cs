using UnityEngine;

public class MoveStomp : MonoBehaviour
{
    SpecialAttack specialAttack;
    [SerializeField] float speed;
    Vector2 direction;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            direction = new Vector2(0, 1);
    }

    private void Awake()
    {
        direction = new Vector2(0, -1);
        specialAttack = FindObjectOfType<SpecialAttack>();
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        if(transform.position.y >= 30)
        {
            Destroy(gameObject);
            specialAttack.i++;
            specialAttack.animator.SetTrigger("Repeat");
        }

        if(transform.position.y <= specialAttack.obj[specialAttack.i].transform.position.y)
            direction = new Vector2(0, 1);

        //transform.position = new Vector2(specialAttack.obj[specialAttack.i].transform.position.x, transform.position.y);
    }
}
