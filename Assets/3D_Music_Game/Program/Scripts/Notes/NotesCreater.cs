using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NoteEditor.DTO;
using System.IO;
using System.Text;

/// <summary>
/// ノートを生成するクラス
/// </summary>
public class NotesCreater : ObjectPool
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
    Quaternion angle = Quaternion.Euler(-30f, 0, 0);
    [SerializeField] Transform judgmentLine;

    LoadManager load = new LoadManager();
    AudioManager clip = new AudioManager();

    /// <summary> ノートが判定ラインに重なるタイミング </summary>
    public List<float> NoteJudgTiming { get; private set; } = new List<float>();

    void Awake()
    {
        load = GameObject.Find("LoadManager").GetComponent<LoadManager>();
        clip = GameObject.Find("MusicSource").GetComponent<AudioManager>();

        for (int i = 0; i < load.Notes.Count; i++)
        {
            float distance = Note.NoteSpeed * load.OneBeatTime;
            Vector3 notePos = new Vector3(-3.8f + load.Notes[i].block * 1.9f,
            load.Notes[i].num * distance / Mathf.Sqrt(3.0f),
            load.Notes[i].num * distance);
            NoteJudgTiming.Add(load.Notes[i].num * load.OneBeatTime);

            switch (load.Notes[i].type)
            {
                case 1:
                    CreatePool(tapNote, notePos, angle);
                    break;
                case 2:
                    CreatePool(holdNote, notePos, angle);
                    break;
                case 3:
                    CreatePool(flickNote, notePos, angle);
                    break;
                default:
                    break;
            }
        }
        clip.Music.Play();
    }
}

//(music.notes[i].num * note.NoteSpeed)
//(music.notes[i].num * note.NoteSpeed)
//judgLinePos.y + ((music.notes[i].num - clip.Music.time) * music.notes[i].LPB) / Mathf.Sqrt(3.0f),
//judgLinePos.z + (music.notes[i].num - clip.Music.time) * music.notes[i].LPB);
//music.BPM / 60f
//music.BPM / 60f
