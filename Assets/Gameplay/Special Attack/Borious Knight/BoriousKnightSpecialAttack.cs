using SwordGame;
using System.Collections;
using UnityEngine;

public class BoriousKnightSpecialAttack : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float time;
    public float damage;
    [SerializeField] Animator animator;
    [SerializeField] GameObject hitbox;
    [SerializeField] GameObject player;
    public bool SpecialActivated = false;

    public IEnumerator Attack()
    {
        hitbox.SetActive(true);
        yield return new WaitForSeconds(time);
        hitbox.SetActive(false);
        animator.SetBool("IsAttack", false);
    }

    private void Update()
    {
        if (GetComponentInParent<PSMController>().GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Player Die State"))
        {
            hitbox.SetActive(false);
            speed = 0;
        }
    }

    public void Move()
    {
        if (SpecialActivated == true)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                player.transform.rotation = Quaternion.Euler(0, 180, 0);

            if (Input.GetKey(KeyCode.RightArrow))
                player.transform.rotation = Quaternion.Euler(0, 0, 0);


            if (player.transform.rotation.eulerAngles.y == 180)
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(-(speed * Time.deltaTime), player.GetComponent<Rigidbody2D>().velocity.y);

            if (player.transform.rotation.eulerAngles.y == 0)
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Time.deltaTime, player.GetComponent<Rigidbody2D>().velocity.y);
        }

        //player.transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
