using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MF.Game
{
    public class InputManager : Singleton<InputManager>
    {
        public class InputEvent : UnityEvent<NoteTypes> { }
        
        public InputEvent inputEvent = new InputEvent();

        NoteTypes noteTypes = NoteTypes.None;
        bool isSetKeyable = false;
        float time = 0f;
        
        public void SetKey(NoteTypes noteType)
        {
            if(isSetKeyable == false)   //첫번째 키가 들어온거
            {
                time = 0f;
                isSetKeyable = true;
            }

            noteTypes |= noteType;
        }

        private void Update()
        {
            if(isSetKeyable)
            {
                time += Time.deltaTime;
                if (time >= 0.1f)
                {
                    //키를 더이상 받아들이지 않고. 이벤트를 발행한다.
                    inputEvent.Invoke(noteTypes);

                    noteTypes = NoteTypes.None;
                    isSetKeyable = false;
                }
            }
        }
    } 
}
