using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    [Header("角色切換")]
    public GameObject[] Maz_form = { null, null };//紀錄子物件的陣列
    private int form_index;
    void Start()
    {
        Maz_form[0] = this.transform.GetChild(0).gameObject;
        Maz_form[1] = this.transform.GetChild(1).gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            form_index = PlayerController.Maz_ID_Now;
            
        }
    }
}
