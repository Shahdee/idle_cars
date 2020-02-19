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

    Color backgroundColor;
    static Color blocked = new Color(0.5f, 0.5f, 0.5f, 0.5f);

    void Awake(){
        button = GetComponent<ExtendedButton>();
        button.onClick.AddListener(ButtonClick);

        if (background != null)
            backgroundColor = background.color;
    }

    public void SetActive(bool active){
        button.interactable = active;

        if (background != null){
            background.color = active ? backgroundColor : blocked;
        }
    }

    public void SetHeader(string txt){
        header.text = txt;
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
