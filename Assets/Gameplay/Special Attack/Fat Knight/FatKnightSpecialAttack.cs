using SwordGame;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FatKnightSpecialAttack : MonoBehaviour
{
    public List<GameObject> enemyList = new List<GameObject>();
    public EnemyData[] obj;
    Boss boss;
    public int i = 0;
    [SerializeField] GameObject stompPrefab;
    public Animator animator;

    public float time;
    public bool DecreaseEnergy;
    public bool ResetDecrease;

    private void Update()
    {
        if (DecreaseEnergy == true)
        {
            GetComponentInParent<PSMController>().CurrentEnergy -= Time.deltaTime * ((GetComponentInParent<PSMController>().MaxEnergy / time));
            EnergyBar.EBInstance.glowing.GetComponent<Image>().fillAmount -= (Time.deltaTime * ((GetComponentInParent<PSMController>().MaxEnergy / time)) / 100);

            ResetDecrease = false;
        }
        if (DecreaseEnergy == true && ResetDecrease == false && GetComponentInParent<PSMController>().CurrentEnergy <= 0)
        {
            DecreaseEnergy = false;
            ResetDecrease = true;
            if (GetComponentInParent<PSMController>().CurrentEnergy < 0)
            {
                GetComponentInParent<PSMController>().CurrentEnergy = 0;
            }
            else
            {
                GetComponentInParent<PSMController>().CurrentEnergy = (int)GetComponentInParent<PSMController>().CurrentEnergy;
            }
        }
    }

    public void Findenemy()
    {
        DecreaseEnergy = true;
        Array.Clear(obj, 0, obj.Length);
        enemyList.Clear();
        enemyList.TrimExcess();
        i = 0;
        obj = FindObjectsOfType<EnemyData>();
        boss = FindObjectOfType<Boss>();

        if (boss != null)
            enemyList.Add(boss.gameObject);

        if (obj.Length != 0)
        {
            foreach (EnemyData go in obj)
            {
                if (go.isActiveAndEnabled)
                {
                    enemyList.Add(go.gameObject);
                }
            }
        }
    }

    public void InstantiateStomps()
    {
        Instantiate(stompPrefab, new Vector2(enemyList[i].transform.position.x, enemyList[i].transform.position.y + 8), transform.rotation);
    }
}
