using SwordGame;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    [SerializeField] private float HitCounter = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<PSMController>().IsLightAttack == true)
        {
            HitCounter++;
            if (HitCounter == 3)
            {
                this.gameObject.layer = 8;
                this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                this.gameObject.AddComponent<Rigidbody2D>();
                Debug.Log("ManichinoMortucciso");
            }
        }

    }
}
