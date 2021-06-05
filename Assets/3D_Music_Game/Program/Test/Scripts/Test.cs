using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;
using System.Collections.Generic;

public class Test : MonoBehaviour
{
    private void Start()
    {
        Vector3 offset = new Vector3(100, 100, 100);
        float sqrLen = offset.sqrMagnitude;
        Debug.Log(sqrLen);
    }
}