﻿using UnityEngine;

public class MoveRight : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Debug.LogWarning(damage+" WAVE DAMAGE");
        
        if (collision.gameObject.tag == "Wall")
            Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
