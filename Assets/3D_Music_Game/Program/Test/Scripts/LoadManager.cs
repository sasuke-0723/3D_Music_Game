using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using NoteEditor.DTO;

public class LoadManager : MonoBehaviour
{
    /// <summary> 譜面が保存されている場所 </summary>
    string filePath = "/Users/sasuke/Documents/FonePaw/Notes/シャイニングスター.json";
    public string FilePath { get { return filePath; } }
    /// <summary> 楽曲名 </summary>
    public string Name { get; private set; }
    /// <summary> レーンの総数 </summary>
    public int MaxBlock { get; private set; }
    /// <summary> 1分間に四分音符が何拍なるか </summary>
    public float BPM { get; private set; }
    /// <summary> 譜面の開始位置 </summary>
    public int Offset { get; private set; }
    /// <summary> Noteのメンバ変数を保持する </summary>
    public List<MusicDTO.Note> Notes { get; private set; }
    /// <summary> 1拍の内にプレイカーソルが何ライン進むか </summary>
    public List<int> LPB { get; private set; } = new List<int>();
    /// <summary> 拍子番号 </summary>
    public List<int> Num { get; private set; } = new List<int>();
    /// <summary> レーンの番号 </summary>
    public List<int> Block { get; private set; } = new List<int>();
    /// <summary> Notesの種類 </summary>
    public List<int> Type { get; private set; } = new List<int>();
    /// <summary> ノートが判定ラインに重なるタイミング </summary>
    public List<float> NoteJudgTiming { get; private set; } = new List<float>();
    /// <summary> 小節の数 </summary>
    public float NumberOfMeasures { get; private set; }
    /// <summary> 一小節に掛かる時間(秒) </summary>
    public float OneBarTime { get; private set; }
    /// <summary> 一拍に掛かる時間(秒) </summary>
    public float OneBeatTime { get; private set; }

    MusicDTO.EditData musicalData;

    void Awake()
    {
        LoadNotesData();
        PropertyInitializer();
        SubstituteMusicalScoreData();
    }

    /// <summary>
    /// 譜面の小節数、一小節、一拍に掛かる時間を格納
    /// </summary>
    void PropertyInitializer()
    {
        NumberOfMeasures = musicalData.BPM / 4f;
        OneBarTime = 60f / NumberOfMeasures;
        OneBeatTime = OneBarTime / 16f;
    }

    /// <summary>
    /// 譜面からNotesの情報を取得して格納する
    /// </summary>
    void LoadNotesData()
    {
        try
        {
            FileInfo file = new FileInfo(filePath);
            using (StreamReader sr = new StreamReader(file.OpenRead()))
            {
                musicalData = JsonUtility.FromJson<MusicDTO.EditData>(sr.ReadToEnd());
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.LogError(e + "指定されたファイルが見つかりませんでした\n");
        }
    }

    /// <summary>
    /// 譜面データをプロパティに代入する
    /// </summary>
    void SubstituteMusicalScoreData()
    {
        Name = musicalData.name;
        MaxBlock = musicalData.maxBlock;
        BPM = musicalData.BPM;
        Offset = musicalData.offset;
        foreach (var data in musicalData.notes)
        {
            LPB.Add(data.LPB);
            Num.Add(data.num);
            Block.Add(data.block);
            Type.Add(data.type);
            NoteJudgTiming.Add(data.num * OneBeatTime);
        }
        Notes = musicalData.notes;
    }
}