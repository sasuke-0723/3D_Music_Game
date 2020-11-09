using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapManager : MonoBehaviour
{
    private Vector3 touchStartPos;
    private Vector3 touchEndPos;

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Debug.Log("Touch: " + touch.fingerId);
                    break;
                case TouchPhase.Stationary:
                    Debug.Log("Hold:" + touch.fingerId);
                    break;
                case TouchPhase.Moved:
                    Debug.Log("Slide:" + touch.fingerId);
                    break;
                case TouchPhase.Ended:
                    Debug.Log("HoldEnd:" + touch.fingerId);
                    break;
                case TouchPhase.Canceled:
                    Debug.Log("Cancel:" + touch.fingerId);
                    break;
                default:
                    break;
            }
        }
    }
}