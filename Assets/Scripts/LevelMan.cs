using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Params;

// stadium 
// cars 

public class LevelMan : MonoBehaviour, IUpdatable, IFixUpdatable
{
    public Transform[] trsTrackPath;
    public Transform trsParent; 
    public Transform trsFinishLineArea;

    static LevelMan _instance;
    public static LevelMan instance{
        get{return _instance;}
        private set{_instance = value;}
    }

    List<CarController> stadiumCars = new List<CarController>();

    Vector3[] trackPathPoints;

    const float boostSpeedMultiplier = 2;
    const float normalSpeedMultiplier = 1;

    public Vector3[] GetTrackPathPoints(){
        return trackPathPoints;
    }

    void Awake()
    {
        instance = this;

        trsParent = transform;

        CalcPath();
    }

    void CalcPath(){
        trackPathPoints = new Vector3[trsTrackPath.Length];

        for (int i=0; i<trsTrackPath.Length; i++){
            trackPathPoints[i] = trsTrackPath[i].position;
        }
    }

    Vector3 _worldBounds;
    public Vector3 worldBounds{
        get{return _worldBounds;}
        private set {_worldBounds = value;}
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
        if (GameMan.instance.GetPlayer().TryTakeCash(carModel.GetCarPrice())){

            GameMan.instance.GetPlayer().AddCar(carModel.parameters.id);

            // Debug.Log("car bought");

            carModel.Buy();

            CarController carController = new CarController(carModel);
            stadiumCars.Add(carController);

            carController.AddFinishLineCrossListener(CarCrossedFinishLine);
        }
        else{
            Debug.Log("already have " + carModel.parameters.id);
        }
    }

    public void UpgradeCar(Car carModel){
        if (GameMan.instance.GetPlayer().TryTakeCash(carModel.GetCarPrice())){

             carModel.Upgrade();

            //  Debug.Log("car upgraded");
        }
        else{
            // Debug.Log("not enough cash");
        }
    }

    public void CarCrossedFinishLine(CarController carController){
        long cash = FormulaHandler.GetCarIncomePerRound(carController.model, GameMan.instance.GetPlayer());
        // Debug.Log("car earned " + cash);
        GameMan.instance.GetPlayer().AddCash(cash);
    }

    public void LevelUp(){
        GameMan.instance.GetPlayer().AknowledgeLevel();
    }

    // for x seconds 
    public void BoostCars(){
        ActivateBoost();
    }

    public void UpdatePhysics(float delta){
       
    }

    bool boostActive = false;
    float _boostTimeLeft = 0;
    public float boostTimeLeft{
        get{return _boostTimeLeft;}
        private set{_boostTimeLeft = value;}
    }

    void ActivateBoost(){
        if (stadiumCars.Count == 0){
            // Debug.Log("nothing to boost");
        }
        else{
            boostActive = true;
            boostTimeLeft = GameMan.instance.GetPlayer().parameters.boostDuration;

            ApplyBoostToCars(boostSpeedMultiplier);

            EventMan.OnBoostActivate(boostTimeLeft);
        }
    }

    public bool isBoostActive(){
        return boostActive;
    }

    void ApplyBoostToCars(float value){

        for (int i=0; i<stadiumCars.Count; i++){
            stadiumCars[i].SpeedUp(value);
        }
    }

    public void UpdateMe(float delta){       
        UpdateBoost(delta);
    }

    void UpdateBoost(float delta){

        if (! boostActive) return;

        // Debug.Log("time");

        if (boostTimeLeft > 0){
            boostTimeLeft -= delta;

        }
        else{
            boostActive = false;

            ApplyBoostToCars(normalSpeedMultiplier);

            EventMan.OnBoostDeactivate();
        }
    }
}
