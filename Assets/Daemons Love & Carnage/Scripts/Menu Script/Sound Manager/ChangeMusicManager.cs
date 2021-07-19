using UnityEngine;

public class ChangeMusicManager : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.FadeOut("MainMenuMusic");
        AudioManager.instance.Play("GameplayOST1");
    }
}
