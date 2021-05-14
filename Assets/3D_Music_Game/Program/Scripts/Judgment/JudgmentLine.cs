using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgmentLine : MonoBehaviour
{
    AudioSource se;
    ScoreManager scoreManager;
    int score = 100;
    NotesCreater note;
    int i = 0;
    AudioManager clip;

    void Start()
    {
        se = GameObject.Find("SE").GetComponent<AudioSource>();
        scoreManager = GameObject.Find("Score").GetComponent<ScoreManager>();
        note = GameObject.Find("CreateNotes").GetComponent<NotesCreater>();
        clip = GameObject.Find("MusicSource").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            se.Play();
            scoreManager.UpdateScore(score);
            Debug.Log(clip.Music.time);
            Debug.Log(note.NoteJudgTiming[i++]);
        }
    }
}
