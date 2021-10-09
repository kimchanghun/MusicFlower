using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace MF.Game
{
    [Serializable]
    public struct NoteColor
    {
        public NoteTypes noteType;  //노트타입
        public Color color;         //노트타입에 대한 컬러
    }

    [CreateAssetMenu(fileName ="창훈이게임데이터", menuName = "창훈/게임데이터")]  
    public class GameProperties : ScriptableObject
    {
        [SerializeField]
        List<NoteColor> noteColors;

        public Color GetNoteColor(NoteTypes noteType)
        {            
            NoteColor noteColor = noteColors.FirstOrDefault(noteColor => noteColor.noteType == noteType);

            return noteColor.color;
        }
    }
}