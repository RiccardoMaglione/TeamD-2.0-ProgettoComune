using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordGame
{
    public class CheckpointController : MonoBehaviour
    {
        public static GameObject LastCheckpoint;
        [HideInInspector] public GameObject InspectorLastCheckpoint;
        public static TypePlayer PlayerCheckpoint;
        [HideInInspector] public TypePlayer InspectorPlayerCheckpoint;
        [HideInInspector] public int ID;

        private void Update()
        {
            InspectorPlayerCheckpoint = PlayerCheckpoint;
            InspectorLastCheckpoint = LastCheckpoint;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                Debug.Log("<color=fuchsia> Checkpoint Attivato </color>");
                PlayerCheckpoint = collision.gameObject.GetComponent<PSMController>().TypeCharacter;
                LastCheckpoint = gameObject;
                PlayerPrefs.SetInt("IDCheckpoint", ID);
                print(PlayerPrefs.GetInt("IDCheckpoint", 0));
            }
        }
    }
}

