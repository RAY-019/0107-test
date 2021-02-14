using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDialog : MonoBehaviour
{
    public GameObject dialogPrefeb;
    public string dialog;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Character"))
        {
            dialogPrefeb.SendMessage("ShowDialog", dialog);
            Destroy(gameObject);
        }
    }
}
