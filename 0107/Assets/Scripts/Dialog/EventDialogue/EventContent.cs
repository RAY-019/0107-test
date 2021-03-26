using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventContent : MonoBehaviour
{
    public GameObject E_StartDialogue, E_FinDialogue;
    public static bool isEvent, isFinEvent;
    void Start()
    {
        E_StartDialogue.SetActive(false);
        E_FinDialogue.SetActive(false);
    }

    void Update()
    {
        StartDialogue();
    }
    void StartDialogue()
    {
        if (DialogueTrigger.isTalkButton)
        {
            if (!DialogueContent.isTrueFinishEvent)
            {
                E_StartDialogue.SetActive(true);
            }

        }
    }
}
