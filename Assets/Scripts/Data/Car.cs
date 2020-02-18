using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Params;

// model 

public class Car 
{
    CarParams _params;

    public CarParams parameters{
        get{return _params;}
        private set{_params = value;}
    }

    int _currLevel;
    public int currLevel{
        get{return _currLevel;}
        set{_currLevel = value;}
    }

    // income 
    // upgrade cost
    // events 

   public void Setup(CarParams prms){
       parameters = prms;

       SetParams();
   }

   public void Restore(){
       SetParams();
   }

   void SetParams(){

   }

   public int GetCarIncomePerRound(){
       // TODO - dependancy on player: PlayerLevelMultiplier formula 

       return 13;
   }

   public int GetCarUpgradeCost(){

       return 666;
   }
}
