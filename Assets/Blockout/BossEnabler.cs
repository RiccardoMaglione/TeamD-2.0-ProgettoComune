using UnityEngine;

public class BossEnabler : MonoBehaviour
{
    [SerializeField] GameObject boss;
    public float activationTime = 0.2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invoke("ActiveBoss", activationTime);
        }
    }

    public void ActiveBoss()
    {
        boss.SetActive(true);
    }
}
