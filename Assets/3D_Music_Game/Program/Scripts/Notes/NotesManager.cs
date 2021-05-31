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
        [SerializeField]
        [Range(1, 10)] float noteSpeed = 5f;
        public float NoteSpeed => noteSpeed;
    }
}