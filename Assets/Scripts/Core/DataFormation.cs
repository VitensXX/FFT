using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    public MoneyNum(long num){
        _num = num;
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
    float _num;//百分数*100的值 去掉百分号的
    public PercentNum(string input){
        try{
            input = input.TrimEnd('%');
            _num = float.Parse(input);
        }
        catch{
            // Debug.LogError("PercentNum:"+input);
            _num = 0;
        }
    }

    public float num => _num;

    public string Val => _num.ToString("0.00") + "%";


    public override string ToString(){
        return Val;
    }
}

[System.Serializable]
public class IntNum{
    int _num;
    public IntNum(string input){
        try{
            _num = int.Parse(input);
        }
        catch{
            _num = 0;
        }
    }

    public IntNum(int num){
        _num = num;
    }

    public int num => _num;

    public override string ToString()
    {
        return _num.ToString();
    }
}

[System.Serializable]
public class DateNum{
    DateTime _date;
    public DateNum(string input){
        try{
            _date = DateTime.Parse(input);
        }
        catch{
            _date = new DateTime();
        }
    }

    public DateTime date => _date;

    public override string ToString()
    {
        DateTime cur = DateTime.Today;
        return _date.ToString("yyyy/MM/dd");// + "  距离现在多少天:"+ _date.Subtract(cur).Days+"!!!!!!";
    }

    //返回此日期与当天的天数差,正表示此日期还未到,负表示已经超了
    public int GetSubDayToToday(){
        return _date.Subtract(DateTime.Today).Days;
    }

    //得到到期日与起始日之间的天数差
    public static int GetDeltaDay(DateNum begin, DateNum end){
        return end.date.Subtract(begin.date).Days;
    }
}
