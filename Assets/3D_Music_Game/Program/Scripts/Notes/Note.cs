using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Note : MonoBehaviour
{
    Rigidbody rigid;
    [SerializeField] float noteSpeed = 4.0f;
    public float NoteSpeed { get { return noteSpeed; } }

    void OnEnable()
    {
        noteSpeed = 4f * 158f / 60f;
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        Vector3 angle = new Vector3(-30, 0, 0);
        Vector3 direction = Quaternion.Euler(angle) * Vector3.back;
        rigid.velocity = direction * noteSpeed;
    }
}
