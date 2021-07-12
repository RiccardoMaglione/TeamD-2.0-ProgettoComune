using UnityEngine;
using UnityEngine.UI;
using SwordGame;

public class BossDialogueImageSwitch : MonoBehaviour
{
    public Image PlayerBossDialogue;
    public Image ObscuredPlayerBossDialogue;

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
        SubstitutePlayerImageBossDialogue();
        SubstituteObscuredPlayerImageBossDialogue();
    }


    public void SubstitutePlayerImageBossDialogue()
    {
        switch (Possession.TypologyPlayer)
        {
            case SwordGame.TypePlayer.FatKnight:
                PlayerBossDialogue.sprite = FatKnightPlayerSprite;
                break;
            case SwordGame.TypePlayer.BoriousKnight:
                PlayerBossDialogue.sprite = BoriousKnightPlayerSprite;
                break;
            case SwordGame.TypePlayer.Babushka:
                PlayerBossDialogue.sprite = BabushkaPlayerSprite;
                break;
            case SwordGame.TypePlayer.Thief:
                PlayerBossDialogue.sprite = ThiefPlayerSprite;
                break;
            default:
                break;
        }
    }
    public void SubstituteObscuredPlayerImageBossDialogue()
    {
        switch (Possession.TypologyPlayer)
        {
            case SwordGame.TypePlayer.FatKnight:
                ObscuredPlayerBossDialogue.sprite = FatKnightPlayerSprite;
                break;
            case SwordGame.TypePlayer.BoriousKnight:
                ObscuredPlayerBossDialogue.sprite = BoriousKnightPlayerSprite;
                break;
            case SwordGame.TypePlayer.Babushka:
                ObscuredPlayerBossDialogue.sprite = BabushkaPlayerSprite;
                break;
            case SwordGame.TypePlayer.Thief:
                ObscuredPlayerBossDialogue.sprite = ThiefPlayerSprite;
                break;
            default:
                break;
        }
    }

}
