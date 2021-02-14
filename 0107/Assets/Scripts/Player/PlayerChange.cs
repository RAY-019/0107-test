using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    public GameObject Now_maz,n_maz,nf_maz,fork;
    public Transform n_maz_pos;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (forkTrigger.getFork)
            {
                Instantiate(nf_maz,n_maz_pos.position,Quaternion.identity,Now_maz.transform);
                Destroy(n_maz);
                Destroy(fork);
            }
        }
    }
}
