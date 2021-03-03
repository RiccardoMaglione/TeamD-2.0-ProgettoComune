using System.Collections;
using UnityEngine;

public class Crack : MonoBehaviour
{
    [SerializeField] float activeTime;

    IEnumerator Laser()
    {
        LaserManager.instance.isActive = true;
        yield return new WaitForSeconds(activeTime);
        gameObject.SetActive(false);
        LaserManager.instance.isActive = false;        
    }

    void OnEnable()
    {
        StartCoroutine(Laser());
    }
}
