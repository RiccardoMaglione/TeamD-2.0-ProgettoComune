using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
