using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDoor : MonoBehaviour
{
    public GameObject GoToNextColl;
    public Animator door_anim;
    public bool isDoorMove;
    public static bool isDoorOpen;
    void Start()
    {
        GoToNextColl.GetComponent<Collider2D>().enabled = false;
        door_anim = GetComponent<Animator>();
        isDoorMove = false;
        isDoorOpen = false;
    }
    private void Update()
    {
        if (isDoorMove)
        {
            Invoke("DoorisOpen", 0.2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Attack"))
        {
            door_anim.SetTrigger("Move");
            isDoorMove = true;
        }
    }
    void DoorisOpen()
    {
        door_anim.SetTrigger("Open");
        isDoorOpen = true;
        GoToNextColl.GetComponent<Collider2D>().enabled = true;
    }
    
}
