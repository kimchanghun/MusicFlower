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

        [SerializeField]
        GameData gameData;
        public GameData Data => gameData;

        // Start is called before the first frame update
        void Start()
        {
            
        }
    }
}