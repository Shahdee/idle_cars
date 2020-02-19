using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;


// moves along trajectory 
// can cross a finish line 

public class CarView : ReusableObject
{
   // setloops 
   // OnStepComplete
   // Sets the tween so that it plays at half the speed
   // myTween.timeScale = 0.5f;

   Tween moveTween;

   void Awake(){

     
   }

   public void Launch(float time){
      var points = LevelMan.instance.GetTrackPathPoints();
      moveTween = transform.DOPath(points, time, PathType.CatmullRom, PathMode.Full3D).SetOptions(true);
      moveTween.SetEase(Ease.Linear);
      moveTween.SetLoops(-1, LoopType.Restart);
      moveTween.OnStepComplete(OnFinishLineCross);
   }

   public void SpeedUp(float value){
      moveTween.timeScale = value;
   }

   UnityAction onFinishLineCrossCallback;

   public void AddFinishLineCrossListener(UnityAction listener){
      onFinishLineCrossCallback += listener;
   }

   public void RemoveFinishLineCrossListener(UnityAction listener){
      onFinishLineCrossCallback += listener;
   }
   
   void OnFinishLineCross(){
      if (onFinishLineCrossCallback != null)
         onFinishLineCrossCallback();
   }
   
   public override void ClearForBuffer(){
      RemoveListeners();
   }

   void RemoveListeners(){
        onFinishLineCrossCallback = null;
    }

}
