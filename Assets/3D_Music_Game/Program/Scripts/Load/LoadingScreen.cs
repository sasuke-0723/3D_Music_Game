using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    /// <summary> 非同期動作で使用するAsyncOperation </summary>
    AsyncOperation async;
    /// <summary> シーンロード中に表示するUI画面 </summary>
    [SerializeField] GameObject loadUI;
    /// <summary> 読み込み率を表示するスライダー </summary>
    [SerializeField] Slider slider;

    public void NextScene()
    {
        // ロード画面UIをアクティブにする
        loadUI.SetActive(true);
        // コルーチン開始
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        // シーンの読み込みをする
        async = SceneManager.LoadSceneAsync("GameScene");

        // 読み込みが終わるまで進捗状況をスライダーの値に反映させる
        while (!async.isDone)
        {
            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            slider.value = progressVal;
            yield return null;
        }
    }
}
