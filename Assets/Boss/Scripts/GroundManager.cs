using DG.Tweening;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public static GroundManager instance;
    public GameObject ground;
    public float speed;

    public float step;

    public void Smash()
    {
        ground.transform.DOMoveY(ground.transform.position.y - step, speed * Time.deltaTime);
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
