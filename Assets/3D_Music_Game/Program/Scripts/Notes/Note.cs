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

        Transform noteClearZone;

        LoadManager load;
        AudioManager clip;
        NotesCreator note;
        NotesManager noteManager;
        GameManager gameManager;

        float judgLinePosY;
        float notePosY;
        float notePosZ;

        /// <summary> ノートが判定ラインに重なるタイミング </summary>
        public float NoteJudgTiming { get; private set; }
        /// <summary> ノートのレーン番号 </summary>
        public int LaneNum { get; private set; }

        public int NoteNumber
        {
            get { return gameObject.activeSelf ? LaneNum : int.MinValue; }
        }

        public float AbsoluteTimeLag
        {
            get { return Mathf.Abs(NoteJudgTiming - clip.Music.time); }
        }

        void Awake()
        {
            clip = GameObject.Find("MusicSource").GetComponent<AudioManager>();
            load = GameObject.Find("LoadManager").GetComponent<LoadManager>();
            note = GameObject.Find("CreateNotes").GetComponent<NotesCreator>();
            noteManager = GameObject.Find("NotesManager").GetComponent<NotesManager>();
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            noteClearZone = GameObject.Find("NoteClearZone").GetComponent<Transform>();

            NoteJudgTiming = note.noteData.num * load.OneBeatTime;
            LaneNum = note.noteData.block;
            judgLinePosY = note.JudgmentLine.position.y;
        }

        void Update()
        {
            var timeLag = NoteJudgTiming - clip.Music.time;
            if (timeLag < -GameManager.BAD_BORDER)
            {
                gameManager.OnNoteMiss();
                gameObject.SetActive(false);
            }

            notePosZ = judgLinePosY - (judgLinePosY * noteManager.NoteSpeed * (NoteJudgTiming - clip.Music.time));
            notePosY = notePosZ / Mathf.Sqrt(3.0f);

            transform.position = new Vector3(
                transform.position.x,
                notePosY,
                notePosZ);
        }
    }
}