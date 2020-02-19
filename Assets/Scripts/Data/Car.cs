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

    const int defaultCarLevel = 0;

    int _currLevel;
    public int currLevel{
        get{return _currLevel;}
        set{
            _currLevel = value;

            EventMan.OnCarLevelChange(parameters.id, currLevel);
        }
    }

   public void Setup(CarParams prms){
       parameters = prms;

       SetParams();
   }

   public void Restore(){
       SetParams();
   }

   void SetParams(){
       currLevel = defaultCarLevel;
   }

   public void Buy(){
       Upgrade();
   }

   public void Upgrade(){
       currLevel++;
   }

   public long GetCarIncomePerRound(){
       return (currLevel * parameters.carLevelMultiplier);
   }

   public long GetCarPrice(){
       return (long)(parameters.baseValue * Mathf.Pow(parameters.powerBase, currLevel));
   }
}
