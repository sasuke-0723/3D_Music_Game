using System;
using System.Collections.Generic;

namespace NoteEditor.DTO
{
    public struct MusicDTO
    {
        /// <summary> 楽曲の情報を保持する構造体 </summary>
        [Serializable]
        public struct EditData
        {
            /// <summary> 楽曲のタイトル </summary>
            public string name;
            /// <summary> レーンの数 </summary>
            public int maxBlock;
            /// <summary> 1分間に四分音符を何拍鳴らすか </summary>
            public float BPM;
            /// <summary> 譜面の開始位置 </summary>
            public int offset;
            /// <summary> Noteのメンバ変数を保持する </summary>
            public List<Note> notes;
        }

        /// <summary> Notesの情報を保持する構造体 </summary>
        [Serializable]
        public struct Note
        {
            /// <summary>
            /// 1拍の内にプレイカーソルが何ライン進むか
            /// (LPB値が大きいほどスクロール速度が上がる)
            /// </summary>
            public int LPB;
            /// <summary> 何番目のBeartsか </summary>
            public int num;
            /// <summary> レーンの番号 </summary>
            public int block;
            /// <summary> Noteの種類 </summary>
            public int type;
            /// <summary> NoteDataのメンバ変数を保持する </summary>
            public List<Note> notes;
        }
    }
}