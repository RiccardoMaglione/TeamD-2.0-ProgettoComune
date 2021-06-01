using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleWipe : MonoBehaviour
{
    public RectTransform RT;
    public float timer;
    public float speed;

    void Start()
    {
        InitializeScaleCircle();
    }

    void Update()
    {
        ScaleCircle();
    }

    public void InitializeScaleCircle()
    {
        RT = GetComponent<RectTransform>();
        RT.sizeDelta = new Vector2(1100, 1100);
    }

    public void ScaleCircle()
    {
        if(RT.sizeDelta.x >= 0 && RT.sizeDelta.y >= 0)
        {
            timer += Time.deltaTime;
            RT.sizeDelta = new Vector2(1100 - timer * speed, 1100 - timer * speed);
        }
    }
}
