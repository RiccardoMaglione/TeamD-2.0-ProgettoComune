using UnityEngine;

public class MoveRight : MonoBehaviour
{
    [SerializeField] float speed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
