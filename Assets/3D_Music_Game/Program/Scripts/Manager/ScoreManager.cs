using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace GameScreen
{
    public class ScoreManager : MonoBehaviour
    {
        /// <summary> スコアを表示するテキスト </summary>
        Text scoreText;
        /// <summary> 総スコア </summary>
        int totalScore = 0;
        Tween scoreTween;
        //int beforeScore = 0;

        void Awake()
        {
            scoreText = GetComponent<Text>();
        }

        /// <summary>
        /// 加算するスコアを受け取ってTextにアニメーションで反映させる
        /// </summary>
        /// <param name="scoreToAdd">加算されるスコア </param>
        public void UpdateScore(int scoreToAdd)
        {
            var currentScore = totalScore;
            var finalScore = currentScore + scoreToAdd;
            totalScore = finalScore;

            DOTween.Kill(scoreTween);
            scoreTween = DOTween.To(() => currentScore, value => currentScore = value, finalScore, 1.0f)
                .OnUpdate(() => scoreText.text = string.Format($"Score: {currentScore:D7}"));

            //tween.Kill();
            //beforeScore = beforeScore + scoreToAdd;
            //sequence.Append(tween = DOTween.To(() => score, value => score = value, score + scoreToAdd, 3.0f)
            //    .OnComplete(() => { score = beforeScore; })
            //    .OnKill(() => { score = beforeScore; })
            //    .OnUpdate(() => scoreText.text = string.Format($"Score: {score:D7}")));
        }
    }
}