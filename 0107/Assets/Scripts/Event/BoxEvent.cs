using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEvent : MonoBehaviour
{
    [Header("對話框&圖片")]
    public GameObject BoxDialog;
    public GameObject BoxLock, BoxOpen, BoxImg;
    void Start()
    {
        BoxDialog.SetActive(false);
        BoxLock.SetActive(false); 
        BoxOpen.SetActive(false); 
        BoxImg.SetActive(false);
    }

    void Update()
    {
        if(boxTrigger.getBox && Input.GetKeyDown(KeyCode.Q))
        {
            BoxDialog.SetActive(true);
            BoxImg.SetActive(true);
        }
    }
}
