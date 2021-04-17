using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    //[SerializeField] GameObject notes;
    //[SerializeField] float notesDirection = -1f;
    //[SerializeField] Transform startPos;
    //[SerializeField] Transform endPoint;
    //[SerializeField] float endTime = 5f;
    //[SerializeField] float currentMusicTime = 0f;
    //[SerializeField] float laneLength = 44f;
    //[SerializeField] float notesSpeed = 1f;

    void Update()
    {
        //currentMusicTime += Time.deltaTime;
        //notes.transform.position = new Vector3(startPos, endPoint - notesDirection * (endTime - currentMusicTime) * laneLength * notesSpeed, 0);
    }
}
