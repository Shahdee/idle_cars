using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Params;

// model 

public class Player 
{
    PlayerParams _params;

    public PlayerParams parameters{
        get{return _params;}
        private set{_params = value;}
    }

    const int defaultPlayerLevel = 1;

    int _currLevel;
    public int currLevel{
        get{return _currLevel;}
        private set{
            _currLevel = value;

            EventMan.OnPlayerLevelChange(currLevel);
        }
    }

    int _currAknowledgedLevel;
     public int currAknowledgedLevel{
        get{return _currAknowledgedLevel;}
        private set{
            _currAknowledgedLevel = value;

            EventMan.OnPlayerAknowledgedLevelChange(currAknowledgedLevel);
        }
    }

    long _currCash;
    public long currCash{
        get{return _currCash;}
        private set{
            _currCash = value;

            EventMan.OnPlayerCashChange(currCash);
        }
    }

    public long GetIncomeMultiplier(){
        return (long)(1 + (currAknowledgedLevel - 1) * parameters.playerLevelMultiplier);
    }

    List<int> boughtCars = new List<int>();
    
    public void LevelUp(){
        currLevel++;
    }

    public void AknowledgeLevel(){
        currAknowledgedLevel = currLevel;
    }

   public void Setup(PlayerParams prms){
       parameters = prms;

       SetParams();
   }

   public void Restore(){
       SetParams();
   }

    // to default 
   void SetParams(){
       currLevel = defaultPlayerLevel;
       currAknowledgedLevel = currLevel;
       currCash = parameters.initialCash;
   }

   public bool hasCar(int carID){
       for (int i=0; i<boughtCars.Count; i++){
           if (boughtCars[i] == carID)
                return true;
       }
        return false;
   }

    // we bought a car 
   public void AddCar(int carID){
       boughtCars.Add(carID);

    //    EventMan.OnPlayerBoughtCar(carID);
   }

   public bool isEnoughCash(long value){
       return (currCash >= value);
   }

   public void AddCash(long value){
       currCash += value;
   }

   public bool TryTakeCash(long value){
        bool enough = isEnoughCash(value);
        if (enough)
            currCash -= value;
       
        return enough;
   }

   public bool TryBuyCar(Car car){
        bool bought = false;

        if (TryTakeCash(car.GetCarPrice())){
            AddCar(car.parameters.id);
            bought = true;
        }
        return bought;
   }

//    public bool TryUpgradeCar(Car car){
//         bool upgraded = false;

//         if (TryTakeCash(car.GetCarUpgradeCost())){
//             upgraded = true;
//         }
//         return upgraded;
//    }
}
