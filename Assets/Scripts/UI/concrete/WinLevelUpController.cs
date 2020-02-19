using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLevelUpController : WinControllerBase
{
    WinLevelUp winLevelUp;

    public WinLevelUpController(WinViewBase v) : base(v){

        winLevelUp = view as WinLevelUp;

        EventMan.AddPlayerLevelChangeListener(PlayerLevelChange);
    }

    void PlayerLevelChange(int level){
        float income = GameMan.instance.GetPlayer().GetRealIncomeMultiplier();
        winLevelUp.SetLevel(level);
        winLevelUp.SetIncome(income);
    }

    protected override void InOpen(){
        int level = GameMan.instance.GetPlayer().currLevel;
        float income = GameMan.instance.GetPlayer().GetRealIncomeMultiplier();
        winLevelUp.SetLevel(level);
        winLevelUp.SetIncome(income);
    }

    public void SendContinue(){
        LevelMan.instance.LevelUp();
        GameMan.instance.GetGUIMan().CloseWindow(this);
    }

}

