package com.example;
import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Collections;

public class FuelUseCalculator {
    private ArrayList<CrabPosition> posArray;
    private Integer minPos;
    private Integer maxPos;

    public FuelUseCalculator(ArrayList<Integer> positions ) {
        posArray = new ArrayList<CrabPosition>();

        minPos = positions.get(0);
        maxPos = positions.get(0);


        for (Integer s : positions
        ) {
            posArray.add(new CrabPosition(s));

            if(s < minPos) { minPos=s;}
            if(s > maxPos) { maxPos = s;}
        }
    }

    public int FuelUse()
    {
        int fuelUse = 999999999;
        int calcFuelUse;
        for(Integer i=minPos; i <= maxPos; i++) {
            calcFuelUse = 0;
            for (CrabPosition p : posArray
            ) {
                calcFuelUse += p.CalculateFUelUse(i);
            }
            if(calcFuelUse < fuelUse) { fuelUse = calcFuelUse; }

        }
        return fuelUse;
    }

    public long FuelUse2()
    {
        long fuelUse = Long.MAX_VALUE;

        long  calcFuelUse;
        for(Integer i=minPos; i <= maxPos; i++) {

            calcFuelUse = 0;
            for (CrabPosition p : posArray
            ) {
                calcFuelUse += p.CalculateFUelUse2(i);
            }
            if(calcFuelUse < fuelUse) { fuelUse = calcFuelUse; }

        }
        return fuelUse;
    }

    public void Test()
    {
        long fuelUse = Long.MAX_VALUE;

        long  calcFuelUse;
        int pos = 5;
            calcFuelUse = 0;
            for (CrabPosition p : posArray
            ) {
                calcFuelUse += p.CalculateFUelUse2(pos);
            }
            if(calcFuelUse < fuelUse) { fuelUse = calcFuelUse; }


    }
}
