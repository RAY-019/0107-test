using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forkTrigger : MonoBehaviour
{
    [SerializeField] public static bool getFork;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            getFork = true;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            getFork = false;
        }
    }
}
