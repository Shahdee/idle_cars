using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(ExtendedButton))]
public class CommonButton : UIObject
{
    public Text header;
    public Image icon;
    public Image background;

    ExtendedButton button;

    UnityAction<CommonButton> onBtnClick;

    public void OnBtnClickAddListener(UnityAction<CommonButton> listener){
        onBtnClick += listener;
    }

    void Awake(){
        button = GetComponent<ExtendedButton>();
        button.onClick.AddListener(ButtonClick);
    }

    public void SetHeader(){

    }

    public void SetIcon(){

    }

    public void SetBackground(Color c){

    }

    void ButtonClick(){

        if (onBtnClick != null)
            onBtnClick(this);


        // TODO  play sound 
    }

}
