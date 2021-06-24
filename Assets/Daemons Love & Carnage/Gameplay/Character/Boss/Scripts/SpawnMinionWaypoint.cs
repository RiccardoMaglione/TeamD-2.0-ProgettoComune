using UnityEngine;

public class SpawnMinionWaypoint : MonoBehaviour
{
    public GameObject[] waypoints;
    [HideInInspector] public int i = 0;
    public float[] speed;
    float WPradius = 0.1f;
    Color32 invulnerableColor;

    private void Awake()
    {
        invulnerableColor = new Color32(121, 121, 121, 255);
    }
    public void Move()
    {
        if (i < waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[i].transform.position, Time.deltaTime * speed[i]);

            if ((Vector3.Distance(waypoints[i].transform.position, transform.position) < WPradius) && i < waypoints.Length)
            {
                i++;
            }
        }
    }

    public void ChangeColor()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(this.gameObject.GetComponent<SpriteRenderer>().color, invulnerableColor, 1f * Time.deltaTime);
    }

    public void ReturnNormalColor()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(this.gameObject.GetComponent<SpriteRenderer>().color, Color.white, 1f * Time.deltaTime);

    }

}
