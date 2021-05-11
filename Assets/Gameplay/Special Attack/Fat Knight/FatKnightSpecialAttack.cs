using System.Collections.Generic;
using UnityEngine;

public class FatKnightSpecialAttack : MonoBehaviour
{
    public List<GameObject> enemyList = new List<GameObject>();
    public GameObject[] obj;
    public int i = 0;
    [SerializeField] GameObject stompPrefab;
    public Animator animator;

    public void Findenemy()
    {
        obj = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in obj)
        {
            if (go.layer == 9)
            {
                enemyList.Add(go);
            }
        }
    }

    public void InstantiateStomps()
    {
        Instantiate(stompPrefab, new Vector2(enemyList[i].transform.position.x, enemyList[i].transform.position.y + 8), transform.rotation);
    }
}
