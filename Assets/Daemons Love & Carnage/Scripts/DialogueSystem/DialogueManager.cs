using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public Text leftNameText;
    public Text rightNameText;
    public Text dialogueText;
    [HideInInspector]
    public bool isTalk = false;
    [SerializeField] float textSpeed;
    public GameObject leftPanel;
    public GameObject rightPanel;
    public GameObject blackPanel;

    public Animator animator;

    private Queue<string> sentences;
    private Queue<string> names;
    private Queue<Position> positions;

    [SerializeField] Animator impBossAnim;
    [SerializeField] Animator cutsceneAnim;

    GameObject player;

    void Awake()
    {
        positions = new Queue<Position>();
        sentences = new Queue<string>();
        names = new Queue<string>();

        if (instance == null)
            instance = this;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        blackPanel.SetActive(true); //11/04/21
        Time.timeScale = 0; //11/04/21


        animator.SetBool("isOpen", true);

        sentences.Clear();
        names.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (string name in dialogue.name)
        {
            names.Enqueue(name);
        }

        foreach (Position position in dialogue.position)
        {
            positions.Enqueue(position);
        }

        isTalk = true;

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        Position position = positions.Dequeue();
        StopAllCoroutines();
        //StartCoroutine(TypeSentence(sentence));
        TypeSentence(sentence);
        TypeName(name, position);
    }

    //IEnumerator TypeSentence(string sentence)
    //{
    //    dialogueText.text = "";
    //    foreach (char letter in sentence.ToCharArray())
    //    {
    //        dialogueText.text += letter;
    //        yield return new WaitForSeconds(textSpeed);
    //    }
    //}


    void TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
        }
    }

    void TypeName(string name, Position position)
    {
        if (position == Position.Left)
        {
            leftPanel.SetActive(true);
            rightPanel.SetActive(false);
            leftNameText.text = "";
            foreach (char letter in name.ToCharArray())
            {
                leftNameText.text += letter;
            }
        }

        else
        {
            leftPanel.SetActive(false);
            rightPanel.SetActive(true);
            rightNameText.text = "";
            foreach (char letter in name.ToCharArray())
            {
                rightNameText.text += letter;
            }
        }
    }

    void EndDialogue()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Animator>().enabled = false;
        
        isTalk = false;
        animator.SetBool("isOpen", false);
        impBossAnim.SetTrigger("GoToJump");
        cutsceneAnim.SetTrigger("GoToStomp");
        Time.timeScale = 1; //11/04/21
        blackPanel.SetActive(false); //11/04/21
    }
}
