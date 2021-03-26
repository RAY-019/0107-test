using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextScene : MonoBehaviour
{
    public static bool isWalkButton;
    private void Start()
    {
        isWalkButton = false;
    }
    private void Update()
    {
        GoToNext();
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == ("Player"))
        {
            isWalkButton = true;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == ("Player"))
        {
            isWalkButton = false;
        }
    }
   
    void GoToNext()
    {
        if (Input.GetKeyDown(KeyCode.Q) && isWalkButton)//1-1-0房間門打開
        {
            SceneManager.LoadScene("1-1-1");
            Debug.Log("go");
        }
    }
}
