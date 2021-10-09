using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MF.Game
{
    public class Points : Singleton<Points>
    {
        //public static Points Instance { get; private set; } //Default Property

        /*
        static Points instance = null;      //���� Property

        public static Points Instance { 
            get
            {
                if(instance == null)
                {
                    //Points�� �����ϴ� ���ӿ�����Ʈ�� ã�Ƽ� GetComponent<Points>();
                    instance = FindObjectOfType<Points>();  
                }
                
                return instance;
            }            
        } 
        */

        [SerializeField]
        Transform spawnPoint_1;
        public Vector3 SpawnPosition_1 => spawnPoint_1.position;    //������ġ1

        [SerializeField]
        Transform spawnPoint_2;
        public Vector3 SpawnPosition_2 => spawnPoint_2.position;    //������ġ2

        public Vector3 DestinationPosition => transform.position;   //��ǥ��
    } 
}
