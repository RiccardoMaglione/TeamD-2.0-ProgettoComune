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
