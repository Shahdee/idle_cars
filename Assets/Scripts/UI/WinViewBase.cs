using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinViewBase : MonoBehaviour, IUpdatable
{
    public enum WinType{
        Gameplay,
        Cars,
        LevelUp,
    }

    public Canvas canvas;
    public GraphicRaycaster raycaster;
    public WinType windowType;

    WinControllerBase _controller;
    public WinControllerBase controller{
        get{return _controller;}
        private set{_controller = value;}
    }

    public void Init(WinControllerBase c){
        controller = c;
        gameObject.SetActive(true);
        InInit();
    }

    // is invoked to setup elements of win once in lifetime 
    // like awake or start 
    protected virtual void InInit(){
    }

    bool visible;
    bool firstTime = true;

    public void SetVisible(bool vis){
        if (visible != vis || firstTime){

            visible = vis;
            firstTime = false;

            canvas.enabled = raycaster.enabled = visible;

            if (visible)
                OnShow();
            else
                OnHide();
        }
    }

    public bool isVisibile(){
        return visible;
    }

    // instead of enable
    protected virtual void OnShow(){
    }

    // instead of disable
    protected virtual void OnHide(){
    }

    public virtual void UpdateMe(float deltaTime){
        // implement in derived
    }
}
