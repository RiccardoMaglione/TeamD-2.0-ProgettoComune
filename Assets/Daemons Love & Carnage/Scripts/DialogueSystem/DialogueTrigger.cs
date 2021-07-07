using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] Animator animator;
    public static bool bossDialogueTrigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            bossDialogueTrigger = true;
            animator.SetTrigger("EnterTrigger");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Destroy(this.gameObject);
    }
}
