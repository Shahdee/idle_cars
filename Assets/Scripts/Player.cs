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

    int _currLevel;
    public int currLevel{
        get{return _currLevel;}
        private set{_currLevel = value;}
    }

    //cash 

    // bought cars 

    List<int> boughtCars = new List<int>();
    
    // events 

   public void Setup(PlayerParams prms){
       parameters = prms;

       SetParams();
   }

   public void Restore(){
       SetParams();
   }

   void SetParams(){
       // to default 
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

   }

}
