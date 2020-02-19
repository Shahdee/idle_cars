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

    static string sincome = "income X ";
    static string slevel = "level reached ";

    public void SetLevel(int lvl){
        if (! isVisibile()) return;

        level.text = slevel + lvl.ToString();
    }

    public void SetIncome(float value){

        if (! isVisibile()) return;

        income.text = sincome + value.ToString();
    }

    protected override void OnShow(){

      
    }

    protected override void OnHide(){
       
    }
}

