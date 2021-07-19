using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    WaveController waveController;
    [SerializeField] GameObject portal;
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
            if (AudioManager.instance != null)
                AudioManager.instance.Play("Sfx_enemy_spawn");

            for (int i = 0; i < wave2Enemies.Length; i++)
            {
                GameObject tempPortal = Instantiate(portal, wave2Enemies[i].position, Quaternion.Euler(0, 0, 0));
                Destroy(tempPortal, 3.25f);
            }
        }

        if (waveController.i == 2 && waveController.EnemiesAreSpawning == true)
        {
            if (AudioManager.instance != null)
                AudioManager.instance.Play("Sfx_enemy_spawn");

            for (int i2 = 0; i2 < wave3Enemies.Length; i2++)
            {
                GameObject tempPortal2 = Instantiate(portal, wave3Enemies[i2].position, Quaternion.Euler(0, 0, 0));
                Destroy(tempPortal2, 3.25f);

            }
        }

    }
}
