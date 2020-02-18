using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLevelUpController : WinControllerBase
{
    public WinLevelUpController(WinViewBase v) : base(v){
       
    }

    public void SendContinue(){

        // TODO apply multiplier 

        GameMan.instance.GetGUIMan().CloseWindow(this);
    }

}

