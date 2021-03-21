using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject ObjectDialogue;
    public static bool isTalkButton;
    public static bool isStartEvent;
    public GameObject TalkColl;
    private void Start()
    {
        TalkColl.GetComponent<Collider2D>().enabled = false;
    }
    void Update()
    {
        if (TalkColl.GetComponent<Collider2D>().enabled == true)
        {
            ObjectDialogue.SetActive(true);
        }
        if (TalkColl.GetComponent<Collider2D>().enabled == false)
        {
            ObjectDialogue.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isTalkButton = true;
            TalkColl.GetComponent<Collider2D>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isTalkButton = false;
            TalkColl.GetComponent<Collider2D>().enabled = false;
        }
    }

   
}
