using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;
using System.Collections.Generic;

public class Test : MonoBehaviour
{
    KeyCode[] keys = new KeyCode[] { KeyCode.A, KeyCode.D, KeyCode.G, KeyCode.J, KeyCode.L };

    private void Update()
    {
        //if (Input.anyKeyDown)
        //{
        //    foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
        //    {
        //        if (Input.GetKeyDown(key))
        //        {
        //            Debug.Log(key);
        //            break;
        //        }
        //    }
        //}
        for (int i = 0; i < keys.Length; i++)
        {
            if (Input.GetKeyDown(keys[i]))
            {
                Debug.Log(keys[i]);
            }
        }
    }
}