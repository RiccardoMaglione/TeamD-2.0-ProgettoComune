using System.Collections;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] GameObject[] waves;
    public bool EnemiesAreSpawning = false;
    public float timerFloat;
    private float timer = 2;
    [SerializeField] KilledEnemyCounter killedEnemyCounterScript;
    [SerializeField] int killedEnemyCounterToProgress;
    public bool allEnemiesAreStunned = false;
    public int wave1EnemiesNumber;
    public int wave2EnemiesNumber;


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
        if (wave1EnemiesNumber == killedEnemyCounterScript.killedEnemyCounter && allEnemiesAreStunned == false || wave2EnemiesNumber == killedEnemyCounterScript.killedEnemyCounter && allEnemiesAreStunned == false)
        {
            allEnemiesAreStunned = true;
        }
        else
        {
            allEnemiesAreStunned = false;
        }



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

        if (EnemiesAreSpawning == false && allEnemiesAreStunned)
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

        }
        if (killedEnemyCounterScript.killedEnemyCounter == killedEnemyCounterToProgress && EnemiesAreSpawning == false)
        {
            UIManager.instance.arrow.SetActive(true);
            //gameObject.SetActive(false);
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
