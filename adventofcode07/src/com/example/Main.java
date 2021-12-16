package com.example;

import java.util.ArrayList;

public class Main {

    public static void main(String[] args) {
	// write your code here
        System.out.println("hello");
        DataService d =new DataService();

        ArrayList<Integer> resInt = d.GetContentInt();



        FuelUseCalculator f =new FuelUseCalculator(resInt);

        f.Test();
        Integer res = f.FuelUse();
        System.out.println(res);

        long res2 = f.FuelUse2();
        System.out.println(res2);

    }
}
