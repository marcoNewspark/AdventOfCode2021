package com.example;

public class CrabPosition {
    int StartPos;
    int FuelUse;

    public CrabPosition(int startPos) {
        StartPos = startPos;
    }

    public int CalculateFUelUse(int endPos)
    {
        // start = 5, end = 9. fuelUse = 4
        // start = 9, end = 5. fuelUse = 4
        if(StartPos > endPos) {
            FuelUse = StartPos - endPos;
        }
        else {
            FuelUse = endPos - StartPos;
        }

        return FuelUse;
    }

    public long CalculateFUelUse2(int endPos)
    {
        // start = 5, end = 9. fuelUse = 4
        // start = 9, end = 5. fuelUse = 4
        int factor = 1;
        long result = 0;
        if(StartPos > endPos) {
            for(int i = endPos; i < StartPos; i++)
            {
                result = result  + factor;
                factor +=1;
            }
        }
        else {
            for(int i = StartPos; i < endPos; i++)
            {
                result = result + factor;
                factor +=1;
            }
        }

        return result;
    }
}

