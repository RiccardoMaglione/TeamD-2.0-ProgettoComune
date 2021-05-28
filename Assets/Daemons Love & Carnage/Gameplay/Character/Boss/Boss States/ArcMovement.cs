using DG.Tweening;
using SwordGame;
using UnityEngine;

public class ArcMovement : MonoBehaviour
{
    Transform player;
    public float height;
    public float parableRaiseSpeed;

    private void Awake()
    {
        player = FindObjectOfType<PSMController>().gameObject.transform;
    }
    public void Arc()
    {
        player = FindObjectOfType<PSMController>().gameObject.transform;

        Attack1_Phase2State.i++;
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
