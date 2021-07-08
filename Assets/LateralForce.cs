using SwordGame;
using UnityEngine;
public class LateralForce : MonoBehaviour
{
    public bool lateralLeft;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PSMController.disableAllInput = true;
            Invoke("RegaingControls", 1.5f);
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            if (lateralLeft)
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(900, 600));
            else
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-900, 600));
        }
    }

    private void RegaingControls()
    {
        PSMController.disableAllInput = false;
    }

}
