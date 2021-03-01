using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject Button, TalkUI;
    public GameObject EventUI = null;
    private void Start()
    {
        Button.SetActive(false);
        TalkUI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Button.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Button.SetActive(false);
      
    }

    private void Update()
    {
        if(Button.activeSelf && Input.GetKeyDown(KeyCode.Q))
        {
            TalkUI.SetActive(true);
        }
        if(DialogueSystem.UIOpen)
        {
            EventUI.SetActive(true);
        }
        else
        {
            EventUI.SetActive(false);
        }
        
    }
}
