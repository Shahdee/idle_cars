using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameplayController : WinControllerBase
{
    public WinGameplayController(WinViewBase v) : base(v){
       
    }

    public void SendCheckCars(){
        GameMan.instance.GetGUIMan().OpenWindow(WinViewBase.WinType.Cars);
    }

     public void SendTest(){
        GameMan.instance.GetGUIMan().OpenWindow(WinViewBase.WinType.LevelUp);
    }

}
