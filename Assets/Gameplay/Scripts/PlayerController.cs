using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //gravity of fall

    #region Variables
    float waitTime;
    [Header("Movement Value")]
    [Tooltip("It's an acceleration of player")]
    public float Acceleration;
    [Tooltip("It's a velocity of player on right and left way")]
    public float Speed;
    [Tooltip("It's a max speed of player")]
    public float MaxSpeed;
    [Header("Jump Value")]
    [Tooltip("It's a force of player's jump")]
    public float jumpForce;
    [Tooltip("It's a time of change rotation offset of platform")]
    public float TimeDoublePlatform;
    [Tooltip("")]
    public float fallMultiplier = 2.5f;
    [Tooltip("")]
    public float lowJumpMultiplier = 2f;

    float tempSpeed;
    bool Grounded = true;
    Rigidbody2D rb;
    GameObject TempPlatform;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waitTime = TimeDoublePlatform;
        tempSpeed = Speed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Speed = tempSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Speed = tempSpeed;
        }



        if (Input.GetKey(KeyCode.A))
        {
            Speed = Speed + Acceleration * Time.deltaTime;
            if (Speed >= MaxSpeed)
                Speed = MaxSpeed;
            print(Speed);
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Speed = Speed + Acceleration * Time.deltaTime;
            if (Speed >= MaxSpeed)
                Speed = MaxSpeed;
            print(Speed);
            rb.velocity = new Vector2(Speed + Acceleration * Time.deltaTime, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        #region Jump Section
        if (Input.GetKey(KeyCode.Space) && Grounded == true && rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Grounded = false;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        #endregion

        if (TempPlatform != null)
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