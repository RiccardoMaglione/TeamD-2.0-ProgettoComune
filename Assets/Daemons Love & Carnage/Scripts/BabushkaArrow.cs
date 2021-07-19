using SwordGame;
using UnityEngine;
public class BabushkaArrow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInParent<MoveArrowEnemy>())
        {
            if (collision.gameObject.GetComponentInParent<MoveArrowEnemy>().gameObject.transform.rotation == Quaternion.Euler(0, 0, 0))
            {
                collision.gameObject.GetComponentInParent<MoveArrowEnemy>().gameObject.transform.rotation = new Quaternion(0, 1, 0, 0);
            }
            else if (collision.gameObject.GetComponentInParent<MoveArrowEnemy>().gameObject.transform.rotation == Quaternion.Euler(0, 180, 0))
            {
                collision.gameObject.GetComponentInParent<MoveArrowEnemy>().gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            Destroy(collision.gameObject.GetComponentInParent<MoveArrowEnemy>().gameObject.GetComponentInChildren<EnemyArrow>());
            collision.gameObject.AddComponent<PlayerArrow>();
            collision.gameObject.GetComponent<PlayerArrow>().ArrowParent = collision.gameObject.GetComponentInParent<MoveArrowEnemy>().gameObject;
            collision.gameObject.GetComponent<PlayerArrow>().ArrowParent.layer = 11;
            collision.gameObject.GetComponent<PlayerArrow>().gameObject.layer = 11;
            collision.gameObject.GetComponent<PlayerArrow>().DamageArrow = 200;
        }
    }
}
