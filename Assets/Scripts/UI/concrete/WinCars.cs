using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// scroll with cars 
    // car info 

public class WinCars : WinViewBase
{
    public Button btnBack;
    public Button btnTest;
    public Transform trsScrollParent;
    List<CarInfoView> carInfoViews = new List<CarInfoView>();
    public List<CarInfoView> GetScrollElements(){
        return carInfoViews;
    }

    protected override void InInit(){
        btnBack.onClick.AddListener(BackClick);
        btnTest.onClick.AddListener(TestClick);
    }

    void BackClick(){
        (controller as WinCarsController).SendBack();
    }
    void TestClick(){
        (controller as WinCarsController).SendTest();
    }

    protected override void OnShow(){

       
    }

    public void InitScroll(Car[] cars){

        Debug.Log("init scroll");

        GameObject element;
        CarInfoView view;

        for (int i=0; i<cars.Length; i++){
            element = GameMan.instance.GetEntityMan().GetScrollElement(); // TODO use a better way to handle ui prefabs in entity pool 
            element.SetActive(true);
            view = element.GetComponent<CarInfoView>();
            view.Setup(cars[i]);
            view.rectTransform.SetParent(trsScrollParent);
            view.rectTransform.localPosition = Vector3.zero;

            carInfoViews.Add(view);
        }

        // create enough scroll elements 
        // fill them with data 
        // set initial correct state 
         // lock buttons if we can't spend money on car 
         // unlock if vise verse 
        // put them correctly in scroll
    }

    protected override void OnHide(){
       ResetScroll();
    }

    void ResetScroll(){
        for (int i=0; i<carInfoViews.Count; i++){
            GameMan.instance.GetEntityMan().ReturnEntity(carInfoViews[i]);
        }
        carInfoViews.Clear();
    }
}
