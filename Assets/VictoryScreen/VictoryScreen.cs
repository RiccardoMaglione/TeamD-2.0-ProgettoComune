﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] GameObject book;

    [SerializeField] GameObject whitePanel;
    [SerializeField] Image whitePanelIMG;
    public bool tornPageIsMoving;
    public float dropSpeed;
    public static bool win;
    public static bool winChecked = false;

    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject player3;
    [SerializeField] GameObject player4;
    [SerializeField] GameObject boss;

    private void Start()
    {

    }

    private void Update()
    {

        if (win == true && winChecked == false)
        {
            winChecked = true;
            Invoke("Dropdown", 1.5f);
            WhitePanelAppears();
            FadeIn();
            Invoke("DeactivateAllEntities", 1.2f);
            //Invoke("FadeOut", 0.1f);
            //Invoke("WhitePanelDisappear", 0.2f);
            Cursor.visible = true;
        }      
    }
    
    public void Dropdown()
    {
        StartCoroutine("BookDropCoroutine");
    }
    public IEnumerator BookDropCoroutine()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.Play("Sfx_book_drop");

        book.SetActive(true);

        float elapsedTime = 0;
        Vector3 startScale = new Vector3(2.24f, 2.24f, 1f);
        Vector3 targetScale = new Vector3(1.12f, 1.12f, 1f);

        book.transform.localScale = startScale;

        float timeTakes = dropSpeed;


        while (elapsedTime < timeTakes)
        {
            book.transform.localScale = Vector3.Lerp(book.transform.localScale, targetScale, (elapsedTime / timeTakes));

            elapsedTime += Time.unscaledDeltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    void DeactivateAllEntities()
    {
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);
        boss.SetActive(false);
    }

    public void FadeIn()
    {
        whitePanelIMG.canvasRenderer.SetAlpha(0f);
        whitePanelIMG.CrossFadeAlpha(1, 1f, false);       
    }
    /*public void FadeOut()
    {
        whitePanelIMG.CrossFadeAlpha(0, 0.1f, false);
    }*/
    public void WhitePanelAppears()
    {
        whitePanel.SetActive(true);
    }
    /*
    public void WhitePanelDisappears()
    {
        whitePanel.SetActive(false);
    }*/

}
