using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    public Animator animator;
    public GameObject wave1;
    public GameObject wave2;

    [SerializeField] PortalForBossMinions portalForBossMinions;

    public bool EnemiesAreSpawning = false;
    public float timerFloat;
    private float timer = 2;
    public int waveCounter = 0;

    private void Awake()
    {

    }
    public void StartWave1()
    {
        portalForBossMinions.SpawnEnemies1();
        EnemiesAreSpawning = true;
        waveCounter = 1;
    }

    public void StartWave2()
    {
        portalForBossMinions.SpawnEnemies2();
        EnemiesAreSpawning = true;
        waveCounter = 2;
        timerFloat = 0;

    }

    public void ControlWave()
    {
        if (EnemiesAreSpawning == true && waveCounter == 1)
        {
            if (timerFloat < timer)
            {
                timerFloat += Time.deltaTime;
            }

            if (timerFloat >= timer)
            {
                wave1.SetActive(true);
                EnemiesAreSpawning = false;
            }
        }

        if (EnemiesAreSpawning == true && waveCounter == 2)
        {
            if (timerFloat < timer)
            {
                timerFloat += Time.deltaTime;
            }

            if (timerFloat >= timer)
            {
                wave2.SetActive(true);
                EnemiesAreSpawning = false;
            }
        }


        if (wave1.activeSelf == true || wave2.activeSelf == true)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 1)
            {
                //wave1.SetActive(false);
                //wave2.SetActive(false);
                animator.SetBool("GoToSmash", true);
            }
        }
    }
}
