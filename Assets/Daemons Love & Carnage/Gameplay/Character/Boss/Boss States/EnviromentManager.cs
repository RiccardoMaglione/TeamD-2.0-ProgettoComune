using UnityEngine;

public class EnviromentManager : MonoBehaviour
{
    [SerializeField] Rigidbody2D[] rb;
    public static EnviromentManager instance;

    /// <summary>
    /// Function for enable the simulated component of the RigidBody2D
    /// </summary>
    /// <param name="value"></param>
    public void ActiveSimulated(bool value)
    {
        foreach (var rbody in rb)
        {
            rbody.simulated = value;
        }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
