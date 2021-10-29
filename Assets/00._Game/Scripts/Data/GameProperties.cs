using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace MF.Game
{
    [Serializable]
    public struct NoteData
    {
        public NoteTypes noteType;  //��ƮŸ��
        public Color color;         //��ƮŸ�Կ� ���� �÷�
        public AudioClip sound;     //��Ʈ�� ����
    }

    [CreateAssetMenu(fileName ="â���̰��ӵ�����", menuName = "â��/���ӵ�����")]  
    public class GameProperties : ScriptableObject
    {
        [SerializeField]
        List<NoteData> noteColors;

        public Color GetNoteColor(NoteTypes noteType)
        {            
            NoteData noteColor = noteColors.FirstOrDefault(noteColor => (noteColor.noteType & NoteTypes.ABC) == noteType);

            return noteColor.color;
        }

        public AudioClip GetNoteAudio(NoteTypes noteType)
        {
            NoteData noteColor = noteColors.FirstOrDefault(noteColor => (noteColor.noteType & NoteTypes.ABC) == noteType);

            return noteColor.sound;
        }
    }
}