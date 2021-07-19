using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonFeedbackController : MonoBehaviour
{
    [SerializeField] float initialScale;
    [SerializeField] float endScale;
    [SerializeField] float time;

    public void OnMouseEnter()
    {
        transform.DOScale(endScale, time);
    }

    public void OnMouseExit()
    {
        transform.DOScale(initialScale, time);
    }
}
