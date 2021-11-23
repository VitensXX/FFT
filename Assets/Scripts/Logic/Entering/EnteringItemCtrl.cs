using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum EnteringInfoType{
    Label,//文本信息
    Money,//金额，两位小数
    Rate,//百分数，两位小数
}

public class EnteringItemCtrl : MonoBehaviour
{
    InputField _input;

    public string inputVal => _input.text;

    public static EnteringItemCtrl Show(Transform parent, string title, EnteringInfoType enteringInfoType){
        GameObject item = Instantiate(Resources.Load("Prefabs/Entering/EnteringItem") as GameObject);
        EnteringItemCtrl itemCtrl = item.GetComponent<EnteringItemCtrl>();
        Transform ts = item.transform;
        ts.SetParent(parent);
        ts.localPosition = Vector3.zero;
        ts.localScale = Vector3.one;
        itemCtrl.Init(title, enteringInfoType);
        return itemCtrl;
    }

    void Init(string title, EnteringInfoType enteringInfoType){
        transform.Find("Text").GetComponent<Text>().text = title;
        _input = transform.Find("InputField").GetComponent<InputField>();

        //百分号
        GameObject percentSign = transform.Find("Percent").gameObject;
        percentSign.SetActive(enteringInfoType == EnteringInfoType.Rate);
    }

}
