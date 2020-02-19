using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// scroll with cars 
    // car info 

public class WinCars : WinViewBase
{
    public ScrollRect scrollRect;

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

    public void InitScroll(Car[] cars, Player player){

        Debug.Log("init scroll");

        GameObject element;
        CarInfoView view;

        Vector2 position = new Vector2(0,0);
        float width = 0;
        float height = 0; 

        for (int i=0; i<cars.Length; i++){
            element = GameMan.instance.GetEntityMan().GetScrollElement(); // TODO use a better way to handle ui prefabs in entity pool 
            element.SetActive(true);
            view = element.GetComponent<CarInfoView>();
            view.Setup(cars[i], player);
            
            // Debug.Log("view.rectTransform.sizeDelta " + view.rectTransform.sizeDelta);

            view.rectTransform.SetParent(scrollRect.content);
            view.rectTransform.localScale = Vector3.one;

            width = view.rectTransform.sizeDelta.x;
            height = view.rectTransform.sizeDelta.y;

            position.y = - (i * height + height / 2);
            view.rectTransform.anchoredPosition = position;

            carInfoViews.Add(view);
        }

        // Debug.Log("sizeDelta " + scrollRect.viewport.sizeDelta.y);
        // Debug.Log("rect " + scrollRect.viewport.rect.size.y);

        float contentHeight = cars.Length * height;
        position.y = scrollRect.viewport.rect.size.y - contentHeight;
        

        scrollRect.content.offsetMin = position;
        scrollRect.content.offsetMax = Vector2.zero;

        // create enough scroll elements 
        // fill them with data 
        // set initial correct state 
         // lock buttons if we can't spend money on car 
         // unlock if vise verse 
        // put them correctly in scroll
    }

    public void UpdateScroll(Car[] cars, Player player){

        if (! isVisibile()) return;

        for (int i=0; i<carInfoViews.Count; i++){
            carInfoViews[i].UpdateDynamicInfo(cars[i], player);
        }
    }

    public void UpdateScrollElement(Car car, Player player){
         for (int i=0; i<carInfoViews.Count; i++){
             if (carInfoViews[i].carID == car.parameters.id){
                carInfoViews[i].UpdateDynamicInfo(car, player);
                break;
             }
        }
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
