using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    [SerializeField] float speed;
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
