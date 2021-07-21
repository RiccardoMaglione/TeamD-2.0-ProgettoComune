using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Page", menuName = "Page")]
public class PageScriptableObject : ScriptableObject
{
    public int IDPage;
    public Vector3 StartPos;
    public Vector3 EndPos;
    public float EnterTransitionTime;
    public float ExitTransitionTime;
}
