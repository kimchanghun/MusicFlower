using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MF.Game
{
    //���ʸ�... �Ϲ�ȭ Ŭ���� ... Ŭ������ ������.. �׶� �� ���ʸ� Ŭ������ �����... 
    //TŸ���� ������ �Ǵ�.. class, struct..����
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
