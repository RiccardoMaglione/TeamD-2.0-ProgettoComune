using SwordGame;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    private bool alreadyDamaged;
    private float canDamageTimerFloat;
    public float canDamageTimer = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && alreadyDamaged == false)
        {
            collision.GetComponent<PSMController>().CurrentHealth -= damage;
            alreadyDamaged = true;
            GetHitScript.getHitScript.gameObject.SetActive(false);
            GetHitScript.getHitScript.gameObject.SetActive(true);

        }

        // Debug.LogWarning(damage+" WAVE DAMAGE");

        if (collision.gameObject.tag == "Wall")
            Destroy(gameObject);
    }


    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (alreadyDamaged == true)
        {
            canDamageTimerFloat += Time.deltaTime;
        }
        if (canDamageTimerFloat >= canDamageTimer)
        {
            alreadyDamaged = false;
            canDamageTimerFloat = 0;
        }

    }
}
