using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDialog : MonoBehaviour
{
    public GameObject dialogPrefeb;
    public string dialog;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Character"))
        {
            dialogPrefeb.SendMessage("ShowDialog", dialog);
            enabled = false;
        }
    }
}
