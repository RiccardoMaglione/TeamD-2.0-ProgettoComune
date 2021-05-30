using System.Collections;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] GameObject[] waves;
    public bool EnemiesAreSpawning = false;
    public float timerFloat;
    private float timer = 2;

    EnemySpawner enemySpawner;

    public int i = 0;
    private void OnEnable()
    {
        waves[i].SetActive(true);
    }

    private void Start()
    {
        enemySpawner = this.gameObject.GetComponent<EnemySpawner>();
    }
    void Update()
    {
        if (EnemiesAreSpawning == true)
        {
            timerFloat += Time.deltaTime;
        }
        if (timerFloat >= timer)
        {
            waves[i].SetActive(true);
            EnemiesAreSpawning = false;
            timerFloat = 0;
        }

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 1 && EnemiesAreSpawning == false)
        {
            if (EnemiesAreSpawning == false)
                i++;
            if (i < waves.Length)
            {
                if (timerFloat <= timer)
                {
                    EnemiesAreSpawning = true;
                    enemySpawner.SpawnEnemies();
                }


                //StopCoroutine("Spawn");
                //StartCoroutine("Spawn");
            }
            if (i == waves.Length)
            {
                UIManager.instance.arrow.SetActive(true);
                //gameObject.SetActive(false);
            }

        }
    }

    IEnumerator Spawn()
    {
        EnemiesAreSpawning = true;
        yield return new WaitForSeconds(5);
        waves[i].SetActive(true);
        EnemiesAreSpawning = false;
    }

}
