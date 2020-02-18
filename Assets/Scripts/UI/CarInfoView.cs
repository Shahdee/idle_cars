using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Params;
using UnityEngine.Events;

// avatar
// level
// name 
// info 
    // roundDuration 
    // incomePerRound 
// buy 
// upgrade 

public class CarInfoView : UIObject
{
    public Image avatar;
    public Text level;
    public Text carName;
    public Text roundDuration;
    public Text incomePerRound;
    public CommonButton btnSpendCash;

    // events 

    void Awake(){
        btnSpendCash.OnBtnClickAddListener(SpendCashClick);
    }

    public UnityAction<CarInfoView> onSpendMoneyCallback;

    public void AddSpendCashListener(UnityAction<CarInfoView> listener){
        onSpendMoneyCallback += listener;
    }

    public void RemoveSpendCashListener(UnityAction<CarInfoView> listener){
        onSpendMoneyCallback -= listener;
    }

    void RemoveListeners(){
        onSpendMoneyCallback = null;
    }

    void OnCashSpent(){
         if (onSpendMoneyCallback != null)
            onSpendMoneyCallback(this);
    }

    void SpendCashClick(CommonButton button){
        OnCashSpent();
    }

    int _carID;
    public int carID{
        get{return _carID;}
        set{_carID = value;}
    }
   
   public void Setup(Car car){

        Debug.Log("Setup " + car.parameters.id);

        carID = car.parameters.id;
        carName.text = car.parameters.name;
        level.text = car.currLevel.ToString();
        roundDuration.text = car.parameters.roundDuration.ToString();
        incomePerRound.text = car.GetCarIncomePerRound().ToString();
   }

   public override void ClearForBuffer(){
       RemoveListeners();
   }
    
}
