using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 4f;
    public int damage;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        /*if (collision.gameObject.tag == "Floor")
        {
            Destroy(this.gameObject);
        }*/

        Debug.Log("Preso");

        if (collision.gameObject)
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
