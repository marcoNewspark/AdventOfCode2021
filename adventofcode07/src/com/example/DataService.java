package com.example;

import java.util.ArrayList;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.rmi.server.ExportException;
import java.util.Collections;

public class DataService {

    private String inFile = "C:\\a\\input2.txt";
    private String content;
    public DataService() {
        try {
            content = new String(Files.readAllBytes(Paths.get(inFile)));
            System.out.println(content);
        }
        catch(Exception ex)
        {}
    }

    ArrayList<Integer> GetContentInt()
    {
        ArrayList<Integer> res = new ArrayList<Integer>();
        for (String s: content.split(","))
        {
            res.add(Integer.parseInt(s));
        }

        return res;
    }

    ArrayList<String> GetContent() {
        String[] s = content.split(",");
        ArrayList<String> res = new ArrayList<String>();
        Collections.addAll(res, s);
        return res;
    }
}
