using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCarsController : WinControllerBase
{
    WinCars winCars;

    public WinCarsController(WinViewBase v) : base(v){
        winCars = view as WinCars;

        // TODO  subs to event man 
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
        winCars.InitScroll(cars);

        var elements = winCars.GetScrollElements();
        for (int i=0; i<elements.Count; i++){
            elements[i].AddSpendCashListener(CashSpent);
        }
    }

    void CashSpent(CarInfoView carInfoView){
        Debug.Log("cash spent on " + carInfoView.carID + " / " + carInfoView.carName.text);

        LevelMan.instance.SpendCashOnCar(carInfoView.carID);

        // itemman - get car 
        // upgrade or buy a car 
    }

    protected override void InClose(){

    }

}

