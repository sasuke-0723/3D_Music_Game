using NoteEditor.DTO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

namespace NoteEditor.Model
{
    public class EditDataDesirializer
    {
        public static void Deserialize(string json)
        {
            var editData = JsonUtility.FromJson<MusicDTO.EditData>(json);
        }
    }
}
