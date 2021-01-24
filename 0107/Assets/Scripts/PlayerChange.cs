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

        Maz_form[0].SetActive(true);
        Maz_form[1].SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            form_index = PlayerController.Maz_ID_Now; 

            if (forkTrigger.getFork)
            {
                form_index = 1;
                Maz_form[0].SetActive(false);
                Maz_form[1].SetActive(true);
            }
        }

        
        
    }

    

    void ChangeFinish()//將原本型態子物件關閉後，開啟新型態的子物件，並更新現在型態的ID
    {
        Maz_form[PlayerController.Maz_ID_Now].SetActive(false);
        Maz_form[form_index].SetActive(true);

        PlayerController.Maz_ID_Now = form_index;
    }

}
