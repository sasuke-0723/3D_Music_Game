using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /// <summary> 楽曲情報 </summary>
    [SerializeField] AudioSource music;
    public AudioSource Music { get { return music; } }
}