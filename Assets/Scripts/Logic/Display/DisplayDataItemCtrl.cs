using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDataItemCtrl : MonoBehaviour
{
    public Text infoText;

    public static DisplayDataItemCtrl Show(DisplayDataCtrl parentCtrl, Transform parent, FFT_Data info, System.Action<FFT_Data> cbModify){
        GameObject item = Instantiate(Resources.Load("Prefabs/Display/DisplayDataItem") as GameObject);
        DisplayDataItemCtrl itemCtrl = item.GetComponent<DisplayDataItemCtrl>();
        Transform ts = item.transform;
        ts.SetParent(parent);
        Common.NormaliseTransform(ts);
        itemCtrl.Init(parentCtrl, info, cbModify);
        return itemCtrl;
    }

    System.Action<FFT_Data> _cbModify;
    FFT_Data _data;
    DisplayDataCtrl _parentCtrl;
    void Init(DisplayDataCtrl parentCtrl,FFT_Data info, System.Action<FFT_Data> cbModify){
        infoText.text = info.ToString();
        _cbModify = cbModify;
        _data = info;
        _parentCtrl = parentCtrl;
    }

    public void OnClickModify(){
        _cbModify?.Invoke(_data);
        _parentCtrl.OnClickClose();
    }
}
