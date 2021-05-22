using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScreen
{
    /// <summary>
    /// ノートを管理するクラス
    /// </summary>
    public class NotesManager : MonoBehaviour
    {
        [SerializeField] float noteSpeed = 5f;
        public float NoteSpeed => noteSpeed;
    }
}