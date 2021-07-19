using SwordGame;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BoriousKnightSpecialAttack : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float time;
    public float damage;
    [SerializeField] Animator animator;
    [SerializeField] public GameObject hitbox;
    [SerializeField] GameObject player;
    public bool SpecialActivated = false;

    public bool DecreaseEnergy;

    public IEnumerator Attack()
    {
        DecreaseEnergy = true;
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Sfx_BK_S_walk");
        }
        hitbox.SetActive(true);
        yield return new WaitForSeconds(time);
        DecreaseEnergy = false;
        GetComponentInParent<PSMController>().CurrentEnergy = (int)GetComponentInParent<PSMController>().CurrentEnergy;
        hitbox.SetActive(false);
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Stop("Sfx_BK_S_walk");
        }
        animator.SetBool("IsAttack", false);
    }

    private void Update()
    {
        if (GetComponentInParent<PSMController>().GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Player Die State"))
        {
            hitbox.SetActive(false);
            speed = 0;
            SpecialActivated = false;
        }
        if (DecreaseEnergy == true)
        {
            GetComponentInParent<PSMController>().CurrentEnergy -= Time.deltaTime * ((GetComponentInParent<PSMController>().MaxEnergy / time));
            EnergyBar.EBInstance.glowing.GetComponent<Image>().fillAmount -= (Time.deltaTime * ((GetComponentInParent<PSMController>().MaxEnergy / time)) / 100);
        }
    }

    public void Move()
    {
        if (SpecialActivated == true)
        {

            if (Input.GetKey(KeyBinding.KeyBindSet(KeyBinding.KeyBindInstance.StringKeyLeft)) || KeyBinding.KeyBindInstance.SetAxisSign(KeyBinding.KeyBindInstance.ControllerStringKeyLeft) || Input.GetKey(KeyBinding.KeyBindSetController(KeyBinding.KeyBindInstance.ControllerStringKeyLeft))/*|| Input.GetAxisRaw("DPad X") < 0*/)
                player.transform.rotation = Quaternion.Euler(0, 180, 0);

            if (Input.GetKey(KeyBinding.KeyBindSet(KeyBinding.KeyBindInstance.StringKeyRight)) || KeyBinding.KeyBindInstance.SetAxisSign(KeyBinding.KeyBindInstance.ControllerStringKeyRight) || Input.GetKey(KeyBinding.KeyBindSetController(KeyBinding.KeyBindInstance.ControllerStringKeyRight))/*|| Input.GetAxisRaw("DPad X") > 0*/)
                player.transform.rotation = Quaternion.Euler(0, 0, 0);


            if (player.transform.rotation.eulerAngles.y == 180)
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(-(speed * Time.deltaTime), player.GetComponent<Rigidbody2D>().velocity.y);

            if (player.transform.rotation.eulerAngles.y == 0)
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Time.deltaTime, player.GetComponent<Rigidbody2D>().velocity.y);
        }

        //player.transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
