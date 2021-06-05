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
    /// <summary>
    /// ゲームの状態変数
    /// </summary>
    public enum GameState
    {
        Title,
        Select,
        Playing,
        GameClear,
        GameOver,
        Result
    }

    /// <summary>
    /// ゲームの進行を管理するクラス
    /// </summary>
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        public const float PERFECT_BORDER = 0.05f;
        public const float GREAT_BORDER = 0.1f;
        public const float GOOD_BORDER = 0.2f;
        public const float BAD_BORDER = 0.5f;

        [SerializeField] AudioManager audioManager;
        [SerializeField] ScoreManager scoreManager;
        NotesCreator note;
        LoadManager load;
        Note[] noteObj;

        KeyCode[] keys = new KeyCode[] { KeyCode.A, KeyCode.D, KeyCode.G, KeyCode.J, KeyCode.L };

        void Start()
        {
            note = GameObject.Find("CreateNotes").GetComponent<NotesCreator>();
            load = GameObject.Find("LoadManager").GetComponent<LoadManager>();
            //noteObj = FindObjectsOfType<Note>();
        }

        void Update()
        {
            for (int laneNum = 0; laneNum < keys.Length; laneNum++)
            {
                if (Input.GetKeyDown(keys[laneNum]))
                {
                    GetTheClosestNote(laneNum);
                }
            }
        }

        /// <summary>
        /// 押したキーに対応したノートの中で最も近いものを取得
        /// </summary>
        /// <param name="laneNum"> レーン番号 </param>
        /// <returns> 一番近いオブジェクト </returns>
        void GetTheClosestNote(int laneNum)
        {
            var targetNote = FindObjectsOfType<Note>()
                .Where(note => note.NoteNumber == laneNum)
                .OrderBy(note => note.AbsoluteTimeLag)
                .FirstOrDefault(note => note.AbsoluteTimeLag <= BAD_BORDER);

            var timeLag = targetNote.AbsoluteTimeLag;
            switch (timeLag)
            {
                case float time when time <= PERFECT_BORDER:
                    OnNotePerfect();
                    break;
                case float time when time <= GREAT_BORDER:
                    OnNoteGreat();
                    break;
                case float time when time <= GOOD_BORDER:
                    OnNoteGood();
                    break;
                case float time when time <= BAD_BORDER:
                    OnNoteBad();
                    break;
                default:
                    break;
            }
            targetNote.gameObject.SetActive(false);

            //Debug.Log(targetNote.name);
        }

        public void OnNotePerfect()
        {
            scoreManager.UpdateScore(1000);
            Debug.Log("Perfect");
        }
        public void OnNoteGreat()
        {
            scoreManager.UpdateScore(500);
            Debug.Log("Great");
        }
        public void OnNoteGood()
        {
            scoreManager.UpdateScore(250);
            Debug.Log("Good");
        }
        public void OnNoteBad()
        {
            scoreManager.UpdateScore(100);
            Debug.Log("Bad");
        }
        public void OnNoteMiss()
        {
            Debug.Log("Miss");
        }
    }
}