using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    //velocita del giocatore
    //[SerializeField] float speed;

    //velocita originale del giocatore
    //float originalSpeed;

    [SerializeField] GameObject lightAttackCollider;
    [SerializeField] GameObject heavyAttackCollider;
    [SerializeField] GameObject specialAttackCollider;
    
    [Header("KEYBOARD INPUTS")]
    [SerializeField] KeyCode KeyboardLightlAttack;
    [SerializeField] KeyCode KeyboardHeavyAttack;
    [SerializeField] KeyCode KeyboardSpecialAttack;

    [HideInInspector] public bool isAttack = false;

    Rigidbody rb;
 
    void LightAttack()
    {
        lightAttackCollider.SetActive(true);
        isAttack = true;
    }

    void HeavyAttack()
    {
        heavyAttackCollider.SetActive(true);
        isAttack = true;
    }

    void SpecialAttack()
    {
        specialAttackCollider.SetActive(true);
        isAttack = true;
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
            //speed = originalSpeed;
        }

        if (Input.GetKeyDown(KeyboardHeavyAttack) && isAttack == false)
        {
            //originalSpeed = speed;
            //speed = 0;
            HeavyAttack();
            //speed = originalSpeed;
        }

        if (Input.GetKeyDown(KeyboardSpecialAttack) && isAttack == false)
        {
            //originalSpeed = speed;
            //speed = 0;
            SpecialAttack();
            //speed = originalSpeed;
        }
    }
}
