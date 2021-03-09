using UnityEngine;
using System.Collections;
using SwordGame;
public class PlayerInput : MonoBehaviour
{
    //velocita del giocatore
    //[SerializeField] float speed;

    //velocita originale del giocatore
    //float originalSpeed;

    [SerializeField] public GameObject lightAttackCollider;
    [SerializeField] public GameObject heavyAttackCollider;
    [SerializeField] public GameObject specialAttackCollider;
    
    [Header("KEYBOARD INPUTS")]
    [SerializeField] public KeyCode KeyboardLightlAttack;
    [SerializeField] public KeyCode KeyboardHeavyAttack;
    [SerializeField] public KeyCode KeyboardSpecialAttack;

    [HideInInspector] public bool isAttack = false;

    Rigidbody rb;


    public bool isLightAttack;
    public bool isHeavyAttack;
    public bool isSpecialAttack;

    [ReadOnly] public float LightTimerActivation;
    [Tooltip("Pre Attack Leggero - Indica il tempo precedente all'attivazione del collider")]
    public float LightMaxTimerActivation;
    [ReadOnly] public float HeavyTimerActivation;
    [Tooltip("Pre Attack Pesante - Indica il tempo precedente all'attivazione del collider")]
    public float HeavyMaxTimerActivation;
    [ReadOnly] public float SpecialTimerActivation;
    [Tooltip("Pre Attack Speciale - Indica il tempo precedente all'attivazione del collider")]
    public float SpecialMaxTimerActivation;

    public bool LightActivation;
    public bool HeavyActivation;
    public bool SpecialActivation;

    public bool CooldownAttack;

    [ReadOnly] public float LightTimerCooldown;
    [Tooltip("Cooldown Leggero - Avviene quando il collider dell'attacco leggero viene disattivo, indica il tempo per ripoter premere l'input")]
    public float LightMaxTimerCooldown;
    [ReadOnly] public float HeavyTimerCooldown;
    [Tooltip("Cooldown Pesante - Avviene quando il collider dell'attacco pesante viene disattivo, indica il tempo per ripoter premere l'input")]
    public float HeavyMaxTimerCooldown;
    [ReadOnly] public float SpecialTimerCooldown;
    [Tooltip("Cooldown Speciale - Avviene quando il collider dell'attacco speciale viene disattivo, indica il tempo per ripoter premere l'input")]
    public float SpecialMaxTimerCooldown;

    void LightAttack()
    {
        if(lightAttackCollider != null)
            lightAttackCollider.SetActive(true);
        isAttack = true;
        isLightAttack = true;
        isHeavyAttack = false;
        isSpecialAttack = false;
    }

    void HeavyAttack()
    {
        if (heavyAttackCollider != null)
            heavyAttackCollider.SetActive(true);
        isAttack = true;
        isLightAttack = false;
        isHeavyAttack = true;
        isSpecialAttack = false;
    }

    void SpecialAttack()
    {
        if (specialAttackCollider != null)
            specialAttackCollider.SetActive(true);
        isAttack = true;
        isLightAttack = false;
        isHeavyAttack = false;
        isSpecialAttack = true;
    }


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GetComponent<PlayerController>().CanDashLeft == false && GetComponent<PlayerController>().CanDashRight == false)
        {
            if (Input.GetKeyDown(KeyboardLightlAttack) && isAttack == false)
            {
                if(/*GetComponent<Animator>().GetBool("PlayerCanAttack") == true*/ GetComponent<Animator>().GetBool("PSM-CanAttack") == true)
                {
                    //GetComponent<Animator>().SetBool("PlayerCanAttack", false);
                    GetComponent<Animator>().SetBool("PSM-CanAttack", true);
                    //originalSpeed = speed;
                    //speed = 0;
                    //LightAttack();
                    //GetComponentInParent<PlayerController>().isInAttack = true;
                    LightActivation = true;
                    //GetComponent<Animator>().SetBool("PlayerAttack", true);
                    //GetComponent<Animator>().SetBool("PlayerLightAttack", true);

                    GetComponent<Animator>().SetBool("PSM-Attack", true);
                    GetComponent<Animator>().SetBool("PSM-LightAttack", true);

                    //speed = originalSpeed;
                }
            }
            if (Input.GetKeyDown(KeyboardHeavyAttack) && isAttack == false)
            {
                if (/*GetComponent<Animator>().GetBool("PlayerCanAttack") == true*/GetComponent<Animator>().GetBool("PSM-CanAttack") == true)
                {
                    //GetComponent<Animator>().SetBool("PlayerCanAttack", false);
                    GetComponent<Animator>().SetBool("PSM-CanAttack", true);
                    //originalSpeed = speed;
                    //speed = 0;
                    //HeavyAttack();
                    //GetComponentInParent<PlayerController>().isInAttack = true;
                    HeavyActivation = true;
                    //GetComponent<Animator>().SetBool("PlayerAttack", true);
                    //GetComponent<Animator>().SetBool("PlayerHeavyAttack", true);


                    GetComponent<Animator>().SetBool("PSM-Attack", true);
                    GetComponent<Animator>().SetBool("PSM-HeavyAttack", true);
                    //speed = originalSpeed;
                }
            }
            if (Input.GetKeyDown(KeyboardSpecialAttack) && isAttack == false)
            {
                if (/*GetComponent<Animator>().GetBool("PlayerCanAttack") == true*/GetComponent<Animator>().GetBool("PSM-CanAttack") == true)
                {
                    //GetComponent<Animator>().SetBool("PlayerCanAttack", false);
                    GetComponent<Animator>().SetBool("PSM-CanAttack", true);
                    //originalSpeed = speed;
                    //speed = 0;
                    //SpecialAttack();
                    //GetComponentInParent<PlayerController>().isInAttack = true;
                    SpecialActivation = true;
                    //GetComponent<Animator>().SetBool("PlayerAttack", true);
                    //GetComponent<Animator>().SetBool("PlayerSpecialAttack", true);
                    GetComponent<Animator>().SetBool("PSM-Attack", true);
                    GetComponent<Animator>().SetBool("PSM-SpecialAttack", true);
                    //speed = originalSpeed;
                }
            }
        }

            LightTimer();
            HeavyTimer();
            SpecialTimer();
    }


    public void LightTimer()
    {
        if (LightActivation == true && CooldownAttack == false)
        {
            LightTimerActivation += Time.deltaTime;
            if (LightTimerActivation >= LightMaxTimerActivation)
            {
                LightAttack();
                LightTimerActivation = 0;
                LightActivation = false;
                //GetComponent<Animator>().SetBool("PlayerLightAttack", false);
                GetComponent<Animator>().SetBool("PSM-LightAttack", false);
            }
        }
        if (CooldownAttack == true)
        {
            LightTimerCooldown += Time.deltaTime;
            if(LightTimerCooldown >= LightMaxTimerCooldown)
            {
                isAttack = false;
                CooldownAttack = false;
            }
        }
    }
    public void HeavyTimer()
    {
        if (HeavyActivation == true && CooldownAttack == false)
        {
            HeavyTimerActivation += Time.deltaTime;
            if (HeavyTimerActivation >= HeavyMaxTimerActivation)
            {
                HeavyAttack();
                HeavyTimerActivation = 0;
                HeavyActivation = false;
                //GetComponent<Animator>().SetBool("PlayerHeavyAttack", false);
                GetComponent<Animator>().SetBool("PSM-HeavyAttack", false);
            }
        }
        if (CooldownAttack == true)
        {
            HeavyTimerCooldown += Time.deltaTime;
            if (HeavyTimerCooldown >= HeavyMaxTimerCooldown)
            {
                isAttack = false;
                CooldownAttack = false;
            }
        }
    }
    public void SpecialTimer()
    {
        if (SpecialActivation == true && CooldownAttack == false)
        {
            SpecialTimerActivation += Time.deltaTime;
            if (SpecialTimerActivation >= SpecialMaxTimerActivation)
            {
                SpecialAttack();
                SpecialTimerActivation = 0;
                SpecialActivation = false;
                //GetComponent<Animator>().SetBool("PlayerSpecialAttack", false);
                GetComponent<Animator>().SetBool("PSM-SpecialAttack", false);
            }
        }
        if (CooldownAttack == true)
        {
            SpecialTimerCooldown += Time.deltaTime;
            if (SpecialTimerCooldown >= SpecialMaxTimerCooldown)
            {
                isAttack = false;
                CooldownAttack = false;
            }
        }
    } //Forse puoi viene sostituito dalla energia
}
