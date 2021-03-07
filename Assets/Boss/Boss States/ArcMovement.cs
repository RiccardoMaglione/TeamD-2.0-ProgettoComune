using DG.Tweening;
using UnityEngine;

public class ArcMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    public float height;

    public void Arc()
    {
        if (transform.position.x < player.position.x)
        {
            transform.DOMoveX(transform.position.x + (-(transform.position.x - player.position.x)), 1);
            transform.DOMoveY(height, 0.5f);
        }

        if (transform.position.x >= player.position.x)
        {
            transform.DOMoveX(transform.position.x - (transform.position.x - player.position.x), 1);
            transform.DOMoveY(height, 0.5f);
        }
    }
}
