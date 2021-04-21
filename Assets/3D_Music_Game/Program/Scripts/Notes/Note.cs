using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Note : MonoBehaviour
{
    Rigidbody rigid;
    float notesSpeed = 3.0f;
    float notesJudgeTime = 3.0f;
    float musicCurrentTime = 0.0f;
    float laneLength = 5.4f;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = Vector3.zero;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {

    }
}
