using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Params;

public class ItemMan 
{
    Car[] allCars;

    public Car[] GetCars(){
        return allCars;
    }

    public void PrepareItems(GameData data){
        PrepareCars(data);
    }

    void PrepareCars(GameData data){

        allCars = new Car[data.cars.Length];

        for (int i=0; i<allCars.Length; i++){

            allCars[i] = new Car();
            allCars[i].Setup(data.cars[i]);
        }
    }

    public Car GetCar(int carID){
        for (int i=0; i<allCars.Length; i++){
            if (allCars[i].parameters.id == carID)
                return allCars[i];
        }
        return null;
    }

    
}
