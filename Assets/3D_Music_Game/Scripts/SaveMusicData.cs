using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class SaveMusicData : MonoBehaviour
{
    private const string FilePath = "Resources/NotesData/TestFile";

    private void Awake()
    {
        MusicData music = new MusicData()
        {
            name = "OVERFLOW",
        };
        MusicDataWriter(music);
    }

    public void MusicDataWriter(MusicData musicData)
    {
        string jsonstr = JsonUtility.ToJson(musicData, prettyPrint: true);
        StreamWriter streamWriter;
        streamWriter = new StreamWriter(Application.dataPath + "/" + FilePath + ".json", false);
        streamWriter.WriteLine(jsonstr);
        streamWriter.Flush();
        streamWriter.Close();
    }
}
