using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTest : MonoBehaviour
{
    // フェードインのおおよその秒数
    [SerializeField] float fadeTimePerFlame;
    // 背景Image
    Image background;

    void Start()
    {
        background = transform.Find("FadeBackground").GetComponent<Image>();
        StartCoroutine(FadeIn());
    }

    /// <summary>
    /// ゲーム開始時にフェードインする
    /// </summary>
    /// <returns> fadeTimePerFlame </returns>
    IEnumerator FadeIn()
    {
        // ColorのAlpha値を0.1ずつ下げていく
        for (var alpha = 1.0f; alpha >= 0; alpha -= 0.1f)
        {
            alpha = float.Parse(alpha.ToString("F1"));
            background.color = new Color(0f, 0f, 0f, alpha);
            // 指定秒数待つ
            yield return new WaitForSeconds(fadeTimePerFlame);
        }
    }
}
