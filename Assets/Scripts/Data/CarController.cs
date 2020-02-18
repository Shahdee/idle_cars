using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public CarController(Car m){
        model = m;

        CreateView();
    }


    void CreateView(){
        GameObject gobject = GameMan.instance.GetEntityMan().GetEntity(model.parameters.prefab);
        gobject.SetActive(true);     
        gobject.transform.SetParent(LevelMan.instance.trsParent); // TODO put correct object

        view = gobject.GetComponent<CarView>();
    }

    void ReleaseView(){
        //
    }
}
