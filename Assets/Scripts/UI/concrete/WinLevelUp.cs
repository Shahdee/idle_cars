using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLevelUp : WinViewBase
{
    public Button btnContinue;

    protected override void InInit(){
        btnContinue.onClick.AddListener(ContinueClick);
    }

    void ContinueClick(){
        (controller as WinLevelUpController).SendContinue();
    }

    protected override void OnShow(){

        // int lives = GameMan.instance.GetPlayer().currLives;
        // SetLives(lives);

        // int level = LevelMan.instance.currLevel;
        // SetLevel(level);
    }

    protected override void OnHide(){
        // instead of disable
        //implement in derived
    }
}

