using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    // specific carinfo view changes
        // buy 
        // upgrade 
        
    // all carinfo view change
        // cash change 
        // aknowledge level up

public class WinCarsController : WinControllerBase
{
    WinCars winCars;

    public WinCarsController(WinViewBase v) : base(v){
        winCars = view as WinCars;

        EventMan.AddCarLevelChangeListener(CarLevelChange);
        EventMan.AddPlayerCashChangeListener(PlayerCashChange);
        // EventMan.AddPlayerAknowledgedLevelChangeListener(PlayerAknowledgeLevelChange);
    }
    
    void CarLevelChange(int carID, int carLevel){
        var car = GameMan.instance.GetItemMan().GetCar(carID);
        winCars.UpdateScrollElement(car, GameMan.instance.GetPlayer());
    }

     // income per round changes
    // void PlayerAknowledgeLevelChange(int level){
    // }

    void PlayerCashChange(long value){
        var cars = GameMan.instance.GetItemMan().GetCars(); 
        winCars.UpdateScroll(cars, GameMan.instance.GetPlayer());
    }

    public void SendBack(){
        GameMan.instance.GetGUIMan().CloseWindow(this);
    }

    public void SendTest(){
        GameMan.instance.GetGUIMan().OpenWindow(WinViewBase.WinType.LevelUp);
    }

    protected override void InOpen(){

        HandleScroll();
        
    }

    void HandleScroll(){
        var cars = GameMan.instance.GetItemMan().GetCars(); // TODO get sorted list of cars for UI 
        winCars.InitScroll(cars, GameMan.instance.GetPlayer());

        var elements = winCars.GetScrollElements();
        for (int i=0; i<elements.Count; i++){
            elements[i].AddSpendCashListener(CashSpent);
        }
    }

    void CashSpent(CarInfoView carInfoView){
        // Debug.Log("cash spent on " + carInfoView.carID + " / " + carInfoView.carName.text);

        LevelMan.instance.SpendCashOnCar(carInfoView.carID);

        // itemman - get car 
        // upgrade or buy a car 
    }

    protected override void InClose(){

    }

}

