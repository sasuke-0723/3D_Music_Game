using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private void Start()
    {
        base.Awake();
    }
}
