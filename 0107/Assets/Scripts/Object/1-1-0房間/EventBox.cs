using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBox : MonoBehaviour
{
    public Animator anim;
    public GameObject Fork = null;
    void Start()
    {
        anim = GetComponent<Animator>();
        Fork.SetActive(false);
    }

    void Update()
    {
        Box();
    }
    void Box()
    {
        if (DialogueTrigger.isTrueFinishEvent && Fork != null)
        {
            anim.SetTrigger("open");
            Fork.SetActive(true);
        }
    }
}
