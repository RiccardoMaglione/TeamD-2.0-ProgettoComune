using UnityEngine;

public class ScriptDelay : MonoBehaviour
{
    private void Start()
    {
        Invoke("EnableAfterDelay", 0.5f);
    }

    private void EnableAfterDelay()
    {
        this.gameObject.GetComponent<DialogueType1>().enabled = true;
    }
}
