using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnteringItem_Label : MonoBehaviour, IGetValue
{
    InputField _input;

    public static EnteringItem_Label Show(Transform parent, string title){
        GameObject item = Instantiate(Resources.Load("Prefabs/Entering/EnteringItem_Label") as GameObject);
        EnteringItem_Label itemCtrl = item.GetComponent<EnteringItem_Label>();
        Transform ts = item.transform;
        ts.SetParent(parent);
        ts.localPosition = Vector3.zero;
        ts.localScale = Vector3.one;
        itemCtrl.Init(title);
        return itemCtrl;
    }

    void Init(string title){
        transform.Find("Text").GetComponent<Text>().text = title;
        _input = transform.Find("InputField").GetComponent<InputField>();
    }

    public void SetValue(string val){
        _input.text = val;
    }

    public string GetValue(){
        return _input.text;
    }

}
