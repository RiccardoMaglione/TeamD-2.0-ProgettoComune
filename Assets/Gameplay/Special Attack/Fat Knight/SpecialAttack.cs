using System.Collections;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
    public GameObject[] obj;
    public int i = 0;
    [SerializeField] GameObject stompPrefab;
    public Animator animator;

    public void Findenemy()
    {
        obj = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void InstantiateStomps()
    {
        Instantiate(stompPrefab, new Vector2(obj[i].transform.position.x, obj[i].transform.position.y + 8), transform.rotation);
    }
}
