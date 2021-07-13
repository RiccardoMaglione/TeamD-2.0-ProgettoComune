using SwordGame;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 4f;
    public int damage;
    public Rigidbody2D rb;
    public bool reflected;
    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && reflected)
        {
            ColorChangeController colorChangeController = collision.gameObject.GetComponent<ColorChangeController>();
            colorChangeController.isAttacked = true;

            collision.gameObject.GetComponentInChildren<EnemyParticleController>().PlayBlood();

            collision.gameObject.GetComponent<EnemyData>().Life -= 200;
            collision.gameObject.GetComponentInParent<Animator>().SetFloat("Life", collision.gameObject.GetComponent<EnemyData>().Life);
            collision.gameObject.GetComponent<Animator>().SetTrigger("DamageReceived");

            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Player" && PSMController.isBoriousDash == false)
        {
            collision.gameObject.GetComponent<PSMController>().CurrentHealth -= damage;
            GetHitScript.getHitScript.gameObject.SetActive(false);
            GetHitScript.getHitScript.gameObject.SetActive(true);

            if (AudioManager.instance != null)
            {
                switch (collision.gameObject.GetComponent<PSMController>().TypeCharacter)
                {
                    case TypePlayer.FatKnight:
                        AudioManager.instance.Play("Sfx_FK_hit");
                        break;

                    case TypePlayer.BoriousKnight:
                        AudioManager.instance.Play("Sfx_BK_hit");
                        break;

                    case TypePlayer.Babushka:
                        AudioManager.instance.Play("Sfx_B_hit");
                        break;

                    case TypePlayer.Thief:
                        AudioManager.instance.Play("Sfx_T_hit");
                        break;

                    default:
                        break;
                }
            }

            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player" && PSMController.isBoriousDash)
        {
            reflected = true;
            GetComponentInChildren<SpriteRenderer>().flipX = true;
            GetComponentInChildren<SpriteRenderer>().color = Color.magenta;
            gameObject.layer = 11;
        }

        else if (collision.gameObject.tag == "Floor")
        {
            Destroy(this.gameObject);
        }
        Debug.Log("Preso");
    }

    private void Update()
    {
        if (reflected == true)
        {
            transform.position += -transform.right * speed * Time.deltaTime;

        }
        else
        {
            transform.position += transform.right * speed * Time.deltaTime;

        }
    }
}
