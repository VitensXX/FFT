using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyNum
{
    long _num;

    public float Val => _num * 0.01f;
    public long num => _num;

    public MoneyNum(string input){

        try{
            float test = float.Parse(float.Parse(input).ToString("0.00"));
            // float.Parse(string.Format("{0:F2}", input));
            // Debug.LogError("mmm:"+input +"      "+string.Format("{0:F2}", input));
            // _num = Mathf.RoundToInt(float.Parse(string.Format("{0:F2}", input)) * 100);
            _num = (long)(test * 100);

            string[] arr = input.Split('.');
            long integerVal = long.Parse(arr[0]) * 100;
            int decimalsVal = arr.Length > 1 ? Mathf.RoundToInt(float.Parse(float.Parse("0."+arr[1]).ToString("0.00")) * 100) : 0;
            _num = integerVal + decimalsVal;
            // Debug.LogError(_num);
        }
        catch(System.Exception e){
            // Debug.LogError("Erro MoneyNum:"+input);
            // Debug.LogError(e.ToString());
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

    // public static bool operator >(MoneyNum a, MoneyNum b)
    // {
    //     return a._num > b._num;
    // }

}

public class PercentNum{
    int _num;
    public PercentNum(string input){
        try{
            input = input.TrimEnd('%');
            _num = Mathf.RoundToInt(float.Parse(input) * 100);
        }
        catch{
            // Debug.LogError("PercentNum:"+input);
            _num = 0;
        }
    }

    public string Val => (_num * 0.01f) + "%";

    public override string ToString(){
        return Val;
    }
}
