using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordGame
{
    [System.Serializable]
    public struct StructMovement
    {
        [Tooltip("It's an acceleration of player")]
        public float Acceleration;
        [Tooltip("It's a velocity of player on right and left way")]
        public float Speed;
        [Tooltip("It's a max speed of player")]
        public float MaxSpeed;
    }
    
    [System.Serializable]
    public struct StructJump
    {
        [Tooltip("It's a force of player's jump")]
        public float jumpForce;
        [Tooltip("It's value of gravity fall")]
        public float fallMultiplier;
        [Tooltip("It's a value for progressive jump")]
        public float lowJumpMultiplier;
    }
    
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]

    public class PlayerController : MonoBehaviour
    {
        #region Variables
        public StructMovement ValueMovement;
        public StructJump ValueJump;

        bool Grounded = true;
        float waitTime;
        float tempSpeed;
        [Tooltip("It's a time of change rotation offset of platform")]
        public float TimeDoublePlatform;
        
        Rigidbody2D rb;
        GameObject TempPlatform;

        bool CanDashLeft = false;
        bool CanDashRight = false;
        [Tooltip("Value of start of timer for dash")]
        public float TimerDash = 0;
        [Tooltip("Value for limit timer of dash")]
        public float LimitTimerDash = 5;
        #endregion
        
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            waitTime = TimeDoublePlatform;
            tempSpeed = ValueMovement.Speed;
        }

        void Update()
        {
            PlayerMovement();
            PlayerJump();
            ResetPlatform();
            Dash();
        }

        #region Player - Move and Jump and Dash
        public void PlayerMovement()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                ValueMovement.Speed = tempSpeed;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                ValueMovement.Speed = tempSpeed;
            }

            if (Input.GetKey(KeyCode.A))
            {
                CalculateSpeed();
                rb.velocity = new Vector2(-ValueMovement.Speed, rb.velocity.y);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                CalculateSpeed();
                rb.velocity = new Vector2(ValueMovement.Speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
        public void PlayerJump()
        {
            if (Input.GetKey(KeyCode.Space) && Grounded == true && rb.velocity.y == 0)
            {
                rb.AddForce(Vector2.up * ValueJump.jumpForce, ForceMode2D.Impulse);
                Grounded = false;
            }
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (ValueJump.fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (ValueJump.lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
        public void CalculateSpeed()
        {
            ValueMovement.Speed = ValueMovement.Speed + ValueMovement.Acceleration * Time.deltaTime;
            if (ValueMovement.Speed >= ValueMovement.MaxSpeed)
                ValueMovement.Speed = ValueMovement.MaxSpeed;
        }
        public void ResetPlatform()
        {
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
        public void Dash()          //Se il timerdash è maggiore del limit, dasha solo quando schiaccio e non perpetua
        {
            if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftControl) || (Input.GetKey(KeyCode.RightControl))) && CanDashRight == false)
            {
                CanDashLeft = true;
            }
            if(CanDashLeft == true)
            {
                rb.velocity = new Vector2(-ValueMovement.Speed * 5, rb.velocity.y);
                TimerDash += Time.deltaTime;
                if(TimerDash >= LimitTimerDash)
                {
                    CanDashLeft = false;
                    TimerDash = 0;
                    //StartCoroutine(CooldownDash());
                }
            }

            if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftControl) || (Input.GetKey(KeyCode.RightControl))) && CanDashLeft == false)
            {
                CanDashRight = true;
            }
            if (CanDashRight == true)
            {
                rb.velocity = new Vector2(ValueMovement.Speed * 5, rb.velocity.y);
                TimerDash += Time.deltaTime;
                if (TimerDash >= LimitTimerDash)
                {
                    CanDashRight = false;
                    TimerDash = 0;
                    //StartCoroutine(CooldownDash());
                }
            }
        }

        //public IEnumerator CooldownDash()
        //{
        //    yield return new WaitForSeconds(TimerCooldownDash);
        //    CanDashLeft = false;
        //    CanDashRight = false;
        //    TimerDash = 0;
        //}
        #endregion

        #region Collision
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
        #endregion
    }
}
