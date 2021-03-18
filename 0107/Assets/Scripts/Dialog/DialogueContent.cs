using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueContent : MonoBehaviour
{
    public GameObject EventUI, StartDialog;
    public GameObject trueDialog = null;
    public GameObject falseDialog = null;
    public static bool isUIOpen;
    public static bool isTrueFinishEvent;
    public bool isEvent;
    public bool isFinishEvent;

    private void Start()
    {
        isUIOpen = false;
        EventUI.SetActive(false);
        StartDialog.SetActive(false);
        if (trueDialog != null && falseDialog != null)
        {
            trueDialog.SetActive(false);
            falseDialog.SetActive(false);
        }
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
        if (falseDialog != null)
        {
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
    }

    void StartDialogue()
    {
        if (DialogueTrigger.isTalkButton && !isUIOpen && !isEvent && !isFinishEvent && !isTrueFinishEvent)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                StartDialog.SetActive(true);
                EventUI.SetActive(true);
            }
        }
    }

    public void CheckPassWord()//密碼鎖的對話
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
