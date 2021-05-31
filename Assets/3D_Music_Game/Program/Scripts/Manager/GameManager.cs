using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using UnityEngine.Events;
using System.Linq;
using NoteEditor.DTO;

namespace GameScreen
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        const float PERFECT_BORDER = 0.05f;
        const float GREAT_BORDER = 0.1f;
        const float GOOD_BORDER = 0.2f;
        const float BAD_BORDER = 0.5f;

        [SerializeField] AudioManager audioManager;
        NotesCreator note;
        LoadManager load;
        //List<Note> noteObj = new List<Note>();
        //Note[] noteObj;
        //GameObject[] noteObj;
        Note[] noteObj;
        GameObject[] obj;

        float previousTime = 0f;

        KeyCode[] keys = new KeyCode[] { KeyCode.A, KeyCode.D, KeyCode.G, KeyCode.J, KeyCode.L };
        //Dictionary<KeyCode, int> keys = new Dictionary<KeyCode, int>()
        //{
        //    { KeyCode.A, 0 },
        //    { KeyCode.D, 1 },
        //    { KeyCode.G, 2 },
        //    { KeyCode.J, 3 },
        //    { KeyCode.L, 4 },
        //};

        void Start()
        {
            note = GameObject.Find("CreateNotes").GetComponent<NotesCreator>();
            load = GameObject.Find("LoadManager").GetComponent<LoadManager>();
            obj = GameObject.FindGameObjectsWithTag("Note");
        }

        void Update()
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (Input.GetKeyDown(keys[i]))
                {
                    for (int j = 0; j < obj.Length; j++)
                    {
                        if (noteObj[i].LaneNum == i)
                        {
                            noteObj[i] = GameObject.FindGameObjectWithTag("Note").GetComponent<Note>();
                            Debug.Log(noteObj[i].LaneNum);
                        }
                    }
                }
            }
        }

        void OnNotePerfect()
        {
            Debug.Log("Perfect");
        }
        void OnNoteGreat()
        {
            Debug.Log("Great");
        }
        void OnNoteBad()
        {
            Debug.Log("Bad");
        }
        void OnNoteMiss()
        {
            Debug.Log("Miss");
        }

        void GetOnNoteKeyTypeAction(int laneNumber)
        {

        }
    }
}