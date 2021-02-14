using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDialog : MonoBehaviour
{
    public float delayShowTime;
    public GameObject dialogPrefeb;
    public string dialog;

    private float insTime;

    private void Start()
    {
        insTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - insTime >= delayShowTime)
        {
            dialogPrefeb.SendMessage("ShowDialog", dialog);
            enabled = false;
        }
    }
}
