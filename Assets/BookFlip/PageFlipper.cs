using System.Collections;
using UnityEngine;

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

    public static bool aPageIsFlipping = false;
    public bool introCutscene = false;

    public int introPageCounter;
    public int pageCounter;

    private float flipTime = 10;
    [SerializeField]
    private float flipSpeed;

    private void Start()
    {
        introPageCounter = 0;
        pageCounter = 0;
        notFlippedPosition = Quaternion.Euler(0, 0, 0);
        flippedPosition = Quaternion.Euler(0, 180, 0);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && introCutscene == true && aPageIsFlipping == false)
        {
            CutsceneFlipForward();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && introCutscene == false && aPageIsFlipping == false)
        {
            if (pageCounter == 1)
            {
                StopAllCoroutines();
                StartCoroutine(BackToMenuCoroutine());
            }
            if (pageCounter == 2)
            {
                StopAllCoroutines();
                StartCoroutine(BackToLevelSelectionCoroutine());
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
                introCutscene = false;
            }


        }
    }

    IEnumerator EnterCutsceneCoroutine()
    {
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
            yield return new WaitForEndOfFrame();
            page8Pivot.SetActive(true);
            yield return null;
        }
    }


    IEnumerator ToLevel3Coroutine()
    {
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
            yield return new WaitForEndOfFrame();
            page9Pivot.SetActive(true);
            yield return null;
        }
    }


    IEnumerator Page1FlipForwardCoroutine()
    {
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
    IEnumerator Page2FlipForwardCoroutine()
    {
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
    IEnumerator Page3FlipForwardCoroutine()
    {
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
    IEnumerator Page4FlipForwardCoroutine()
    {
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
    IEnumerator Page5FlipForwardCoroutine()
    {
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
    IEnumerator Page6FlipForwardCoroutine()
    {
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
    IEnumerator Page7FlipForwardCoroutine()
    {
        float progress = 0;
        while (progress < flipTime)
        {
            aPageIsFlipping = true;
            page7Pivot.transform.rotation = Quaternion.Lerp(flippedPosition, notFlippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (page7Pivot.transform.rotation.y == 0)
            {
                pageCounter = 1;
                aPageIsFlipping = false;
            }
            yield return new WaitForEndOfFrame();
            page8Pivot.SetActive(true);
            yield return null;
        }
    }
    IEnumerator BackToMenuCoroutine()
    {
        float progress = 0;
        while (progress < flipTime)
        {
            aPageIsFlipping = true;
            page0Pivot.transform.rotation = Quaternion.Lerp(notFlippedPosition, flippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (page8Pivot.transform.rotation.eulerAngles.y == 180)
            {
                aPageIsFlipping = false;
            }
            if (page0Pivot.transform.rotation.eulerAngles.y == 180)
            {
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
