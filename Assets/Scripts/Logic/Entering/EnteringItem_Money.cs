using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnteringItem_Money : MonoBehaviour, IGetValue
{
    InputField _input;
    Text _inputText;
    Text _numTip;

    public static EnteringItem_Money Show(Transform parent, string title){
        GameObject item = Instantiate(Resources.Load("Prefabs/Entering/EnteringItem_Money") as GameObject);
        EnteringItem_Money itemCtrl = item.GetComponent<EnteringItem_Money>();
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
        _numTip = transform.Find("numTip").GetComponent<Text>();
    }

    public string GetValue(){
        return _input.text;
    }

    public void SetValue(string val){
        _input.text = val;
    }

    private void Update() {
        string inputStr = _input.text;
        if(!string.IsNullOrEmpty(inputStr)){
            MoneyNum money = new MoneyNum(inputStr);
            _numTip.text = string.Format("{0:N}", money.num / 100.0d);
        }
        else{
            _numTip.text = string.Format("{0:N}", 0);
        }
    }
}
