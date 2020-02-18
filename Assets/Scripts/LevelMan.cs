using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Params;

// stadium 
// cars 

public class LevelMan : MonoBehaviour, IUpdatable, IFixUpdatable
{
    public Transform trsParent; 
    public Transform trsFinishLineArea;

    static LevelMan _instance;
    public static LevelMan instance{
        get{return _instance;}
        private set{_instance = value;}
    }

    List<CarController> stadiumCars = new List<CarController>();

    void Awake()
    {
        instance = this;

        trsParent = transform;

        SubscribeToEvents();

        CalcWorldBounds();
    }

    void SubscribeToEvents(){

       
    }
    

    Vector3 _worldBounds;
    public Vector3 worldBounds{
        get{return _worldBounds;}
        private set {_worldBounds = value;}
    }

    void CalcWorldBounds(){
        Vector3 vec = new Vector3();
        vec.x = Screen.width;
        vec.y = Screen.height;
        vec.z = Camera.main.transform.position.z;

        worldBounds = Camera.main.ScreenToWorldPoint(vec);

        // Debug.Log("worldBounds " + worldBounds);
    }

    public void StartLevel(){
   
        EventMan.OnGameStart();

    }

    public void SpendCashOnCar(int carID){
        var car = GameMan.instance.GetItemMan().GetCar(carID);
        if (car != null){
            if (GameMan.instance.GetPlayer().hasCar(carID)){
                UpgradeCar(car);
            }
            else{
                BuyCar(car);
            }

        }
    }

    public void BuyCar(Car carModel){

        // get money from player for car 
        // GameMan.instance.GetPlayer().AddCar()

        CarController carController = new CarController(carModel);
        stadiumCars.Add(carController);
       

        // carController.view

        // create controller 
        // add car to player 
        // subscribe to car events 
        // put car correctly on scene 

    }

    public void UpgradeCar(Car car){

    }

    public void LevelUp(){

    }

    // for x seconds 
    public void SpeedUp(){

    }

    public void UpdatePhysics(float delta){

       
    }

    public void UpdateMe(float delta){
       

    }
}
