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
   
   public void Setup(Car car, Player player){

        // Debug.Log("Setup " + car.parameters.id);

        carID = car.parameters.id;    

        UpdateInfo(car, player);
   }

   static string sduration = "duration: ";
   static string sincome = "income: ";
   static string slevel = "level: ";

   public void UpdateInfo(Car car, Player player){
        carName.text = car.parameters.name;        
        roundDuration.text = sduration + car.parameters.roundDuration.ToString();

        UpdateDynamicInfo(car, player);
   }    

   public void UpdateDynamicInfo(Car car, Player player){
        bool hasCar = player.hasCar(car.parameters.id);

        level.gameObject.SetActive(hasCar);
        incomePerRound.gameObject.SetActive(hasCar);

        long price = car.GetCarPrice();
        bool enoughCash = player.isEnoughCash(price);

        UpdateSpendCashButton(price, enoughCash);

        if (hasCar){
            level.text = slevel + car.currLevel.ToString();
            var income = FormulaHandler.GetCarIncomePerRound(car, player);
            incomePerRound.text = sincome + income.ToString();            
        }
   }

   void UpdateSpendCashButton(long value, bool enough){
       btnSpendCash.SetActive(enough);
       btnSpendCash.SetHeader(value.ToString()); // TODO format
   }

   public override void ClearForBuffer(){
       RemoveListeners();
   }
    
}
