using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NoteEditor.DTO;

public class NotesCreate : ObjectPool
{
    /// <summary> TapNotes </summary>
    [SerializeField] GameObject tapNotes;
    /// <summary> LongNotes </summary>
    [SerializeField] GameObject longNotes;
    /// <summary> 最初にInstance化するObjectの数 </summary>
    [SerializeField] int initNotesCount;
    /// <summary> 追加でInstance化するObjectの数 </summary>
    [SerializeField] int createNotesCount;

    LoadTest load = new LoadTest();

    void Awake()
    {
        string input = Resources.Load<TextAsset>(load.FilePath).ToString();
        MusicDTO.EditData music = JsonUtility.FromJson<MusicDTO.EditData>(input);

        for (int i = 0; i < initNotesCount; i++)
        {
            float notePosX = -3.8f + music.notes[i].block * 1.9f;
            float notePosY = 0;
            float notePosZ = 0;
            CreatePool(tapNotes, new Vector3(notePosX, notePosY, notePosZ),
                Quaternion.Euler(-30, 0, 0));
        }
    }
}
