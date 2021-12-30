using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDataCtrl : MonoBehaviour
{
    public Transform gridAnchor;

    // public static DisplayDataItemCtrl Show(Transform parent, string info){
    //     GameObject item = Instantiate(Resources.Load("Prefabs/Display/DisplayDataItem") as GameObject);
    //     DisplayDataItemCtrl itemCtrl = item.GetComponent<DisplayDataItemCtrl>();
    //     Transform ts = item.transform;
    //     ts.SetParent(parent);
    //     ts.localPosition = Vector3.zero;
    //     ts.localScale = Vector3.one;
    //     itemCtrl.Init(info);
    //     return itemCtrl;
    // }



    public void OnClickClose(){
        Destroy(gameObject);
    }
}
