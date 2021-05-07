using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NoteEditor.DTO;
using System.IO;
using System.Text;

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

    LoadTest load = new LoadTest();
    MusicDTO.EditData music;

    void Awake()
    {
        try
        {
            FileInfo file = new FileInfo(load.FilePath);
            using (StreamReader sr = new StreamReader(file.OpenRead()))
            {
                music = JsonUtility.FromJson<MusicDTO.EditData>(sr.ReadToEnd());
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.LogError("指定されたファイルが見つかりませんでした\n" + e);
        }

        AudioManager clip = GameObject.Find("MusicSource").GetComponent<AudioManager>();
        // 小節の数
        float numberOfMeasures = music.BPM / 4f;
        // 一小節に掛かる時間(秒)
        float barPerSecond = 60f / numberOfMeasures;
        // 一拍に掛かる時間(秒) => ノーツの間隔
        float beatPerSecond = barPerSecond / 4;
        Vector3 judgLinePos = judgmentLine.position;
        for (int i = 0; i < music.notes.Count; i++)
        {
            float distance = Note.NoteSpeed * beatPerSecond;
            Vector3 notePos = new Vector3(-3.8f + music.notes[i].block * 1.9f,
                 music.notes[i].num * distance / Mathf.Sqrt(3.0f),
                 music.notes[i].num * distance);

            switch (music.notes[i].type)
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
