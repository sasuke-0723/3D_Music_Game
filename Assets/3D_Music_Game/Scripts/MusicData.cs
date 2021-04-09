using System;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

[Serializable]
public struct MusicData
{
    public string name;
    public int maxBlock;
    public int BPM;
    public int offset;
    public List<NotesData> notes;
}

[Serializable]
public struct NotesData
{
    public int LPB;
    public int num;
    public int block;
    public int type;
    public List<NotesData> notes;
}