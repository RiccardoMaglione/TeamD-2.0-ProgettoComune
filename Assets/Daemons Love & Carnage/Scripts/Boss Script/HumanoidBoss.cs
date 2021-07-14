using UnityEngine;

public class HumanoidBoss : MonoBehaviour
{
    [SerializeField] Animator animator;
    public GameObject blood;
    public GameObject hit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.root.CompareTag("Player") || collision.gameObject.layer == 11)
        {
            int rand = Random.Range(1, 3);
            if (rand == 1)
                animator.SetTrigger("GoToStagger1");

            if (rand == 2)
                animator.SetTrigger("GoToStagger2");

            GetComponent<ButtonMashCounter>().attack++;
            GameObject tempHitEffect = Instantiate(hit.gameObject, transform.position, Quaternion.identity);
            tempHitEffect.GetComponent<ParticleSystem>().Play();

            Destroy(tempHitEffect, 0.5f);

            GameObject tempHitEffect2 = Instantiate(blood.gameObject, transform.position, Quaternion.identity);
            tempHitEffect2.GetComponent<ParticleSystem>().Play();

            Destroy(tempHitEffect2, 0.5f);

            AudioManager.instance.Play("Sfx_boss_imp_hit");

        }
    }
}
