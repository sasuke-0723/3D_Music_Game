using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using NoteEditor.DTO;

public class LoadTest : MonoBehaviour
{
    /// <summary> 譜面が保存されている場所 </summary>
    string filePath = "NotesData/OVERFLOW";
    public string FilePath { get { return filePath; } }
    /// <summary> 楽曲名 </summary>
    public string Name { get; private set; }
    /// <summary> レーンの総数 </summary>
    public int MaxBlock { get; private set; }
    /// <summary> 1分間に四分音符が何拍なるか </summary>
    public float BPM { get; private set; }
    /// <summary> 譜面の開始位置 </summary>
    public int Offset { get; private set; }
    /// <summary> </summary>
    public List<MusicDTO.Note> Notes { get; private set; }
    public List<MusicDTO.Note> Notes1 { get; private set; }
    /// <summary> 1拍の内にプレイカーソルが何ライン進むか </summary>
    public List<int> LPB { get; private set; } = new List<int>();
    /// <summary> TODO 今のところ何に使うのか分かっていない </summary>
    public List<int> Num { get; private set; } = new List<int>();
    /// <summary> レーンの番号 </summary>
    public List<int> Block { get; private set; } = new List<int>();
    /// <summary> Notesの種類 </summary>
    public List<int> Type { get; private set; } = new List<int>();

    private void Start()
    {

    }

    /// <summary>
    /// 譜面からNotesの情報を取得して格納する
    /// </summary>
    public void LoadNotesData()
    {
        string input = Resources.Load<TextAsset>(filePath).ToString();
        MusicDTO.EditData notes = JsonUtility.FromJson<MusicDTO.EditData>(input);
    }
}