using UnityEngine;

public class JumpTest : MonoBehaviour
{
    //Rigidbody
    private Rigidbody2D rb;

    public float jumpStrenght;
    private float jumpTimeCounter;
    public float jumpTime;
    public static bool isJumping;
    //public bool isFalling;
    public float fallMultiplier;

    public Transform groundChecker;
    public LayerMask groundLayer;
    public bool grounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        grounded = Physics2D.OverlapBox(groundChecker.position, new Vector2(0.9f, 0.01f), transform.eulerAngles.z, groundLayer);
        GetComponent<Animator>().SetBool("IsJumping", rb.velocity.y > 0);

        //isFalling = rb.velocity.y < 0;
        Jump();
    }

    private void Jump()
    {

        if (Input.GetButtonDown("Jump") && grounded)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = new Vector2(rb.velocity.x, jumpStrenght);
        }

        if (Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpStrenght);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        else
        {
            isJumping = false;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

    }


}
