using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject Button, EventUI, StartDialog;
    public GameObject trueDialog = null;
    public GameObject falseDialog = null;
    public static bool isTalkButton;
    public static bool isUIOpen;
    public static bool isTrueFinishEvent;
    public bool isEvent;
    public bool isFinishEvent;

    private void Start()
    {
        isUIOpen = false;
        Button.SetActive(false);
        EventUI.SetActive(false);
        StartDialog.SetActive(false);
        if(trueDialog != null && falseDialog != null)
        {
            trueDialog.SetActive(false);
            falseDialog.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isTalkButton = true;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isTalkButton = false;
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
        if(falseDialog != null)
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
        if (isTalkButton && !isUIOpen && !isEvent && !isFinishEvent && !isTrueFinishEvent)
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
