using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace MF.Game
{
    [ExcelAsset]
    public class GameData : ScriptableObject
    {
        public List<GameDataEntity> Entities;

        public GameDataEntity SelectRandomOne()
        {
            int random = UnityEngine.Random.Range(0, Entities.Count);
            return Entities[random];
        }
    } 
}
