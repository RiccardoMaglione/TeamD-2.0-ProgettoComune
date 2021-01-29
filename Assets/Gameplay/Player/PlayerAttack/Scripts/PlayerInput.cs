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
        if (Input.GetKeyDown(KeyboardLightlAttack) && isAttack == false)
        {
            //originalSpeed = speed;
            //speed = 0;
            //LightAttack();
            LightActivation = true;
            //speed = originalSpeed;
        }
        if (Input.GetKeyDown(KeyboardHeavyAttack) && isAttack == false)
        {
            //originalSpeed = speed;
            //speed = 0;
            //HeavyAttack();
            HeavyActivation = true;
            //speed = originalSpeed;
        }
        if (Input.GetKeyDown(KeyboardSpecialAttack) && isAttack == false)
        {
            //originalSpeed = speed;
            //speed = 0;
            //SpecialAttack();
            SpecialActivation = true;
            //speed = originalSpeed;
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
