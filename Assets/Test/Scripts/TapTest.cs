using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTest : MonoBehaviour
{
    private Vector3 touchStartPos;
    private Vector3 touchEndPos;

    float flickTimeLimit = 0.5f;
    private float flickDistance;
    [SerializeField] private float flickRangeDistance = 50.0f;

    private float _fingerId = 0;

    private void Update()
    {
        TouchTest();
    }

    private void TouchTest()
    {
        foreach (Touch touch in Input.touches)
        {
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Moved:
                    break;
                case TouchPhase.Ended:
                    touchEndPos = touch.position;
                    flickDistance = Vector2.Distance(touchStartPos, touchEndPos);
                    Debug.Log(flickDistance);
                    break;
                case TouchPhase.Canceled:
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary> Flick判定の時間</summary>
    private bool FlickJudgment()
    {
        float flickTimer = 0;
        bool isFlick = false;

        flickTimer += Time.deltaTime;
        if (flickTimer < flickTimeLimit)
        {
            isFlick = true;
        }

        return isFlick;
    }
}
