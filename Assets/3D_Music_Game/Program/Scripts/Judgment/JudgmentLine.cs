using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgmentLine : MonoBehaviour
{
    AudioSource se;
    ScoreManager scoreManager;
    int score = 100;

    void Start()
    {
        se = GameObject.Find("SE").GetComponent<AudioSource>();
        scoreManager = GameObject.Find("Score").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            se.Play();
            scoreManager.UpdateScore(score);
        }
    }
}
