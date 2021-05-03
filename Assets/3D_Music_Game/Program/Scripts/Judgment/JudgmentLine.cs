using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgmentLine : MonoBehaviour
{
    AudioSource se;

    void Start()
    {
        se = GameObject.Find("SE").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            se.Play();
        }
    }
}
