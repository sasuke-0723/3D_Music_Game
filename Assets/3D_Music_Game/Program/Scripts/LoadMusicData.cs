using UnityEngine;
using System.IO;

public class LoadMusicData : MonoBehaviour
{
    private const string FilePath = "Resources/NotesData/TestFile";

    public MusicData MusicDataReader()
    {
        string datastr = "";
        StreamReader streamReader;
        streamReader = new StreamReader(Application.dataPath + "/" + FilePath + ".json", false);
        datastr = streamReader.ReadToEnd();
        streamReader.Close();

        return JsonUtility.FromJson<MusicData>(datastr);
    }
}
