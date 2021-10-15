using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace MF.Game
{
    [Serializable]
    public class GameDataEntity
    {
        public int id;
        public float difficult;
        public float term;
        public int condition_1;
        public int condition_2;
        public string note_00, note_01, note_02, note_03, note_04, note_05, note_06, note_07, note_08, note_09;
        public string note_10, note_11, note_12, note_13, note_14, note_15, note_16, note_17, note_18, note_19;
        public string note_20, note_21, note_22, note_23, note_24, note_25, note_26, note_27, note_28, note_29;
        public string note_30, note_31, note_32, note_33, note_34, note_35, note_36, note_37, note_38, note_39;
  
        public IEnumerable<string> Notes
        {
            get
            {
                return allNotes.Where(note => !string.IsNullOrEmpty(note));
            }
        }



        IEnumerable<string> allNotes    
        {
            get
            {
                yield return note_00;                
                yield return note_01;
                yield return note_02;
                yield return note_03;
                yield return note_04;
                yield return note_05;
                yield return note_06;
                yield return note_07;
                yield return note_08;
                yield return note_09;
                yield return note_10;
                yield return note_11;
                yield return note_12;
                yield return note_13;
                yield return note_14;
                yield return note_15;
                yield return note_16;
                yield return note_17;
                yield return note_18;
                yield return note_19;
                yield return note_20;
                yield return note_21;
                yield return note_22;
                yield return note_23;
                yield return note_24;
                yield return note_25;
                yield return note_26;
                yield return note_27;
                yield return note_28;
                yield return note_29;
                yield return note_30;
                yield return note_31;
                yield return note_32;
                yield return note_33;
                yield return note_34;
                yield return note_35;
                yield return note_36;
                yield return note_37;
                yield return note_38;
                yield return note_39;
            }
        }
    }
}