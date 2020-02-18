using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinGameplay : WinViewBase
{
    public Text level; 
    public Text cash;
    public Button btnCars;
    public Button btnTest;

    // TODO 2x button 

    protected override void InInit(){
        btnCars.onClick.AddListener(CarsClick);
        btnTest.onClick.AddListener(TestClick);

    }

    void CarsClick(){
        (controller as WinGameplayController).SendCheckCars();
    }

    void TestClick(){
        (controller as WinGameplayController).SendTest();
    }


    // void SetLives(int lvs){
    //     lives.text = "lives " + lvs.ToString();
    // }

    protected override void OnShow(){

        // int lives = GameMan.instance.GetPlayer().currLives;
        // SetLives(lives);

        // int level = LevelMan.instance.currLevel;
        // SetLevel(level);
    }

    void SetLevel(int lvl){
        // level.text = "level " + (lvl + 1).ToString();
    }
}
