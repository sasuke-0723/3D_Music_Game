using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScreen
{
    /// <summary>
    /// 楽曲を管理するクラス
    /// </summary>
    public class AudioManager : MonoBehaviour
    {
        /// <summary> 楽曲情報 </summary>
        [SerializeField] AudioSource music;
        public AudioSource Music => music;

        public void PlayAudioClip()
        {
            music.Play();
        }
    }
}