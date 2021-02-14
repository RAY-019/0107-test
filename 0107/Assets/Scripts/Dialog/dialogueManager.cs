using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class dialogueManager : MonoBehaviour
{
    public static dialogueManager instance;

    public GameObject dialogueBox;
    public Text dialogueText, nameText;

    [TextArea(1, 3)]
    public string[] dialogueLines;

    [SerializeField] private int currentLine;

    //以下代碼

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        dialogueText.text = dialogueLines[currentLine];
    }

    private void Update()
    {
        if (dialogueBox.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentLine++;

                if (currentLine < dialogueLines.Length)
                {
                    CheckName();
                    dialogueText.text = dialogueLines[currentLine];
                }

                else
                {
                    dialogueBox.SetActive(false);
                    //FindObjectOfType<moveNplayer>().canMove = true;
                    //FindObjectOfType<moveHplayer>().canMove = true;
                    //FindObjectOfType<moveFplayer>().canMove = true;
                    //FindObjectOfType<moveKplayer>().canMove = true;
                }
            }
        }
    }

    public void ShowDialogue(string[] _newLines)
    {
        dialogueLines = _newLines;
        currentLine = 0;

        CheckName();

        dialogueText.text = dialogueLines[currentLine];
        dialogueBox.SetActive(true);

        //FindObjectOfType<moveNplayer>().canMove = true;
        //FindObjectOfType<Player>().canMove = true;
        //FindObjectOfType<moveFplayer>().canMove = true;
        //FindObjectOfType<moveKplayer>().canMove = true;
        //FindObjectOfType<eventText>().theText.SetActive(false);
    }

    private void CheckName()
    {
        if (dialogueLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogueLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }
}
