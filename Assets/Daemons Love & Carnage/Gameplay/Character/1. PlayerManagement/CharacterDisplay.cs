using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDisplay : MonoBehaviour
{
    public CharacterManager CM;

    public string Name;
    public int Life;
    public int Energy;
    public RuntimeAnimatorController RAC;
    public AnimatorOverrideController AOC;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            InitializeCharacter();
        }
    }

    public void InitializeCharacter()
    {
        Name = CM.PlayerName;
        Life = CM.PlayerLife;
        Energy = CM.PlayerEnergy;
        GetComponent<SpriteRenderer>().sprite = CM.PlayerSprite;
        RAC = CM.PlayerBaseAnimator;
        AOC = CM.PlayerOverrideAnimator;
        GetComponent<Animator>().runtimeAnimatorController = CM.PlayerOverrideAnimator;
    }
}
