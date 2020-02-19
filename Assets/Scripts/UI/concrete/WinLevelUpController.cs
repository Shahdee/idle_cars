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
        winLevelUp.SetLevel(level);
    }

    protected override void InOpen(){
        int level = GameMan.instance.GetPlayer().currLevel;
        winLevelUp.SetLevel(level);
    }

    public void SendContinue(){

        // TODO apply multiplier 

        GameMan.instance.GetGUIMan().CloseWindow(this);
    }

}

