using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionsPanel : MonoBehaviour
{
    public Image blackBG;
    [SerializeField] private float alpha;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string _sceneName)
    {
        StartCoroutine(FadeOut(_sceneName));
    }

    IEnumerator FadeIn()
    {
        alpha = 1;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime;
            blackBG.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(0);
        }
    }

    IEnumerator FadeOut(string sceneName)
    {
        alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime;
            blackBG.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}
