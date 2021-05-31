using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fade : MonoBehaviour
{
    public Image FadePanel;
    public float FadeTime = 2;
    void Start()
    {
        FadePanel.GetComponent<Image>().CrossFadeAlpha(0, FadeTime, false);
        Invoke("DeactiveFadePanel", FadeTime);
    }
    public void DeactiveFadePanel()
    {
        FadePanel.gameObject.SetActive(false);
    }
}
