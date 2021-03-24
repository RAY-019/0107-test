using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanelEvent : MonoBehaviour
{
    public GameObject editor;
    void Start()
    {
        editor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        EditorisTalk();
    }
    void EditorisTalk()
    {
        if (ButtonClickEvent.isClosePanel)
        {
            Invoke("EditorAppear", 1f);
        }
    }
    void EditorAppear()
    {
        editor.SetActive(true);
    }
}
