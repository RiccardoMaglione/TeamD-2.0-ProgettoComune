using SwordGame;
using UnityEngine;

public class PiecesBehavior : MonoBehaviour
{
    private void OnEnable()
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddTorque(3);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<PSMController>().IsLightAttack == true)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddTorque(3);
        }
        if (collision.GetComponentInParent<PSMController>().IsHeavyAttack == true)
        {
        }
        if (collision.GetComponentInParent<PSMController>().IsSpecialAttack == true)
        {
        }

    }
}
