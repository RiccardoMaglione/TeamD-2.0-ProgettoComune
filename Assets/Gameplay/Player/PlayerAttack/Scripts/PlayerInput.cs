﻿using UnityEngine;
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

    public float LightTimerActivation;
    public float LightMaxTimerActivation;
    public float HeavyTimerActivation;
    public float HeavyMaxTimerActivation;
    public float SpecialTimerActivation;
    public float SpecialMaxTimerActivation;

    public bool LightActivation;
    public bool HeavyActivation;
    public bool SpecialActivation;

    public bool CooldownAttack;

    public float LightTimerCooldown;
    public float LightMaxTimerCooldown;
    public float HeavyTimerCooldown;
    public float HeavyMaxTimerCooldown;
    public float SpecialTimerCooldown;
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
            LightAttack();
            LightActivation = true;
            //speed = originalSpeed;
        }
        if (Input.GetKeyDown(KeyboardHeavyAttack) && isAttack == false)
        {
            //originalSpeed = speed;
            //speed = 0;
            HeavyAttack();
            HeavyActivation = true;
            //speed = originalSpeed;
        }
        if (Input.GetKeyDown(KeyboardSpecialAttack) && isAttack == false)
        {
            //originalSpeed = speed;
            //speed = 0;
            SpecialAttack();
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
