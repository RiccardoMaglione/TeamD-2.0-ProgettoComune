using UnityEngine;

public class PortalForBossMinions : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;
    [SerializeField] Transform[] waveEnemies1;
    [SerializeField] Transform[] waveEnemies2;

    public void SpawnEnemies1()
    {
        for (int i = 0; i < waveEnemies1.Length; i++)
        {
            Instantiate(ps, waveEnemies1[i].position, waveEnemies1[i].rotation);
        }
    }
    public void SpawnEnemies2()
    {
        for (int i = 0; i < waveEnemies2.Length; i++)
        {
            Instantiate(ps, waveEnemies2[i].position, waveEnemies2[i].rotation);
        }
    }

}
