using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoneyNum
{
    long _num;

    public double Val => _num * 0.01d;
    public long num => _num;

    public MoneyNum(string input){

        try{
            float test = float.Parse(float.Parse(input).ToString("0.00"));
            _num = (long)(test * 100);
            string[] arr = input.Split('.');
            long integerVal = long.Parse(arr[0]) * 100;
            int decimalsVal = arr.Length > 1 ? Mathf.RoundToInt(float.Parse(float.Parse("0."+arr[1]).ToString("0.00")) * 100) : 0;
            _num = integerVal + decimalsVal;
        }
        catch(System.Exception e){
            // Debug.LogError("Erro MoneyNum:"+input);
            // Debug.LogError(e.ToString());
            _num = 0;
        }
    }

    public override string ToString(){
        return Val.ToString("0.00");
    }

    // public static bool operator >(MoneyNum a, MoneyNum b)
    // {
    //     return a._num > b._num;
    // }

}

[System.Serializable]
public class PercentNum{
    int _num;
    public PercentNum(string input){
        try{
            input = input.TrimEnd('%');
            _num = Mathf.RoundToInt(float.Parse(input));
        }
        catch{
            // Debug.LogError("PercentNum:"+input);
            _num = 0;
        }
    }

    public string Val => (_num * 0.01f).ToString("0.00") + "%";

    public override string ToString(){
        return Val;
    }
}
