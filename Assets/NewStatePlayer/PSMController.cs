using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PSMStructMovement
{
    [Tooltip("It's an acceleration of player")]
    public float Acceleration;
    [Tooltip("It's a velocity of player on right and left way")]
    public float Speed;
    [Tooltip("It's a max speed of player")]
    public float MaxSpeed;
}

[System.Serializable]
public struct PSMStructJump
{
    [Tooltip("It's a force of player's jump")]
    public float InitialJumpForce;
    [Tooltip("It's a force of player's jump")]
    public float jumpForce;
    [Tooltip("It's value of gravity fall")]
    public float fallMultiplier;
    [Tooltip("It's a value for progressive jump")]
    public float lowJumpMultiplier;
}
public class PSMController : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D RB2D;
    public PSMStructMovement ValueMovement;
    public PSMStructJump ValueJump;

    #region Variables Dash
    [HideInInspector] public float TimerDash = 0;
    public float LimitTimerDash = 0.2f;
    [HideInInspector] public float TimerDashCooldown = 0;
    public float LimiTimerDashCooldown = 1f;
    /*[HideInInspector]*/ public bool CanDashRight = false;
    /*[HideInInspector]*/ public bool CanDashLeft = false;
    /*[HideInInspector]*/ public bool CooldownDashDirectional = false;
    #endregion
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        DashCooldownState();
    }

    public void DashCooldownState()
    {
        if (CooldownDashDirectional == true)
        {
            Debug.Log("PlayerState - E' nel cooldown dash");
            TimerDashCooldown += Time.deltaTime;
            if (TimerDashCooldown >= LimiTimerDashCooldown)
            {
                //Resetta cose ma devo essere già fuori dallo stato
                CanDashRight = false;                   //Resetta la direzione del dash
                CanDashLeft = false;                    //Resetta la direzione del dash
                TimerDash = 0;                          //Resetta il timer della durata del dash
                TimerDashCooldown = 0;                  //Resetta il timer del cooldown
                CooldownDashDirectional = false;        //Mi permette di ritornare in dash
            }

        }
    }

    public void CalculateSpeed()
    {
        ValueMovement.Speed = ValueMovement.Speed + ValueMovement.Acceleration * Time.deltaTime;
        if (ValueMovement.Speed >= ValueMovement.MaxSpeed)
            ValueMovement.Speed = ValueMovement.MaxSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            GetComponent<Animator>().SetBool("PSM-IsGrounded", true);   //Setto PSM-IsGrounded = true quando tocca il pavimento
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            GetComponent<Animator>().SetBool("PSM-CanDashInAir", false); //Permette di rientrare in dash
        }
    }
}


//Sarebbe da velocizzare il passaggio a jump