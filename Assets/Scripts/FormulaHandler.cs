using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FormulaHandler 
{
    public static long GetCarIncomePerRound(Car car, Player player){

        var income = car.GetCarIncomePerRound();
        var multiplier = player.GetIncomeMultiplier();

        return income * multiplier;

    }
}
