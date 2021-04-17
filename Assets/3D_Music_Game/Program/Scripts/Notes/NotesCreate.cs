using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesCreate : ObjectPool
{
    [SerializeField] GameObject tapNotes;
    [SerializeField] GameObject longNotes;
    [SerializeField] int createNotesCount = 100;

    void Start()
    {
        base.CreatePool(tapNotes, createNotesCount);
        base.CreatePool(longNotes, createNotesCount);
    }
}
