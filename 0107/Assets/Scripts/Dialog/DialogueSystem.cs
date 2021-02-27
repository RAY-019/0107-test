using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [Header("UI組件")]
    public TMP_Text TextLabel;
    public Image FaceImage;

    [Header("文本文件")]
    public TextAsset TextFile;
    public int index;
    public float textSpeed;

    [Header("頭像")]
    public Sprite face01, face02;

    bool textFinished;//是否完成打字
    bool cancelTyping;//取消打字

    List<string> textList = new List<string>();
    

    void Awake()
    {
        GetTextFormFile(TextFile);
        index = 0;
    }

    private void OnEnable()
    { 
        StartCoroutine(SetTextUI());
    }

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Q) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (textFinished && !cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if (!textFinished && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
    }

    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineData = file.text.Split('\n');//將字串依照行切割

        foreach(var line in lineData)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        TextLabel.text = "";

        switch (textList[index])
        {
            case "A\r":
                FaceImage.sprite = face01;
                index++;
                break;
            case "B\r":
                FaceImage.sprite = face02;
                index++;
                break;
        }
       
        int letter = 0;
        while (letter < textList[index].Length - 1 && !cancelTyping)
        {
            TextLabel.text += textList[index][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);
        }
        TextLabel.text = textList[index];
        cancelTyping = false;
        textFinished = true;
        index++;
    }
}
