using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarController 
{
    private Car _model;
    public Car model{
        get{return _model;}
        private set{_model = value;}
    }

    private CarView _view;
    public CarView view{
        get{return _view;}
        private set{_view = value;}
    }

    UnityAction<CarController> onCrossFinishLineCallback;

    public void AddFinishLineCrossListener(UnityAction<CarController> listener){
        onCrossFinishLineCallback += listener;
    }

    public void RemoveFinishLineCrossListener(UnityAction<CarController> listener){
        onCrossFinishLineCallback -= listener;
    }

    void OnFinishLineCross(){
        if (onCrossFinishLineCallback != null)
            onCrossFinishLineCallback(this);
    }

    public CarController(Car m){
        model = m;

        CreateView();
        PutCarOnStart();
    }

    void CreateView(){
        GameObject gobject = GameMan.instance.GetEntityMan().GetEntity(model.parameters.prefab);
        gobject.SetActive(true);     
        view = gobject.GetComponent<CarView>();

        view.AddFinishLineCrossListener(CarMadeACircle);
    }

    void CarMadeACircle(){
        OnFinishLineCross();
    }

    void PutCarOnStart(){
        view.transform.SetParent(LevelMan.instance.trsParent); 
        view.transform.position = LevelMan.instance.trsFinishLineArea.position;

        view.Launch(model.parameters.roundDuration);
    }

    public void SpeedUp(float value){
        view.SpeedUp(value);
    }

    void ReleaseView(){
        if (view != null){
            GameMan.instance.GetEntityMan().ReturnEntity(view);
            view = null;
        }   
    }
}
