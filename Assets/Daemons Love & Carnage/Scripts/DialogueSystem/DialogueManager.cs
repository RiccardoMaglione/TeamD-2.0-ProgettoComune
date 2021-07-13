using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject playerObscured;
    public GameObject playerIlluminated;
    public GameObject bossObscured;
    public GameObject bossIlluminated;

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
        AudioManager.instance.Play("Sfx_skip_dialogue");

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
            playerIlluminated.SetActive(true);
            playerObscured.SetActive(false);
            bossIlluminated.SetActive(false);
            bossObscured.SetActive(true);

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
            playerIlluminated.SetActive(false);
            playerObscured.SetActive(true);
            bossIlluminated.SetActive(true);
            bossObscured.SetActive(false);

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
        playerIlluminated.SetActive(false);
        playerObscured.SetActive(false);
        bossIlluminated.SetActive(false);
        bossObscured.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player");

        isTalk = false;
        animator.SetBool("isOpen", false);
        impBossAnim.SetTrigger("GoToJump");
        cutsceneAnim.SetTrigger("GoToStomp");
        blackPanel.SetActive(false); //11/04/21
    }
}
