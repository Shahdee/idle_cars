using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GUIMan : MonoBehaviour, IUpdatable
{
    public WinViewBase[] allWindows;
    WinControllerBase[] allWinControlles;
    Stack<WinControllerBase> currentWindows = new Stack<WinControllerBase>();
    Queue<WinControllerBase> delayedWindows = new Queue<WinControllerBase>();

     public void Init(){
        InitWindows();
        OpenWindow(WinViewBase.WinType.Gameplay);
    }

    void InitWindows(){
        allWinControlles = new WinControllerBase[allWindows.Length];
        WinControllerBase controller = null;

        for (int i=0; i<allWindows.Length; i++){
            controller = CreateController(allWindows[i]);
            allWinControlles[i] = controller;
            allWindows[i].Init(controller);

            controller.Close();
        }
    }

    WinControllerBase CreateController(WinViewBase window){
        switch(window.windowType){
            case WinViewBase.WinType.Gameplay:
                return new WinGameplayController(window);

            case WinViewBase.WinType.Cars:
                return new WinCarsController(window);

            case WinViewBase.WinType.LevelUp:
                return new WinLevelUpController(window);
        }
        return null;
    }

    public void OpenWindow(WinViewBase.WinType wType){

        Debug.Log("open " + wType);

        var win = GetWindow(wType);
        if (win == null) return;

        if (CanOpenWindow(wType)){
            currentWindows.Push(win);
            win.Open();

            TryOpenDelayedWindow();
        }
        else{
            Debug.Log("add to delayed");
            delayedWindows.Enqueue(win);
        }
    }

    public void CloseWindow(WinControllerBase window){

        Debug.Log("close " + window.view.windowType);

        var win = currentWindows.Peek();
        if (win == window){
            currentWindows.Pop();
            window.Close();

            TryOpenDelayedWindow();

            // bool check for queued windows
            // if no queued => we could unhide window if it was hidden 
        }
    }

    WinControllerBase GetWindow(WinViewBase.WinType wType){
        for (int i=0; i<allWindows.Length; i++)
            if (allWindows[i].windowType == wType)
                return allWindows[i].controller;

        return null;
    }

    bool CanOpenWindow(WinViewBase.WinType wType){
        Debug.Log("can open " + wType);
        switch(wType){
            case WinViewBase.WinType.LevelUp:
                return (currentWindows.Count == 1);

            default:               
                return true;
        }
    }

    void AddWindowToDelayed(WinViewBase window){
        if (window != null){
            Debug.Log("AddWindowToDelayed " + window);
            
        }
    }

    bool TryOpenDelayedWindow(){
        Debug.Log("TryOpenDelayedWindow");
        if (delayedWindows.Count > 0){
            var window = delayedWindows.Dequeue();
            if (window != null){              

                currentWindows.Push(window);
                window.Open();
                return true;    
            }
        }
        return false;
    }
    
    public void UpdateMe(float delta)
    {
        
    }
}
