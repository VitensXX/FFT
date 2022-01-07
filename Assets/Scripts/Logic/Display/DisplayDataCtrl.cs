using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDataCtrl : MonoBehaviour
{
    public Transform gridAnchor;

    public static DisplayDataCtrl Show(Transform parent, List<FFT_Data> datas, System.Action<FFT_Data> cbModify){
        GameObject item = Instantiate(Resources.Load("Prefabs/Display/DisplayData") as GameObject);
        DisplayDataCtrl itemCtrl = item.GetComponent<DisplayDataCtrl>();
        Transform ts = item.transform;
        ts.SetParent(parent);
        Common.NormaliseTransform(ts);
        // ts.localPosition = Vector3.zero;
        // ts.localScale = Vector3.one;
        itemCtrl.Init(datas, cbModify);
        return itemCtrl;
    }

    void Init(List<FFT_Data> datas, System.Action<FFT_Data> cbModify){
        for (int i = 0; i < datas.Count; i++)
        {
            DisplayDataItemCtrl.Show(this, gridAnchor, datas[i], cbModify);
        }
    }

    public void OnClickClose(){
        Destroy(gameObject);
    }
}
