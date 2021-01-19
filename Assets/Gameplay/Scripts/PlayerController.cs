using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables and Properties
    public float speed;
    public float jumpForce;
    public bool Grounded = true;
    Rigidbody2D rb;
    public float TimeDoublePlatform;
    float waitTime;
    public GameObject TempPlatform;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waitTime = TimeDoublePlatform;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space) && Grounded == true && rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Grounded = false;
        }
        if(TempPlatform != null)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                TempPlatform.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
                TempPlatform = null;
                waitTime = TimeDoublePlatform;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Grounded = true;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.S))
        {
            collision.gameObject.GetComponent<PlatformEffector2D>().rotationalOffset = 180;
            TempPlatform = collision.gameObject;
        }
    }
}