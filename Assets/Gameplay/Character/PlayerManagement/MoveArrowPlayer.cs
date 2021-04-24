using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrowPlayer : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        transform.position += transform.right * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
