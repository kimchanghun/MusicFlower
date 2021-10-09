using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MF.Game
{
    public class Points : Singleton<Points>
    {
        //public static Points Instance { get; private set; } //Default Property

        /*
        static Points instance = null;      //정석 Property

        public static Points Instance { 
            get
            {
                if(instance == null)
                {
                    //Points가 존재하는 게임오브젝트를 찾아서 GetComponent<Points>();
                    instance = FindObjectOfType<Points>();  
                }
                
                return instance;
            }            
        } 
        */

        [SerializeField]
        Transform spawnPoint_1;
        public Vector3 SpawnPosition_1 => spawnPoint_1.position;    //생성위치1

        [SerializeField]
        Transform spawnPoint_2;
        public Vector3 SpawnPosition_2 => spawnPoint_2.position;    //생성위치2

        public Vector3 DestinationPosition => transform.position;   //목표지
    } 
}
