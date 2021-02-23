using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;
public class Knockback : MonoBehaviour
{
    public Rigidbody2D RB2D;
    public int thrust;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            RB2D.AddForce(transform.right * thrust, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            print("111Trigger");
            RB2D = collision.GetComponent<Rigidbody2D>();
        }
    }
}
