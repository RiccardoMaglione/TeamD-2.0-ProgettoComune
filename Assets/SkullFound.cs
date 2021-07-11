using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkullFound : MonoBehaviour
{
    Image SkullNotFoundImage;
    public Sprite SkullNotFoundSprite;
    public Sprite SkullFoundSprite;

    private void Awake()
    {
        SkullNotFoundImage = GetComponent<Image>();
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("ObtainSkull") == 1)
        {
            SkullNotFoundImage.sprite = SkullFoundSprite;
        }
        else if (PlayerPrefs.GetInt("ObtainSkull") == 0)
        {
            SkullNotFoundImage.sprite = SkullNotFoundSprite;
        }
    }

    public void ResetSkullFound()
    {
        PlayerPrefs.SetInt("ObtainSkull", 0);
    }
}
