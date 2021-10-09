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
        public NoteTypes noteType;  //��ƮŸ��
        public Color color;         //��ƮŸ�Կ� ���� �÷�
    }

    [CreateAssetMenu(fileName ="â���̰��ӵ�����", menuName = "â��/���ӵ�����")]  
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