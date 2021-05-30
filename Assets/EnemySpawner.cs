using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    WaveController waveController;
    [SerializeField] ParticleSystem ps;
    [SerializeField] Transform[] wave2Enemies;
    [SerializeField] Transform[] wave3Enemies;

    private void Awake()
    {
        waveController = this.gameObject.GetComponent<WaveController>();
    }
    public void SpawnEnemies()
    {
        if (waveController.i == 1 && waveController.EnemiesAreSpawning == true)
        {
            for (int i = 0; i < wave2Enemies.Length; i++)
            {
                Instantiate(ps, wave2Enemies[i].position, wave2Enemies[i].rotation);
            }
        }
        if (waveController.i == 2 && waveController.EnemiesAreSpawning == true)
        {
            for (int i2 = 0; i2 < wave3Enemies.Length; i2++)
            {
                Instantiate(ps, wave3Enemies[i2].position, wave2Enemies[i2].rotation);
            }
        }

    }
}
