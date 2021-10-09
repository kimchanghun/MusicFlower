using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MF.Game
{
    //»ó¼Ó

    public class GameManager : Singleton<GameManager>
    {
        [SerializeField]
        GameProperties gameProperties;
        public GameProperties Properties => gameProperties;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            Test();
        }

        [SerializeField]
        GameObject notePrefab;

        void Test()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject g = Instantiate(notePrefab);

                Note note = g.GetComponent<Note>();
                note.NoteType = (NoteTypes)Random.Range(1, 8);
            }
        }
    }

}