using Cinemachine;
using UnityEngine;

public class FixParallax : MonoBehaviour
{
    public static Vector3 position;
    [HideInInspector]
    public CinemachineVirtualCameraBase cam;

    private void Start()
    {
        position = FindObjectOfType<CinemachineVirtualCameraBase>().transform.position;
        cam = FindObjectOfType<CinemachineVirtualCameraBase>();
    }
    private void Update()
    {
        cam = FindObjectOfType<CinemachineVirtualCameraBase>();
        position = FindObjectOfType<CinemachineVirtualCameraBase>().transform.position;
        position = cam.State.FinalPosition;
    }
}
