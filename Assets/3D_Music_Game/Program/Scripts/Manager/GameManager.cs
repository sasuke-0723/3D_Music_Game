using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] Transform judgmentLine;

    protected override void Awake()
    {
        base.Awake();
    }
}
