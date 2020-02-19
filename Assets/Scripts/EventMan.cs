using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventMan 
{
 
#region Player

    public static UnityAction<long> onPlayerCashChangeCallback;

    public static void AddPlayerCashChangeListener(UnityAction<long> listener){
        onPlayerCashChangeCallback += listener;
    }

    public static void OnPlayerCashChange(long value){
        if (onPlayerCashChangeCallback != null)
            onPlayerCashChangeCallback(value);
    }

    public static UnityAction<int> onPlayerLevelChangeCallback;

    public static void AddPlayerLevelChangeListener(UnityAction<int> listener){
        onPlayerLevelChangeCallback += listener;
    }

    public static void OnPlayerLevelChange(int value){
        if (onPlayerLevelChangeCallback != null)
            onPlayerLevelChangeCallback(value);
    }

     public static UnityAction<int> onPlayerAknowledgedLevelChangeCallback;

    public static void AddPlayerAknowledgedLevelChangeListener(UnityAction<int> listener){
        onPlayerAknowledgedLevelChangeCallback += listener;
    }

    public static void OnPlayerAknowledgedLevelChange(int value){
        if (onPlayerAknowledgedLevelChangeCallback != null)
            onPlayerAknowledgedLevelChangeCallback(value);
    }


#region Car
    // public static UnityAction<int> onPlayerBoughtCarCallback;

    // public static void AddPlayerBoughtCarListener(UnityAction<int> listener){
    //     onPlayerBoughtCarCallback += listener;
    // }

    // public static void OnPlayerBoughtCar(int value){
    //     if (onPlayerBoughtCarCallback != null)
    //         onPlayerBoughtCarCallback(value);
    // }

    public static UnityAction<int> onPlayerUpgradedCarCallback;

    public static void AddPlayerUpgradedCarListener(UnityAction<int> listener){
        onPlayerUpgradedCarCallback += listener;
    }

    public static void OnPlayerUpgradedCar(int value){
        if (onPlayerUpgradedCarCallback != null)
            onPlayerUpgradedCarCallback(value);
    }

   public static UnityAction<int, int> onCarLevelChangeCallback;

    public static void AddCarLevelChangeListener(UnityAction<int, int> listener){
        onCarLevelChangeCallback += listener;
    }

    public static void OnCarLevelChange(int carID, int level){
        if (onCarLevelChangeCallback != null)
            onCarLevelChangeCallback(carID, level);
    }

#endregion

    public static UnityAction<float> onBoostActivateCallback;

    public static void AddBoostActivateListener(UnityAction<float> listener){
        onBoostActivateCallback += listener;
    }

    public static void OnBoostActivate(float timeLeft){
        if (onBoostActivateCallback != null)
            onBoostActivateCallback(timeLeft);
    }

    public static UnityAction onBoostDeactivateCallback;

    public static void AddBoostDeactivateListener(UnityAction listener){
        onBoostDeactivateCallback += listener;
    }

    public static void OnBoostDeactivate(){
        if (onBoostDeactivateCallback != null)
            onBoostDeactivateCallback();
    }

#endregion

}
