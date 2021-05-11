using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class BoriousKnightSpecialAttack : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float time;
    [SerializeField] float damage;
    [SerializeField] Animator animator;
    [SerializeField] GameObject hitbox;
    [SerializeField] GameObject player;

    public IEnumerator Attack()
    {
        hitbox.SetActive(true);      
        yield return new WaitForSeconds(time);
        hitbox.SetActive(false);
        animator.SetBool("IsAttack", false);
    }

    public void Move()
    {
        player.transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
