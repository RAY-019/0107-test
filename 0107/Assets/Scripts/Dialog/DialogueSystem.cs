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

    List<string> textList = new List<string>();
    

    void Awake()
    {
        GetTextFormFile(TextFile);
    }

    private void OnEnable()
    {
        TextLabel.text = textList[index];
        index++;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TextLabel.text = textList[index];
            index++;
        }
        if (Input.GetKeyDown(KeyCode.Q) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
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
}
