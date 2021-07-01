﻿using SwordGame;
using System.Collections;
using UnityEngine;

public class BoriousKnightSpecialAttack : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float time;
    public float damage;
    [SerializeField] Animator animator;
    [SerializeField] public GameObject hitbox;
    [SerializeField] GameObject player;
    public bool SpecialActivated = false;

    public IEnumerator Attack()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_BK_S_walk");
        }
        hitbox.SetActive(true);
        yield return new WaitForSeconds(time);
        hitbox.SetActive(false);
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Stop("Sfx_BK_S_walk");
        }
        animator.SetBool("IsAttack", false);
    }

    private void Update()
    {
        if (GetComponentInParent<PSMController>().GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Player Die State"))
        {
            hitbox.SetActive(false);
            speed = 0;
            SpecialActivated = false;
        }
    }

    public void Move()
    {
        if (SpecialActivated == true)
        {

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("DPad X") < 0)
                player.transform.rotation = Quaternion.Euler(0, 180, 0);

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("DPad X") > 0)
                player.transform.rotation = Quaternion.Euler(0, 0, 0);


            if (player.transform.rotation.eulerAngles.y == 180)
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(-(speed * Time.deltaTime), player.GetComponent<Rigidbody2D>().velocity.y);

            if (player.transform.rotation.eulerAngles.y == 0)
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Time.deltaTime, player.GetComponent<Rigidbody2D>().velocity.y);
        }

        //player.transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
