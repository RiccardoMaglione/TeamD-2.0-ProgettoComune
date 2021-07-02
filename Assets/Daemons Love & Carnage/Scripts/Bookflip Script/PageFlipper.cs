﻿using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PageFlipper : MonoBehaviour
{
    [SerializeField]
    private GameObject illustration0;
    [SerializeField]
    private GameObject levelSelectionPage1;


    [SerializeField]
    private GameObject page0Pivot;
    [SerializeField]
    private GameObject page1Pivot;
    [SerializeField]
    private GameObject page2Pivot;
    [SerializeField]
    private GameObject page3Pivot;
    [SerializeField]
    private GameObject page4Pivot;
    [SerializeField]
    private GameObject page5Pivot;
    [SerializeField]
    private GameObject page6Pivot;
    [SerializeField]
    private GameObject page7Pivot;
    [SerializeField]
    private GameObject page8Pivot;
    [SerializeField]
    private GameObject page9Pivot;

    private Quaternion notFlippedPosition;
    private Quaternion flippedPosition;

    public bool aPageIsFlipping = false;
    public bool introCutscene = false;

    public int introPageCounter;
    public int pageCounter;

    public bool movingBack = false;

    private float flipTime = 10;
    [SerializeField]
    private float flipSpeed;
    public GameObject page8button;
    public GameObject av;
    public GameObject bv;
    public GameObject cv;
    public GameObject cvtext;

    public GameObject cv1;
    public GameObject cvtext1;
    public GameObject cv2;
    public GameObject cvtext2;

    public bool boola;
    private void Start()
    {
        introPageCounter = 0;
        pageCounter = 0;
        notFlippedPosition = Quaternion.Euler(0, 0, 0);
        flippedPosition = Quaternion.Euler(0, 180, 0);
    }

    public void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && introCutscene == true && aPageIsFlipping == false || Input.GetMouseButtonDown(0) && introCutscene == true && aPageIsFlipping == false)
        {
            EventSystem.current.SetSelectedGameObject(null);
            Invoke("CheckBackwardBeforeForward", 0.15f);
        }
        if(Input.GetKeyDown(KeyCode.Joystick1Button1) && introCutscene == true && aPageIsFlipping == false && introPageCounter == 0)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1) && introCutscene == true && aPageIsFlipping == false)
        {
            EventSystem.current.SetSelectedGameObject(null);
            CutsceneFlipBackward();
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1) && introCutscene == true && aPageIsFlipping == true)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && introCutscene == true && aPageIsFlipping == false)
        {
            CutsceneFlipBackward();
        }

        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button1)) && introCutscene == false && aPageIsFlipping == false)
        {
            BackToMenuOrLevelSelection();
        }

    }
    public void BackToMenuOrLevelSelection()
    {
        if (aPageIsFlipping == false)
        {
            if (pageCounter == 1)
            {
                StopAllCoroutines();
                StartCoroutine(BackToMenuCoroutine());
            }
            if (pageCounter == 2)
            {
                if (TornPage.tornPageIsMoving == false)
                {
                    StopAllCoroutines();
                    StartCoroutine(BackToLevelSelectionCoroutine());
                }
            }

        }

    }
    public void NewGame()
    {
        if (aPageIsFlipping == false)
        {
            introPageCounter = 0;
            pageCounter = 0;

            StopAllCoroutines();
            StartCoroutine(EnterCutsceneCoroutine());
            introCutscene = true;
            illustration0.SetActive(true);
            levelSelectionPage1.SetActive(false);
            page7Pivot.SetActive(false);
            page8Pivot.SetActive(false);

            page1Pivot.transform.rotation = Quaternion.Euler(0, 180, 0);
            page2Pivot.transform.rotation = Quaternion.Euler(0, 180, 0);
            page3Pivot.transform.rotation = Quaternion.Euler(0, 180, 0);
            page4Pivot.transform.rotation = Quaternion.Euler(0, 180, 0);
            page5Pivot.transform.rotation = Quaternion.Euler(0, 180, 0);
            page6Pivot.transform.rotation = Quaternion.Euler(0, 180, 0);
            page7Pivot.transform.rotation = Quaternion.Euler(0, 180, 0);
            page8Pivot.transform.rotation = Quaternion.Euler(0, 180, 0);
            page9Pivot.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    public void Continue()
    {
        if (aPageIsFlipping == false)
        {
            introPageCounter = 0;
            pageCounter = 0;

            StopAllCoroutines();
            page8Pivot.SetActive(false);
            StartCoroutine(EnterLevelSelectionCoroutine());
            introCutscene = false;
            levelSelectionPage1.SetActive(true);
            illustration0.SetActive(false);
        }
    }

    public void ToLevel3()
    {
        if (aPageIsFlipping == false)
        {
            StopAllCoroutines();
            page9Pivot.SetActive(false);
            pageCounter = 2;
            StartCoroutine(ToLevel3Coroutine());
        }
    }

    public void CheckBackwardBeforeForward()
    {
        if (movingBack == false && aPageIsFlipping == false)
            CutsceneFlipForward();
    }
    public void CutsceneFlipForward()
    {
        if (aPageIsFlipping == false)
        {
            if (introPageCounter == 0)
            {
                StopAllCoroutines();
                StartCoroutine(Page1FlipForwardCoroutine());
            }
            else if (introPageCounter == 1)
            {
                StopAllCoroutines();

                StartCoroutine(Page2FlipForwardCoroutine());
            }
            else if (introPageCounter == 2)
            {
                StopAllCoroutines();

                StartCoroutine(Page3FlipForwardCoroutine());
            }
            else if (introPageCounter == 3)
            {
                StopAllCoroutines();

                StartCoroutine(Page4FlipForwardCoroutine());
            }
            else if (introPageCounter == 4)
            {
                StopAllCoroutines();

                StartCoroutine(Page5FlipForwardCoroutine());
            }
            else if (introPageCounter == 5)
            {
                StopAllCoroutines();

                StartCoroutine(Page6FlipForwardCoroutine());
            }
            else if (introPageCounter == 6)
            {
                StopAllCoroutines();
                StartCoroutine(Page7FlipForwardCoroutine());
            }

        }
    }

    public void CutsceneFlipBackward()
    {
        if (aPageIsFlipping == false)
        {
            movingBack = true;
            if (introPageCounter == 0)
            {
            }
            else if (introPageCounter == 1)
            {
                StopAllCoroutines();

                StartCoroutine(Page2FlipBackwardCoroutine());
            }
            else if (introPageCounter == 2)
            {
                StopAllCoroutines();

                StartCoroutine(Page3FlipBackwardCoroutine());
            }
            else if (introPageCounter == 3)
            {
                StopAllCoroutines();

                StartCoroutine(Page4FlipBackwardCoroutine());
            }
            else if (introPageCounter == 4)
            {
                StopAllCoroutines();

                StartCoroutine(Page5FlipBackwardCoroutine());
            }
            else if (introPageCounter == 5)
            {
                StopAllCoroutines();

                StartCoroutine(Page6FlipBackwardCoroutine());
            }
            else if (introPageCounter == 6)
            {
                StopAllCoroutines();
                StartCoroutine(Page7FlipBackwardCoroutine());
            }
        }

    }

    IEnumerator EnterCutsceneCoroutine()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_mouse_on_button");
        }
        float progress = 0;
        while (progress < flipTime)
        {
            aPageIsFlipping = true;
            page0Pivot.transform.rotation = Quaternion.Lerp(flippedPosition, notFlippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (page0Pivot.transform.rotation.y == 0)
            {
                aPageIsFlipping = false;
            }
            yield return new WaitForEndOfFrame();
            page1Pivot.SetActive(true);
            yield return null;
        }
    }
    IEnumerator EnterLevelSelectionCoroutine()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_mouse_on_button");
        }
        float progress = 0;
        while (progress < flipTime)
        {
            aPageIsFlipping = true;
            page0Pivot.transform.rotation = Quaternion.Lerp(flippedPosition, notFlippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (page0Pivot.transform.rotation.y == 0)
            {
                pageCounter = 1;
                aPageIsFlipping = false;
            }
            page8Pivot.SetActive(true);
            if(boola == false)
            {
                av.GetComponent<Image>().enabled = false;
                bv.GetComponent<Image>().enabled = false;

                cv.GetComponent<Image>().enabled = false;
                cv1.GetComponent<Image>().enabled = false;
                cv2.GetComponent<Image>().enabled = false;

                cv.GetComponent<Image>().color = new Color(cv.GetComponent<Image>().color.r, cv.GetComponent<Image>().color.g, cv.GetComponent<Image>().color.b, 0);
                cv1.GetComponent<Image>().color = new Color(cv1.GetComponent<Image>().color.r, cv1.GetComponent<Image>().color.g, cv1.GetComponent<Image>().color.b, 0);
                cv2.GetComponent<Image>().color = new Color(cv2.GetComponent<Image>().color.r, cv2.GetComponent<Image>().color.g, cv2.GetComponent<Image>().color.b, 0);
                
                cvtext.SetActive(false);
                cvtext1.SetActive(false);
                cvtext2.SetActive(false);

                boola = true;
            }
            yield return new WaitForEndOfFrame();
            if(boola == true)
            {
                av.GetComponent<Image>().enabled = true;
                bv.GetComponent<Image>().enabled = true;

                cv.GetComponent<Image>().enabled = true;
                cv1.GetComponent<Image>().enabled = true;
                cv2.GetComponent<Image>().enabled = true;

                cv.GetComponent<Image>().color = new Color(cv.GetComponent<Image>().color.r, cv.GetComponent<Image>().color.g, cv.GetComponent<Image>().color.b, 1);
                cv1.GetComponent<Image>().color = new Color(cv1.GetComponent<Image>().color.r, cv1.GetComponent<Image>().color.g, cv1.GetComponent<Image>().color.b, 1);
                cv2.GetComponent<Image>().color = new Color(cv2.GetComponent<Image>().color.r, cv2.GetComponent<Image>().color.g, cv2.GetComponent<Image>().color.b, 1);

                cvtext.SetActive(true);
                cvtext1.SetActive(true);
                cvtext2.SetActive(true);
            }
            yield return null;
        }
    }


    IEnumerator ToLevel3Coroutine()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_mouse_on_button");
        }
        float progress = 0;
        while (progress < flipTime)
        {
            aPageIsFlipping = true;
            page8Pivot.transform.rotation = Quaternion.Lerp(flippedPosition, notFlippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (page8Pivot.transform.rotation.y == 0)
            {
                introPageCounter = 1;
                aPageIsFlipping = false;
            }
            page9Pivot.SetActive(true);
            yield return new WaitForEndOfFrame();
            yield return null;
        }
    }


    IEnumerator Page1FlipForwardCoroutine()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_mouse_on_button");
        }
        float progress = 0;
        while (progress < flipTime)
        {
            aPageIsFlipping = true;
            page1Pivot.transform.rotation = Quaternion.Lerp(flippedPosition, notFlippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (page1Pivot.transform.rotation.y == 0)
            {
                introPageCounter = 1;
                aPageIsFlipping = false;
            }
            yield return new WaitForEndOfFrame();
            page2Pivot.SetActive(true);
            yield return null;
        }
    }
    IEnumerator Page2FlipBackwardCoroutine()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_mouse_on_button");
        }
        float progress = 0;
        while (progress < flipTime)
        {
            aPageIsFlipping = true;
            page1Pivot.transform.rotation = Quaternion.Lerp(notFlippedPosition, flippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (page1Pivot.transform.rotation.eulerAngles.y == 180)
            {
                page2Pivot.SetActive(false);
                introPageCounter = 0;
                aPageIsFlipping = false;
                movingBack = false;
            }
            yield return new WaitForEndOfFrame();
            yield return null;
        }
    }

    IEnumerator Page2FlipForwardCoroutine()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_mouse_on_button");
        }
        float progress = 0;
        while (progress < flipTime)
        {
            aPageIsFlipping = true;
            page2Pivot.transform.rotation = Quaternion.Lerp(flippedPosition, notFlippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (page2Pivot.transform.rotation.y == 0)
            {
                introPageCounter = 2;
                aPageIsFlipping = false;
            }
            yield return new WaitForEndOfFrame();
            page3Pivot.SetActive(true);
            yield return null;
        }
    }
    IEnumerator Page3FlipBackwardCoroutine()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_mouse_on_button");
        }
        float progress = 0;
        while (progress < flipTime)
        {
            aPageIsFlipping = true;
            page2Pivot.transform.rotation = Quaternion.Lerp(notFlippedPosition, flippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (page2Pivot.transform.rotation.eulerAngles.y == 180)
            {
                page3Pivot.SetActive(false);
                introPageCounter = 1;
                aPageIsFlipping = false;
                movingBack = false;
            }
            yield return new WaitForEndOfFrame();
            yield return null;
        }
    }

    IEnumerator Page3FlipForwardCoroutine()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_mouse_on_button");
        }
        float progress = 0;
        while (progress < flipTime)
        {
            aPageIsFlipping = true;
            page3Pivot.transform.rotation = Quaternion.Lerp(flippedPosition, notFlippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (page3Pivot.transform.rotation.y == 0)
            {
                introPageCounter = 3;
                aPageIsFlipping = false;
            }
            yield return new WaitForEndOfFrame();
            page4Pivot.SetActive(true);
            yield return null;
        }
    }
    IEnumerator Page4FlipBackwardCoroutine()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_mouse_on_button");
        }
        float progress = 0;
        while (progress < flipTime)
        {
            aPageIsFlipping = true;
            page3Pivot.transform.rotation = Quaternion.Lerp(notFlippedPosition, flippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (page3Pivot.transform.rotation.eulerAngles.y == 180)
            {
                page4Pivot.SetActive(false);
                introPageCounter = 2;
                aPageIsFlipping = false;
                movingBack = false;
            }
            yield return new WaitForEndOfFrame();
            yield return null;
        }
    }

    IEnumerator Page4FlipForwardCoroutine()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_mouse_on_button");
        }
        float progress = 0;
        while (progress < flipTime)
        {
            aPageIsFlipping = true;
            page4Pivot.transform.rotation = Quaternion.Lerp(flippedPosition, notFlippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (page4Pivot.transform.rotation.y == 0)
            {
                introPageCounter = 4;
                aPageIsFlipping = false;
            }
            yield return new WaitForEndOfFrame();
            page5Pivot.SetActive(true);
            yield return null;
        }
    }
    IEnumerator Page5FlipBackwardCoroutine()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_mouse_on_button");
        }
        float progress = 0;
        while (progress < flipTime)
        {
            aPageIsFlipping = true;
            page4Pivot.transform.rotation = Quaternion.Lerp(notFlippedPosition, flippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (page4Pivot.transform.rotation.eulerAngles.y == 180)
            {
                page5Pivot.SetActive(false);
                introPageCounter = 3;
                aPageIsFlipping = false;
                movingBack = false;
            }
            yield return new WaitForEndOfFrame();
            yield return null;
        }
    }

    IEnumerator Page5FlipForwardCoroutine()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_mouse_on_button");
        }
        float progress = 0;
        while (progress < flipTime)
        {
            aPageIsFlipping = true;
            page5Pivot.transform.rotation = Quaternion.Lerp(flippedPosition, notFlippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (page5Pivot.transform.rotation.y == 0)
            {
                introPageCounter = 5;
                aPageIsFlipping = false;
            }
            yield return new WaitForEndOfFrame();
            page6Pivot.SetActive(true);
            yield return null;
        }
    }
    IEnumerator Page6FlipBackwardCoroutine()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_mouse_on_button");
        }
        float progress = 0;
        while (progress < flipTime)
        {
            aPageIsFlipping = true;
            page5Pivot.transform.rotation = Quaternion.Lerp(notFlippedPosition, flippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (page5Pivot.transform.rotation.eulerAngles.y == 180)
            {
                page6Pivot.SetActive(false);
                introPageCounter = 4;
                aPageIsFlipping = false;
                movingBack = false;
            }
            yield return new WaitForEndOfFrame();
            yield return null;
        }
    }

    IEnumerator Page6FlipForwardCoroutine()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_mouse_on_button");
        }
        float progress = 0;
        while (progress < flipTime)
        {
            aPageIsFlipping = true;
            page6Pivot.transform.rotation = Quaternion.Lerp(flippedPosition, notFlippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (page6Pivot.transform.rotation.y == 0)
            {
                introPageCounter = 6;
                aPageIsFlipping = false;
            }
            yield return new WaitForEndOfFrame();
            page7Pivot.SetActive(true);
            yield return null;
        }

    }
    IEnumerator Page7FlipBackwardCoroutine()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_mouse_on_button");
        }
        float progress = 0;
        while (progress < flipTime)
        {
            aPageIsFlipping = true;
            page6Pivot.transform.rotation = Quaternion.Lerp(notFlippedPosition, flippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (page6Pivot.transform.rotation.eulerAngles.y == 180)
            {
                page7Pivot.SetActive(false);
                introPageCounter = 5;
                aPageIsFlipping = false;
                movingBack = false;
            }
            yield return new WaitForEndOfFrame();
            yield return null;
        }
    }

    IEnumerator Page7FlipForwardCoroutine()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_mouse_on_button");
        }
        float progress = 0;
        while (progress < flipTime)
        {
            aPageIsFlipping = true;
            page7Pivot.transform.rotation = Quaternion.Lerp(flippedPosition, notFlippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (page7Pivot.transform.rotation.y == 0)
            {
                introCutscene = false;
                pageCounter = 1;
                aPageIsFlipping = false;
            }
            page8Pivot.SetActive(true);
            if (boola == false)
            {
                av.GetComponent<Image>().enabled = false;
                bv.GetComponent<Image>().enabled = false;

                cv.GetComponent<Image>().enabled = false;
                cv1.GetComponent<Image>().enabled = false;
                cv2.GetComponent<Image>().enabled = false;

                EventSystem.current.SetSelectedGameObject(cv);
                cv.GetComponent<Image>().color = new Color(cv.GetComponent<Image>().color.r, cv.GetComponent<Image>().color.g, cv.GetComponent<Image>().color.b, 0);
                cvtext.SetActive(false);

                cv1.GetComponent<Image>().color = new Color(cv1.GetComponent<Image>().color.r, cv1.GetComponent<Image>().color.g, cv1.GetComponent<Image>().color.b, 0);
                cvtext1.SetActive(false);
                cv2.GetComponent<Image>().color = new Color(cv2.GetComponent<Image>().color.r, cv2.GetComponent<Image>().color.g, cv2.GetComponent<Image>().color.b, 0);
                cvtext2.SetActive(false);

                boola = true;
            }
            yield return new WaitForEndOfFrame();
            if (boola == true)
            {
                av.GetComponent<Image>().enabled = true;
                bv.GetComponent<Image>().enabled = true;

                cv.GetComponent<Image>().enabled = true;
                cv1.GetComponent<Image>().enabled = true;
                cv2.GetComponent<Image>().enabled = true;

                cv.GetComponent<Image>().color = new Color(cv.GetComponent<Image>().color.r, cv.GetComponent<Image>().color.g, cv.GetComponent<Image>().color.b, 1);
                cvtext.SetActive(true);

                cv1.GetComponent<Image>().color = new Color(cv1.GetComponent<Image>().color.r, cv1.GetComponent<Image>().color.g, cv1.GetComponent<Image>().color.b, 1);
                cvtext1.SetActive(true);
                cv2.GetComponent<Image>().color = new Color(cv2.GetComponent<Image>().color.r, cv2.GetComponent<Image>().color.g, cv2.GetComponent<Image>().color.b, 1);
                cvtext2.SetActive(true);
            }
            yield return null;
        }
    }
    IEnumerator BackToMenuCoroutine()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_mouse_on_button");
        }
        float progress = 0;
        while (progress < flipTime)
        {
            aPageIsFlipping = true;
            page0Pivot.transform.rotation = Quaternion.Lerp(notFlippedPosition, flippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (page0Pivot.transform.rotation.eulerAngles.y == 180)
            {
                aPageIsFlipping = false;
                av.GetComponent<Image>().enabled = false;
                bv.GetComponent<Image>().enabled = false;
                cv.GetComponent<Image>().enabled = false;
                cv1.GetComponent<Image>().enabled = false;
                cv2.GetComponent<Image>().enabled = false;
                page8Pivot.SetActive(false);
            }
            yield return new WaitForEndOfFrame();
            pageCounter = 0;
            illustration0.SetActive(false);
            levelSelectionPage1.SetActive(true);
            page1Pivot.SetActive(false);
            page2Pivot.SetActive(false);
            page3Pivot.SetActive(false);
            page4Pivot.SetActive(false);
            page5Pivot.SetActive(false);
            page6Pivot.SetActive(false);
            page7Pivot.SetActive(false);
            page9Pivot.SetActive(false);
            yield return null;
        }
    }
    IEnumerator BackToLevelSelectionCoroutine()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_mouse_on_button");
        }
        float progress = 0;
        while (progress < flipTime)
        {
            aPageIsFlipping = true;
            page8Pivot.transform.rotation = Quaternion.Lerp(notFlippedPosition, flippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (page8Pivot.transform.rotation.eulerAngles.y == 180)
            {
                aPageIsFlipping = false;
                page9Pivot.SetActive(false);
            }
            yield return new WaitForEndOfFrame();
            pageCounter = 1;
            illustration0.SetActive(false);
            levelSelectionPage1.SetActive(true);
            page1Pivot.SetActive(false);
            page2Pivot.SetActive(false);
            page3Pivot.SetActive(false);
            page4Pivot.SetActive(false);
            page5Pivot.SetActive(false);
            page6Pivot.SetActive(false);
            page7Pivot.SetActive(false);
            yield return null;
        }
    }

}
