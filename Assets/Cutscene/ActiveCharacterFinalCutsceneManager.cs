using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordGame;

public class ActiveCharacterFinalCutsceneManager : MonoBehaviour
{
    [SerializeField] GameObject FatKnight;
    [SerializeField] GameObject BoriousKnight;
    [SerializeField] GameObject Babushka;
    [SerializeField] GameObject Thief;

    private void Awake()
    {
        switch (CharacterCutsceneManager.id)
        {
            case 1:
                FatKnight.SetActive(true);
                break;

            case 2:
                Babushka.SetActive(true);
                break;

            case 3:
                BoriousKnight.SetActive(true);
                break;

            case 4:
                Thief.SetActive(true);
                ThiefSpecialAttack.specialOn = false;
                break;

            default:
                break;
        }

        FindObjectOfType<PSMController>().enabled = false;
        CutsceneControllerDeathBoss.isCutsceneEnabled = true;
    }
}
