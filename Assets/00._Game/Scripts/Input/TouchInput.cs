using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MF.Game
{
    public class TouchInput : MonoBehaviour
    {
        [SerializeField]
        NoteTypes noteType;

        private void OnMouseDown()
        {
            InputManager.Instance.SetKey(noteType);
        }
    } 
}
