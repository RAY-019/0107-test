using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    public GameObject Now_maz,n_maz,nf_maz,fork;
    public Transform n_maz_pos;

    private void Start()
    {
        //fork.SetActive(false);
    }

    void Update()
    {
        PlayChange();
    }

    void PlayChange()
    {
        if (EnterKey.isPasswordCorrect)
        {
            //fork.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Q) && forkTrigger.getFork)
            {
                Instantiate(nf_maz, n_maz_pos.position, Quaternion.identity, Now_maz.transform);
                Destroy(n_maz);
                Destroy(fork);
            }
        }

    }
}
