using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickEvent : MonoBehaviour
{
    public GameObject TransitionsPanel,OpenGameUI;
    public static bool isClosePanel;

    void Start()
    {
        OpenGameUI.SetActive(true);
        TransitionsPanel.SetActive(false);
        isClosePanel = false;
    }

    void Update()
    {
        
        
    }

    public void OpenGame()
    {
        TransitionsPanel.SetActive(true);
        OpenGameUI.SetActive(false);
        isClosePanel = true;
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
