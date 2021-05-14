using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ノートを降らせるクラス
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Note : MonoBehaviour
{
    Rigidbody rigid;
    [SerializeField] static float noteSpeed = 4.0f;
    public static float NoteSpeed { get { return noteSpeed; } }
    float generationPosY;
    float generationPosZ;

    LoadManager load = new LoadManager();
    AudioManager clip;

    void Awake()
    {
        clip = GameObject.Find("MusicSource").GetComponent<AudioManager>();
    }

    void OnEnable()
    {
        noteSpeed = 4f * 158f / 60f;
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;
        rigid.velocity = Vector3.zero;
        generationPosY = transform.position.y;
        generationPosZ = transform.position.z;
    }

    //void Update()
    //{
    //    float posY = generationPosY - (transform.position.y - clip.Music.time) * noteSpeed;
    //    float posZ = generationPosZ - (transform.position.z - clip.Music.time) * noteSpeed;
    //    Vector3 pos = new Vector3(0, posY, posZ);
    //    Vector3 angle = new Vector3(-30, 0, 0);
    //    Vector3 direction = Quaternion.Euler(angle) * pos;
    //    rigid.velocity = direction;
    //}

    void FixedUpdate()
    {
        Vector3 angle = new Vector3(-30, 0, 0);
        Vector3 direction = Quaternion.Euler(angle) * Vector3.back;
        rigid.velocity = direction * noteSpeed;
    }
}
