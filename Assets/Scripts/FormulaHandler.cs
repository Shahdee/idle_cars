using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FormulaHandler 
{
    public static long GetCarIncomePerRound(Car car, Player player){

        long income = car.GetCarIncomePerRound();
        float multiplier = player.GetIncomeMultiplier();

        return (long)(income * multiplier);
    }
}
