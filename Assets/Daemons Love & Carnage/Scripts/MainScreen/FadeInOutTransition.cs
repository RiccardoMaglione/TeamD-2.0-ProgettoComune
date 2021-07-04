﻿using UnityEngine;
using UnityEngine.UI;


public class FadeInOutTransition : MonoBehaviour
{
    [SerializeField]
    public Image blackPanel;

    [SerializeField]
    public GameObject blackPanelObject;

    [SerializeField]
    public GameObject blackPanelObject2;


    private void Start()
    {
        //FadeOut();
        if (blackPanelObject2 != null)
        {
            Invoke("BlackPanel2Disappears", 0.5f);
        }
    }
    public void FadeIn()
    {
        //cambia l'alpha del pannello nero a 1(totalmente nero) in X secondi(secondo paramentro) dopo averla impostata a 0
        blackPanel.canvasRenderer.SetAlpha(0f);
        blackPanel.CrossFadeAlpha(1, 0.4f, false);
    }
    public void FadeOut()
    {
        //cambia l'alpha del pannello nero a 0(totalmente trasparente) in X secondi(secondo paramentro)
        blackPanel.CrossFadeAlpha(0, 0.4f, false);
    }
    public void BlackPanelAppears()
    {
        //disattiva il gameobject del pannello nero

        blackPanelObject.SetActive(true);
    }
    public void BlackPanelDisappears()
    {
        //attiva il gameobject del pannello nero
        blackPanelObject.SetActive(false);
    }
    public void BlackPanel2Disappears()
    {
        //attiva il gameobject del pannello nero
        blackPanelObject2.SetActive(false);
    }

}
