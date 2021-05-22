using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScreen
{
    public class JudgmentLine : MonoBehaviour
    {
        AudioSource se;
        ScoreManager scoreManager;
        int score = 100;
        LoadManager load;
        int i = 0;
        AudioManager clip;

        void Start()
        {
            se = GameObject.Find("SE").GetComponent<AudioSource>();
            scoreManager = GameObject.Find("Score").GetComponent<ScoreManager>();
            load = GameObject.Find("LoadManager").GetComponent<LoadManager>();
            clip = GameObject.Find("MusicSource").GetComponent<AudioManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Note"))
            {
                se.Play();
                scoreManager.UpdateScore(score);
                Debug.Log(clip.Music.time);
                Debug.Log(load.NoteJudgTiming[i++]);
            }
        }
    }
}