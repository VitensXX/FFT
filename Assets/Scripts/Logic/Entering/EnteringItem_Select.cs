using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnteringItem_Select : MonoBehaviour, IGetValue
{
    Dropdown _dropDown;

    public static EnteringItem_Select Show(Transform parent, string title){
        GameObject item = Instantiate(Resources.Load("Prefabs/Entering/EnteringItem_Select") as GameObject);
        EnteringItem_Select itemCtrl = item.GetComponent<EnteringItem_Select>();
        Transform ts = item.transform;
        ts.SetParent(parent);
        ts.localPosition = Vector3.zero;
        ts.localScale = Vector3.one;
        itemCtrl.Init(title);
        return itemCtrl;
    }

    void Init(string title){
        transform.Find("Text").GetComponent<Text>().text = title;
        _dropDown = transform.Find("Dropdown").GetComponent<Dropdown>();
        _dropDown.ClearOptions();
        _dropDown.AddOptions(Define.commodityTypes);
    }

    public string GetValue(){
        return Define.commodityTypes[_dropDown.value];
    }

    public void SetValue(string val){
        _dropDown.value = Define.commodityTypes.IndexOf(val);
    }

    public void Clear(){
        _dropDown.value = 0;
    }
}
