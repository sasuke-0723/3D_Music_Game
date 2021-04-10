﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapManager : MonoBehaviour
{
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private float flickTimer = 0.0f; // Flick判定タイマー

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    flickTimer += Time.deltaTime;
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Moved:
                    break;
                case TouchPhase.Ended:
                    touchEndPos = touch.position;
                    //float flickDirection = Vector2.Distance(touchStartPos, touchEndPos);
                    Debug.Log(flickTimer);
                    break;
                case TouchPhase.Canceled:
                    break;
                default:
                    break;
            }
        }
    }

    private void Flick()
    {
        foreach (Touch touch in Input.touches)
        {
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    break;
                case TouchPhase.Ended:
                    touchEndPos = touch.position;
                    break;
                default:
                    break;
            }
        }
    }
}