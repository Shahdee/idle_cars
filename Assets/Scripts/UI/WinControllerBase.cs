using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// concrete view instantiate concrete controller 

public class WinControllerBase
{
    protected WinViewBase _view;
    public WinViewBase view{
        private set{_view = value;}
        get{return _view;}
    }

    public WinControllerBase(){
        
    }

    public WinControllerBase(WinViewBase v){
        view = v;
    }


    public void Open(){
        view.SetVisible(true);
        InOpen();
    }

    public void Close(){
        InClose();
        view.SetVisible(false);
    }

    protected virtual void InOpen(){}
    
   protected virtual void InClose(){}
}
