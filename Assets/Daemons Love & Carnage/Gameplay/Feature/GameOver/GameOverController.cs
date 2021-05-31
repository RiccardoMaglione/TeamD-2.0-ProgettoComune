using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public List<Sprite> ListEye = new List<Sprite>();
    public Image ImageEye;

    
    public List<Sprite> ListImageBoss = new List<Sprite>();
    public List<Image> ImageBoss = new List<Image>();
    
    public List<string> ListDialogue = new List<string>();
    public List<Text> TextDialogue = new List<Text>();

    
    // Start is called before the first frame update
    void Start()
    {
        RandomGameOver();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomGameOver()
    {
        int RndEye = Random.Range(0, ListEye.Count);
        ImageEye.sprite = ListEye[RndEye];

        int RndListBoss = Random.Range(0, ListImageBoss.Count);
        int RndImageBoss = Random.Range(0, ImageBoss.Count);
        ImageBoss[RndImageBoss].gameObject.SetActive(true);
        ImageBoss[RndImageBoss].sprite = ListImageBoss[RndListBoss];

        int RndListDialogue = Random.Range(0, ListDialogue.Count);
        int RndTextDialouge = Random.Range(0, TextDialogue.Count);
        TextDialogue[RndTextDialouge].gameObject.SetActive(true);
        TextDialogue[RndTextDialouge].text = ListDialogue[RndListDialogue];
    }

    public void ReturnMenu(string NameScene)
    {
        SceneManager.LoadScene(NameScene);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
