using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Params{
    [System.Serializable]
    public class CarParams{
        public int id;
        public string name;
        public string prefab;
        public float roundDuration;
        public int carLevelMultiplier;
        public int baseValue;
        public float powerBase; 
    }

    [System.Serializable]
    public class PlayerParams{
        public int initialCash;
        public float boostDuration;
        public float playerLevelMultiplier;
        public int baseValue;
        public float powerBase; 
    }

    // ? do I need it 
    [System.Serializable]
    public class Levels{
        public int cash;
    }
}


