using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SwordGame;

public class UICharacter : MonoBehaviour
{
    public Image PlayerImage;

    public Sprite FatKnightPlayerSprite;
    public Sprite BoriousKnightPlayerSprite;
    public Sprite BabushkaPlayerSprite;
    public Sprite ThiefPlayerSprite;

    private void Start()
    {
        Possession.TypologyPlayer = ChangeFollow.StaticPlayerTemp.GetComponent<PSMController>().TypeCharacter;
    }

    void Update()
    {
        SubstitutePlayerImage();
    }

    public void SubstitutePlayerImage()
    {
        switch (Possession.TypologyPlayer)
        {
            case SwordGame.TypePlayer.FatKnight:
                PlayerImage.sprite = FatKnightPlayerSprite;
                break;
            case SwordGame.TypePlayer.BoriousKnight:
                PlayerImage.sprite = BoriousKnightPlayerSprite;
                break;
            case SwordGame.TypePlayer.Babushka:
                PlayerImage.sprite = BabushkaPlayerSprite;
                break;
            case SwordGame.TypePlayer.Thief:
                PlayerImage.sprite = ThiefPlayerSprite;
                break;
            default:
                break;
        }
    }
}
