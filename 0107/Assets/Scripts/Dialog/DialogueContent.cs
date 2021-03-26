using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueContent : MonoBehaviour
{
    public GameObject StartDialog;
    public GameObject EventUI, trueDialog, falseDialog, FinishDialog = null;

    public bool isEvent, isFinishEvent;
    public static bool isUIOpen, isTrueFinishEvent, isGetEventObject;
    private void Start()
    {
        isUIOpen = false;
        StartDialog.SetActive(false);
        if (EventUI != null)
        {
            EventUI.SetActive(false);
        }
        if (trueDialog != null)
        {
            trueDialog.SetActive(false);
        }
        if (falseDialog != null)
        {
            trueDialog.SetActive(false);
        }
        if (FinishDialog != null)
        {
            FinishDialog.SetActive(false);
        }
    }
    void Update()
    {
        StartDialogue();
        DialogueEvent();
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

    void DialogueEvent()
    {
        if (DialogueTrigger.isTalkButton && isGetEventObject && !isUIOpen && isTrueFinishEvent)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                FinishDialog.SetActive(true);
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
