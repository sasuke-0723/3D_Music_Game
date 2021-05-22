using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NoteEditor.DTO;

namespace GameScreen
{
    /// <summary>
    /// ノート自身が持つクラス
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class Note : MonoBehaviour
    {
        public NoteType noteType = NoteType.Tap;

        LoadManager load = new LoadManager();
        AudioManager clip;
        NotesCreator note;
        NotesManager noteManager;

        float judgLinePosY;
        float notePosY;
        float notePosZ;

        float NoteJudgTiming;

        void Awake()
        {
            clip = GameObject.Find("MusicSource").GetComponent<AudioManager>();
            load = GameObject.Find("LoadManager").GetComponent<LoadManager>();
            note = GameObject.Find("CreateNotes").GetComponent<NotesCreator>();
            noteManager = GameObject.Find("NotesManager").GetComponent<NotesManager>();
            NoteJudgTiming = note.note.num * load.OneBeatTime;
            judgLinePosY = note.JudgmentLine.position.y;
        }

        void Update()
        {
            notePosY = (judgLinePosY - (judgLinePosY * noteManager.NoteSpeed * (NoteJudgTiming - clip.Music.time))) / Mathf.Sqrt(3.0f);
            notePosZ = judgLinePosY - (judgLinePosY * noteManager.NoteSpeed * (NoteJudgTiming - clip.Music.time));

            transform.position = new Vector3(
                transform.position.x,
                notePosY,
                notePosZ);
        }
    }
}