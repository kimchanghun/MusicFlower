using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MF.Game
{
    //제너릭... 일반화 클래스 ... 클래스가 들어오면.. 그때 이 제너릭 클래스를 만든다... 
    //T타입의 제한을 건다.. class, struct..조건
    public class Singleton<T> : MonoBehaviour
        where T : Object
    {
        protected static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {                    
                    instance = FindObjectOfType<T>();
                }                
                return instance;
            }
        }
    } 
}
