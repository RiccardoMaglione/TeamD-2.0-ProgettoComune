using SwordGame;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    [SerializeField] private float HitCounter = 0;
    [SerializeField] GameObject dummyPieces;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<PSMController>().IsLightAttack == true)
        {
            HitCounter++;
            if (HitCounter >= 3)
            {
                this.gameObject.SetActive(false);
                dummyPieces.SetActive(true);
                this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                this.gameObject.AddComponent<Rigidbody2D>();
                Debug.Log("ManichinoMortucciso");
            }
        }
        if (collision.GetComponentInParent<PSMController>().IsHeavyAttack == true)
        {
            HitCounter++;
            if (HitCounter >= 3)
            {
                this.gameObject.SetActive(false);
                dummyPieces.SetActive(true);
                this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                this.gameObject.AddComponent<Rigidbody2D>();
                Debug.Log("ManichinoMortucciso");
            }
        }
        if (collision.GetComponentInParent<PSMController>().IsSpecialAttack == true)
        {
            HitCounter++;
            if (HitCounter >= 3)
            {
                this.gameObject.SetActive(false);
                dummyPieces.SetActive(true);
                this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                this.gameObject.AddComponent<Rigidbody2D>();
                Debug.Log("ManichinoMortucciso");
            }
        }

    }
}
