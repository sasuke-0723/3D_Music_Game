using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NoteEditor.DTO;
using System.IO;
using System.Text;

namespace GameScreen
{
    /// <summary>
    /// ノートを生成するクラス
    /// </summary>
    public class NotesCreator : ObjectPool
    {
        /// <summary> タップノーツ </summary>
        [SerializeField] GameObject tapNote;
        /// <summary> ホールドノーツ </summary>
        [SerializeField] GameObject holdNote;
        /// <summary> フリックノーツ </summary>
        [SerializeField] GameObject flickNote;
        /// <summary> 最初にInstance化するObjectの数 </summary>
        [SerializeField] int initNotesCount;
        /// <summary> 追加でInstance化するObjectの数 </summary>
        [SerializeField] int createNotesCount;
        /// <summary> Noteの角度 </summary>
        Quaternion angle = Quaternion.Euler(-30, 0, 0);
        [SerializeField] Transform judgmentLine;
        public Transform JudgmentLine => judgmentLine;
        public float SpawnPoint { get; private set; }
        [SerializeField] GameObject notesParent;

        LoadManager load;
        AudioManager clip;
        NotesManager noteManager;

        public MusicDTO.Note noteData { get; private set; }

        void Awake()
        {
            load = GameObject.Find("LoadManager").GetComponent<LoadManager>();
            clip = GameObject.Find("MusicSource").GetComponent<AudioManager>();
            noteManager = GameObject.Find("NotesManager").GetComponent<NotesManager>();

            CreateNotes();
            clip.PlayAudioClip();
        }

        /// <summary>
        /// ノートを生成する
        /// </summary>
        void CreateNotes()
        {
            float distance = noteManager.NoteSpeed * load.OneBeatTime;

            for (int i = 0; i < load.Notes.Count; i++)
            {
                Vector3 notePos = new Vector3(-3.8f + load.Notes[i].block * 1.9f,
                judgmentLine.position.y + load.Num[i] * distance / Mathf.Sqrt(3.0f),
                judgmentLine.position.y + load.Num[i] * distance);

                noteData = load.Notes[i];

                switch (load.Notes[i].type)
                {
                    case 1:
                        CreatePool(notesParent, tapNote, notePos, angle);
                        break;
                    //case 2:
                    //    CreatePool(tapNote, notePos, angle);
                    //    break;
                    //case 3:
                    //    CreatePool(flickNote, notePos, angle);
                    //    break;
                    default:
                        break;
                }
            }
        }
    }
}