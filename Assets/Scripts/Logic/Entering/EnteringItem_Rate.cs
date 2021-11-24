using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnteringItem_Rate : MonoBehaviour, IGetValue
{
    InputField _input;
    Text _inputText;
    Text _numTip;

    public string inputVal => _input.text;

    public static EnteringItem_Rate Show(Transform parent, string title){
        GameObject item = Instantiate(Resources.Load("Prefabs/Entering/EnteringItem_Rate") as GameObject);
        EnteringItem_Rate itemCtrl = item.GetComponent<EnteringItem_Rate>();
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

    public string GetValue(){
        return _input.text;
    }

}
