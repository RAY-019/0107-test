using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxTrigger : MonoBehaviour
{
    public GameObject BoxUI;

    private void Update()
    {
        //if ()
        //{
            //talkUI.SetActive(true);
        //}
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            
        }
    }
}
