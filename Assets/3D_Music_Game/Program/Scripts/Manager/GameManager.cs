using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

namespace GameScreen
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [SerializeField] float countDown = 3.0f;
        bool isPlay = false;
        public bool IsPlay { get { return isPlay; } }

        void Update()
        {

        }
    }
}