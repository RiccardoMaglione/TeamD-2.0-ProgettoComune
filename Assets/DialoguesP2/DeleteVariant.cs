using UnityEngine;

public class DeleteVariant : MonoBehaviour
{
    [SerializeField] GameObject otherVariantTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            otherVariantTrigger.SetActive(false);
        }
    }
}
