using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnteringItemCtrl : MonoBehaviour
{
    InputField _input;

    public string inputVal => _input.text;

    public static EnteringItemCtrl Show(Transform parent, string title){
        GameObject item = Instantiate(Resources.Load("Prefabs/Entering/EnteringItem") as GameObject);
        EnteringItemCtrl itemCtrl = item.GetComponent<EnteringItemCtrl>();
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

}
