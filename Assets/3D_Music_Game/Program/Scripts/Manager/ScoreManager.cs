using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    public static event Action AtTheTimeOfJudgment;
    Text scoreText;
    int score = 0;
    const int MAX_SCORE = 1000000;
    Tween tween;

    void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    public void UpdateScore(int scoreToAdd)
    {
        DOTween.Kill(tween);
        tween = DOTween.To(() => score, value => score = value, score + scoreToAdd, 0.5f)
            .OnUpdate(() => scoreText.text = string.Format($"Score: {score:D7}"));
        //AtTheTimeOfJudgment?.Invoke();
    }
}