using DG.Tweening;
using UnityEngine;

public class ArcMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    public float height;
    public float parableRaiseSpeed;

    public CameraShake cameraShake;

    public void Arc()
    {
        if (transform.position.x < player.position.x)
        {
            transform.DOMoveX(transform.position.x + (-(transform.position.x - player.position.x)) + 2, parableRaiseSpeed);
            transform.DOMoveY(height, parableRaiseSpeed / 2);
        }

        if (transform.position.x >= player.position.x)
        {
            transform.DOMoveX(transform.position.x - (transform.position.x - player.position.x) - 2, parableRaiseSpeed);
            transform.DOMoveY(height, parableRaiseSpeed / 2);
        }
    }
}
