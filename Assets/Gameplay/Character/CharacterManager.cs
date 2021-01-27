using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Character")]
public class CharacterManager : ScriptableObject
{
    [Header("When the character is player")]
    public string PlayerName;
    public int PlayerID;
    public Sprite PlayerSprite;
    public int PlayerLife;
    public int PlayerEnergy;

    public float PlayerAcceleration;
    public float PlayerSpeed;
    public float PlayerMaxSpeed;

    public float PlayerJumpForce;
    public float PlayerFallMultiplier;
    public float PlayerLowJumpMultiplier;

    public bool PlayerHasDashEffect;

    public RuntimeAnimatorController PlayerBaseAnimator;
    public AnimatorOverrideController PlayerOverrideAnimator;

    [Header("When the character is enemy")]
    public string EnemyName;
    public int EnemyID;
    public Sprite EnemySprite;
    public int EnemyLife;
    public int EnemyEnergy;

    public float EnemyAcceleration;
    public float EnemySpeed;
    public float EnemyMaxSpeed;
}
