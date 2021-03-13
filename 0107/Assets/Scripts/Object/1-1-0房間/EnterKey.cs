using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterKey : MonoBehaviour
{
    [Header("密碼格數據")]
    public GameObject[] slot;//密码格子数组
    string password;//正确密码
    public string inputPassword;//输入密码
    public static bool isPasswordCorrect;

    void Start()
    {
        password = "1000";
        isPasswordCorrect = false;
        DialogueTrigger.isUIOpen = true;
    }

    /// <summary>
    /// 检查密码方法
    /// </summary>
    public void CheckPass()
    {
        //将每个密码格子中的数字拼接成字符串，然后判断下
        for (int i = 0; i < slot.Length; i++)
        {
            inputPassword = inputPassword + slot[i].GetComponent<NumMove>().Num;
        }
        if (inputPassword == password)
        {
            print("解锁成功");
            isPasswordCorrect = true;
            //DialogueTrigger.isUIOpen = false;
        }
        else
        {
            print("密码错误");
            inputPassword = null;
            isPasswordCorrect = false;
            //DialogueSystem.isMove = false;
            //DialogueTrigger.isUIOpen = false;
        }
    }


}
