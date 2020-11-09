using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Debug.Log("押した瞬間");
                    break;
                case TouchPhase.Ended:
                    Debug.Log("離した瞬間");
                    break;
                case TouchPhase.Moved:
                    Debug.Log("長押し");
                    break;
                default:
                    break;
            }
        }
    }
}
