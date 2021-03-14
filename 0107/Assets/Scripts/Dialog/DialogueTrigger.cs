using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject Button, EventUI, StartDialog, trueDialog, falseDialog;
    public static bool isTalkButton;
    public static bool isUIOpen;
    public bool isEvent;
    public bool isFinishEvent;
    public bool isTrueFinishEvent;

    private void Start()
    {
        isUIOpen = false;
        Button.SetActive(false);
        EventUI.SetActive(false);
        StartDialog.SetActive(false);
        trueDialog.SetActive(false);
        falseDialog.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        isTalkButton = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isTalkButton = false;
    }

    void Update()
    {
        StartDialogue();

        if (EventUI.activeInHierarchy)
        {
            isUIOpen = true;
        }
        else
        {
            isUIOpen = false;
        }
        if (falseDialog.activeInHierarchy)
        {
            isEvent = true;
        }
        else
        {
            isEvent = false;
            isFinishEvent = false;
        }
        if (falseDialog.activeInHierarchy)
        {
            isEvent = true;
            isFinishEvent = true;
        }
        else
        {
            isEvent = false;
            isFinishEvent = false;
        }

    }

    void StartDialogue()
    {
        if (isTalkButton && !isUIOpen && !isEvent && !isFinishEvent && !isTrueFinishEvent)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                StartDialog.SetActive(true);
                EventUI.SetActive(true);
            }
        }
    }

    public void CheckPassWord()
    {
        DialogueSystem.index = 0;
        if (EnterKey.isPasswordCorrect && isUIOpen)
        {
            StartDialog.SetActive(false);
            trueDialog.SetActive(true);
            falseDialog.SetActive(false);
            EventUI.SetActive(false);
            isTrueFinishEvent = true;
        }
        if (!EnterKey.isPasswordCorrect && isUIOpen)
        {
            StartDialog.SetActive(false);
            trueDialog.SetActive(false);
            falseDialog.SetActive(true);
            EventUI.SetActive(false);
        }
    }
}
