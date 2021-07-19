using UnityEngine;

public class PortalForBossMinions : MonoBehaviour
{
    [SerializeField] GameObject portal;
    [SerializeField] Transform[] waveEnemies1;
    [SerializeField] Transform[] waveEnemies2;

    public void SpawnEnemies1()
    {
        for (int i = 0; i < waveEnemies1.Length; i++)
        {
            GameObject tempPortal = Instantiate(portal, waveEnemies1[i].position, Quaternion.Euler(0, 0, 0));
            Destroy(tempPortal, 3f);

        }
    }
    public void SpawnEnemies2()
    {
        for (int i = 0; i < waveEnemies2.Length; i++)
        {
            GameObject tempPortal = Instantiate(portal, waveEnemies2[i].position, Quaternion.Euler(0, 0, 0));
            Destroy(tempPortal, 3f);
        }
    }

}
