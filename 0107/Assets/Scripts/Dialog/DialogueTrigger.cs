using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject Button, talkUI;
    public static bool ImgOpen, UIOpen;

    private void Start()
    {
        Button.SetActive(false);
        talkUI.SetActive(false);
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
            talkUI.SetActive(true);
            ImgOpen = true;
            UIOpen = true;
        }
    }
}
