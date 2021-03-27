using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeController : MonoBehaviour
{
    [HideInInspector]
    public bool isAttacked = false;
    
    public float colorChangeDuration;

    public Material newMaterial;
    public Material originalMaterial;

    SpriteRenderer sr;

    public IEnumerator ChangeColor()
    {
        isAttacked = false;
        sr.material = newMaterial;
        yield return new WaitForSecondsRealtime(colorChangeDuration);
        sr.material = originalMaterial;
    }

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isAttacked)
        {
            StartCoroutine(ChangeColor());
        }
    }
}
