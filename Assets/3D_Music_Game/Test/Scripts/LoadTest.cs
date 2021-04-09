using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class LoadTest : MonoBehaviour
{
    private string filePath = "NotesData/OVERFLOW";
    public string FilePath { get; set; }
    private string path = "";

    private void Awake()
    {
        string input = Resources.Load<TextAsset>(filePath).ToString();
        MusicData musicData = JsonUtility.FromJson<MusicData>(input);
        Debug.Log(musicData.name);
        Debug.Log(musicData.maxBlock);
        Debug.Log(musicData.BPM);
        Debug.Log(musicData.offset);

        foreach (var item in musicData.notes)
        {
            Debug.Log(item.LPB);
            Debug.Log(item.num);
            Debug.Log(item.block);
            Debug.Log(item.type);
            foreach (var notes in item.notes)
            {
                Debug.Log(notes.LPB);
                Debug.Log(notes.num);
                Debug.Log(notes.block);
                Debug.Log(notes.type);
            }
        }
    }

    private void OnGUI()
    {
        GUI.TextArea(new Rect(0, 0, Screen.width, Screen.height), path);
    }

    string SetDefaultText()
    {
        return "ファイルを読み込めませんでした\n";
    }
}
