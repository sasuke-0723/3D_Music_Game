using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;
using System.Collections.Generic;

public class Test : MonoBehaviour
{
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log(source.time);
            Debug.Log(source.timeSamples);
        }
    }
}