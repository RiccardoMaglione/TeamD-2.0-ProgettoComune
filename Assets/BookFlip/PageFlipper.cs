using System.Collections;
using UnityEngine;

public class PageFlipper : MonoBehaviour
{
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

    private Quaternion notFlippedPosition;
    private Quaternion flippedPosition;

    private bool aPageIsFlipping = false;

    public int pageCounter;

    private float flipTime = 10;
    [SerializeField]
    private float flipSpeed;

    private void Start()
    {
        pageCounter = 0;
        notFlippedPosition = Quaternion.Euler(0, 0, 0);
        flippedPosition = Quaternion.Euler(0, 180, 0);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PageFlipForward();
        }
    }
    public void PageFlipForward()
    {
        if (aPageIsFlipping == false)
        {
            if (pageCounter == 0)
            {
                StopAllCoroutines();
                StartCoroutine(Page1FlipForwardCoroutine());
            }
            else if (pageCounter == 1)
            {
                StopAllCoroutines();

                StartCoroutine(Page2FlipForwardCoroutine());
            }
            else if (pageCounter == 2)
            {
                StopAllCoroutines();

                StartCoroutine(Page3FlipForwardCoroutine());
            }
            else if (pageCounter == 3)
            {
                StopAllCoroutines();

                StartCoroutine(Page4FlipForwardCoroutine());
            }
            else if (pageCounter == 4)
            {
                StopAllCoroutines();

                StartCoroutine(Page5FlipForwardCoroutine());
            }
            else if (pageCounter == 5)
            {
                StopAllCoroutines();

                StartCoroutine(Page6FlipForwardCoroutine());
            }

        }
    }
    /*public void Page1FlipFBackward()
    {
        StopAllCoroutines();
        StartCoroutine(Page1FlipBackwardCoroutine());
    }*/

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
                pageCounter = 1;
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
                pageCounter = 2;
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
                pageCounter = 3;
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
                pageCounter = 4;
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
                pageCounter = 5;
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
                pageCounter = 6;
                aPageIsFlipping = false;
            }
            yield return null;
        }
    }















    /*IEnumerator PageXFlipBackwardCoroutine()
    {
        float progress = 0;
        while (progress < flipTime)
        {
            aPageIsFlipping = true;
            page1Pivot.transform.rotation = Quaternion.Lerp(notFlippedPosition, flippedPosition, progress * flipSpeed);
            progress += Time.deltaTime;
            if (page1Pivot.transform.rotation.y == 180)
            {
               
            }
            yield return null;
        }
    }*/

}
