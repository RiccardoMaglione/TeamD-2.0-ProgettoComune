using SwordGame;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [SerializeField] private float HitCounter = 0;
    [SerializeField] GameObject Pieces;

    public bool enemyCounterIncreased = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<PSMController>().IsLightAttack == true)
        {
            HitCounter++;
            if (HitCounter >= 3)
            {
                if (enemyCounterIncreased == false)
                {
                    FindObjectOfType<KilledEnemyCounter>().killedEnemyCounter++;
                    enemyCounterIncreased = true;
                }

                this.gameObject.SetActive(false);
                Pieces.SetActive(true);
                this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                this.gameObject.AddComponent<Rigidbody2D>();
                //Debug.Log("Manichino Mortucciso");
            }
        }
        if (collision.GetComponentInParent<PSMController>().IsHeavyAttack == true)
        {
            HitCounter++;
            if (HitCounter >= 3)
            {
                if (enemyCounterIncreased == false)
                {
                    FindObjectOfType<KilledEnemyCounter>().killedEnemyCounter++;
                    enemyCounterIncreased = true;
                }

                this.gameObject.SetActive(false);
                Pieces.SetActive(true);
                this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                this.gameObject.AddComponent<Rigidbody2D>();
                //Debug.Log("ManichinoMortucciso");
            }
        }
        if (collision.GetComponentInParent<PSMController>().IsSpecialAttack == true)
        {
            HitCounter++;
            if (HitCounter >= 3)
            {
                if (enemyCounterIncreased == false)
                {
                    FindObjectOfType<KilledEnemyCounter>().killedEnemyCounter++;
                    enemyCounterIncreased = true;
                }

                this.gameObject.SetActive(false);
                Pieces.SetActive(true);
                this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                this.gameObject.AddComponent<Rigidbody2D>();
                Debug.Log("ManichinoMortucciso");
            }
        }

    }
}
