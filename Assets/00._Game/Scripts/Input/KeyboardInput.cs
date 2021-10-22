using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MF.Game
{
    public class KeyboardInput : MonoBehaviour
    {
        //Ű���� ��ǲ�� �޾Ƽ� InputManager���� ����
        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                InputManager.Instance.SetKey(NoteTypes.A);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                InputManager.Instance.SetKey(NoteTypes.B);
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                InputManager.Instance.SetKey(NoteTypes.C);
            }
        }
    }

}