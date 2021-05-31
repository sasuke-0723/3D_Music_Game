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
        public int LaneNum { get; private set; }

        void Awake()
        {
            clip = GameObject.Find("MusicSource").GetComponent<AudioManager>();
            load = GameObject.Find("LoadManager").GetComponent<LoadManager>();
            note = GameObject.Find("CreateNotes").GetComponent<NotesCreator>();
            noteManager = GameObject.Find("NotesManager").GetComponent<NotesManager>();
            NoteJudgTiming = note.noteData.num * load.OneBeatTime;
            LaneNum = note.noteData.block;
            judgLinePosY = note.JudgmentLine.position.y;
        }

        void Update()
        {
            notePosZ = judgLinePosY - (judgLinePosY * noteManager.NoteSpeed * (NoteJudgTiming - clip.Music.time));
            notePosY = notePosZ / Mathf.Sqrt(3.0f);

            transform.position = new Vector3(
                transform.position.x,
                notePosY,
                notePosZ);
        }
    }
}