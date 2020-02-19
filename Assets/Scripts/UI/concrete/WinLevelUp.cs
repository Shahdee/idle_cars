using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLevelUp : WinViewBase
{
    public Text level;
    public Text income;
    public CommonButton btnContinue;
    public Button btnBackground;

    protected override void InInit(){
        btnContinue.OnBtnClickAddListener(ContinueClick);
        btnBackground.onClick.AddListener(BackgroundClick);
    }

    void BackgroundClick(){
        ContinueClick(null);
    }

    void ContinueClick(CommonButton btn){
        (controller as WinLevelUpController).SendContinue();
    }

    public void SetLevel(int lvl){
        level.text = "Level " + lvl.ToString() + " reached";
    }

    protected override void OnShow(){

      
    }

    protected override void OnHide(){
       
    }
}

