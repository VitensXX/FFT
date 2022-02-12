using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpringGUI;
using System;

public class EnteringItem_Date : MonoBehaviour, IGetValue
{
    InputField _input;

    public static EnteringItem_Date Show(Transform parent, string title){
        GameObject item = Instantiate(Resources.Load("Prefabs/Entering/EnteringItem_Date") as GameObject);
        EnteringItem_Date itemCtrl = item.GetComponent<EnteringItem_Date>();
        Transform ts = item.transform;
        ts.SetParent(parent);
        ts.localPosition = Vector3.zero;
        ts.localScale = Vector3.one;
        itemCtrl.Init(title);
        return itemCtrl;
    }

    DatePicker datePicker;
    void Init(string title){
        transform.Find("Text").GetComponent<Text>().text = title;
        // _input = transform.Find("InputField").GetComponent<InputField>();
        datePicker = GetComponent<DatePicker>();
    }

    public void SetValue(string val){
        // _input.text = val;
        datePicker.DateTime = DateTime.Parse(val);
    }

    public string GetValue(){
        return datePicker.DateTime.ToString("yyyy/MM/dd");
    }

    public void Clear(){
        datePicker.DateTime = DateTime.Today;
        // _input.text = "";
    }

}
