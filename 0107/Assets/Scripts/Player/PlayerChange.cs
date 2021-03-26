using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    public GameObject Now_maz,nf_maz,n_maz_CM,nf_maz_CM;
    public GameObject n_maz = null;
    public GameObject fork = null;
    public Transform n_maz_pos;

    private void Start()
    {
        /*if (n_maz != null && fork != null && EnterKey.isPasswordCorrect)
        {
            fork.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Q) && forkTrigger.getFork && DialogueTrigger.isTrueFinishEvent)
            {
                GameObject new_nf_maz = Instantiate(nf_maz, n_maz_pos.position, Quaternion.identity, Now_maz.transform);
                Destroy(n_maz);
                n_maz_CM.SetActive(false);
                nf_maz_CM.SetActive(true);
                new_nf_maz.name = nf_maz.name.Replace("(Clone)", "");
                Destroy(fork);
            }
        }*/
    }

    void Update()
    {
        PlayChange();
    }

    void PlayChange()
    {
        if (n_maz != null && fork != null && EnterKey.isPasswordCorrect)
        {
            fork.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Q) && forkTrigger.getFork && DialogueContent.isTrueFinishEvent)
            {
                GameObject new_nf_maz =Instantiate(nf_maz, n_maz_pos.position, Quaternion.identity, Now_maz.transform);
                Destroy(n_maz);
                n_maz_CM.SetActive(false);
                nf_maz_CM.SetActive(true);
                new_nf_maz.name = nf_maz.name.Replace("(Clone)", "");
                Destroy(fork);
                DialogueContent.isGetEventObject = true;
            }
        }
    }
}
