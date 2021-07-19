using SwordGame;
using UnityEngine;

public class PiecesBehavior : MonoBehaviour
{
    private void OnEnable()
    {
        var impulse = (Random.Range(-360, +360) * Mathf.Deg2Rad) * this.gameObject.GetComponent<Rigidbody2D>().inertia;

        this.gameObject.GetComponent<Rigidbody2D>().AddTorque(impulse, ForceMode2D.Impulse);
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 1, ForceMode2D.Impulse);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<PSMController>() != null && this.gameObject.GetComponent<Rigidbody2D>() != null)
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
