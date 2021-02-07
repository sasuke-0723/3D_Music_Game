using System;
using System.Collections.Generic;

[Serializable]
public struct MusicData
{
    public string songTitle;
    public int    bpm;
    public List<NotesData> notesData;
}

[Serializable]
public struct NotesData
{
    public string noteType;
    public int    laneValue;
    public float  timing;
    public string judgment;
}