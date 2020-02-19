using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameplayController : WinControllerBase
{
    WinGameplay winGameplay;
    public WinGameplayController(WinViewBase v) : base(v){

        winGameplay = view as WinGameplay;

        EventMan.AddPlayerCashChangeListener(PlayerCashChange);
        EventMan.AddPlayerLevelChangeListener(PlayerLevelChange);

        EventMan.AddBoostActivateListener(BoostActivated);
        EventMan.AddBoostDeactivateListener(BoostDeactivated);
    }

    void PlayerCashChange(long value){
        winGameplay.SetCash(value);

    }
    void PlayerLevelChange(int level){
        winGameplay.SetLevel(level);
    }

    protected override void InOpen(){

        long cash = GameMan.instance.GetPlayer().currCash;
        int level = GameMan.instance.GetPlayer().currLevel;

        PlayerCashChange(cash);
        PlayerLevelChange(level);        

        // check boost 

        HandleBoost();

        // GameMan.instance.levelMan.
    }

    void HandleBoost(){
        if (LevelMan.instance.isBoostActive()){
            float timeLeft = LevelMan.instance.boostTimeLeft;
            winGameplay.SetSpeedUpTimer(timeLeft);
        }
        else{
            winGameplay.SetSpeedUpButton();
        }
    }

    void BoostActivated(float timeLeft){

    }

    void BoostDeactivated(){

    }

    public void SendCheckCars(){
        GameMan.instance.GetGUIMan().OpenWindow(WinViewBase.WinType.Cars);
    }

     public void SendTest(){
        GameMan.instance.GetGUIMan().OpenWindow(WinViewBase.WinType.LevelUp);
    }

    public void SendBoostCars(){
         LevelMan.instance.BoostCars();
    }
}
