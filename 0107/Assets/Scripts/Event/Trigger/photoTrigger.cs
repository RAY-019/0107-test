using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photoTrigger : MonoBehaviour
{
    public GameObject Dialogue,EventUI;
    public bool isEvent;
    private void Start()
    {
        Dialogue.SetActive(false);
        EventUI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isEvent = true;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isEvent = false;
        }
    }
    void Update()
    {
        ShowDialogue();
    }
    void ShowDialogue()
    {
        if(DialogueTrigger.isTalkButton && isEvent)
        {
            Dialogue.SetActive(true);
        }
    }
}
