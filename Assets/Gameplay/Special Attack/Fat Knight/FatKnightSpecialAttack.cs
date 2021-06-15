using System.Collections.Generic;
using UnityEngine;

public class FatKnightSpecialAttack : MonoBehaviour
{
    public List<GameObject> enemyList = new List<GameObject>();
    public EnemyData[] obj;
    public int i = 0;
    [SerializeField] GameObject stompPrefab;
    public Animator animator;
    public bool allAdded;

    public void Findenemy()
    {
        allAdded = false;
        obj = FindObjectsOfType<EnemyData>();
        foreach (EnemyData go in obj)
        {
            if (go.isActiveAndEnabled)
            {
                enemyList.Add(go.gameObject);
            }
        }
    }

    public void InstantiateStomps()
    {
        Instantiate(stompPrefab, new Vector2(enemyList[i].transform.position.x, enemyList[i].transform.position.y + 8), transform.rotation);
    }
}
