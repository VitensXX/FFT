using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyNum
{
    long _num;

    public float Val => _num * 0.01f;

    public MoneyNum(string input){

        try{
            Debug.LogError("mmm:"+input);
            _num = (long)(float.Parse(input) * 100);
            Debug.LogError(input+"   "+(float.Parse(input) * 100));
        }
        catch{
            Debug.LogError("MoneyNum:"+input);
            _num = 0;
        }
        // if(input == ""){
        //     _num = 0;
        // }
        // else{
        //     _num = Mathf.RoundToInt(float.Parse(input) * 100);
        // }
    }

    public override string ToString(){
        return Val.ToString("0.00");
    }
}

public class PercentNum{
    int _num;
    public PercentNum(string input){
        try{
            input = input.TrimEnd('%');
            _num = Mathf.RoundToInt(float.Parse(input) * 100);
        }
        catch{
            Debug.LogError("PercentNum:"+input);
            _num = 0;
        }
    }

    public string Val => (_num * 0.01f) + "%";

    public override string ToString(){
        return Val;
    }
}
