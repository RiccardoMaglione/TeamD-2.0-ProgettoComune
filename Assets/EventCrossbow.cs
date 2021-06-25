using UnityEngine;

public class EventCrossbow : MonoBehaviour
{
    CrossbowTrap crossbowTrap;

    private void Awake()
    {
        crossbowTrap = GetComponentInParent<CrossbowTrap>();
    }
    public void InstantiateBullet()
    {
        if (transform.rotation.eulerAngles.y == 180)
        {
            GameObject go = Instantiate(crossbowTrap.bullet, crossbowTrap.shotPoint.transform.position, transform.rotation);
        }

        else
        {
            GameObject go = Instantiate(crossbowTrap.bullet, crossbowTrap.shotPoint2.transform.position, transform.rotation);
        }

    }

}
