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
        if (collision.GetComponentInParent<PSMController>() != null)
        {
            var impulse = (Random.Range(-360, +360) * Mathf.Deg2Rad) * this.gameObject.GetComponent<Rigidbody2D>().inertia;
            if (collision.GetComponentInParent<PSMController>().IsLightAttack == true)
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddTorque(impulse, ForceMode2D.Impulse);
            }
            if (collision.GetComponentInParent<PSMController>().IsHeavyAttack == true)
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddTorque(impulse, ForceMode2D.Impulse);
            }
            if (collision.GetComponentInParent<PSMController>().IsSpecialAttack == true)
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddTorque(impulse, ForceMode2D.Impulse);
            }
        }
    }
}
