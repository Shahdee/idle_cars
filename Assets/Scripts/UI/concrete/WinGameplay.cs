using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinGameplay : WinViewBase
{
    public Text level; 
    public Text cash;
    public CommonButton btnCars;
    public Button btnTest;
    public CommonButton btnBoost;

    protected override void InInit(){
        btnCars.OnBtnClickAddListener(CarsClick);
        btnTest.onClick.AddListener(TestClick);
        btnBoost.OnBtnClickAddListener(BoostClick);
    }

    void CarsClick(CommonButton btn){
        (controller as WinGameplayController).SendCheckCars();
    }

    void TestClick(){
        (controller as WinGameplayController).SendTest();
    }

    void BoostClick(CommonButton btn){
        (controller as WinGameplayController).SendBoostCars();
    }

    bool timerActive = false;
    float currTimeLeft = 0;

    int prevTimeCapped =0;
    int currTimeCapped = 0;

    public void SetSpeedUpTimer(float timeLeft){
        timerActive = true;
        currTimeLeft = timeLeft;
        prevTimeCapped = (int)timeLeft;
        currTimeCapped = 0;
        btnBoost.SetActive(false);
    }

    static string sboost = "boost";

    public void SetSpeedUpButton(){
        timerActive = false;

        btnBoost.SetHeader(sboost);
        btnBoost.SetActive(true);
    }

    public void SetCash(long value){
        cash.text = value.ToString();
    }

    protected override void OnShow(){
       
    }

    public void SetLevel(int lvl){
        level.text = "level " + lvl.ToString();
    }

    public override void UpdateMe(float deltaTime){        
        UpdateTimer(deltaTime);
    }

    void UpdateTimer(float deltaTime){
        if (! timerActive) return;
       
        if (currTimeLeft > 0){
            currTimeLeft -= deltaTime;
        }
        else{
            timerActive = false;      
            currTimeLeft = Mathf.Max(0, currTimeLeft);     
        }

        prevTimeCapped = (int)currTimeLeft;

        if (currTimeCapped != prevTimeCapped){
            currTimeCapped = prevTimeCapped;
            btnBoost.SetHeader(currTimeCapped.ToString());
        }
    }
}
