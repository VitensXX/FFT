using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpringGUI;

public class CalendarDialog : MonoBehaviour
{
    public Calendar calendar { get; private set;}

    public static CalendarDialog Show(Transform parent, Vector3 pos){
        GameObject dialog = Instantiate(Resources.Load("Prefabs/Entering/CalerdarDialog") as GameObject);
        CalendarDialog dialogCtrl = dialog.GetComponent<CalendarDialog>();
        Transform ts = dialog.transform;
        ts.SetParent(parent);
        ts.localPosition = Vector3.zero;
        ts.localScale = Vector3.one;
        RectTransform rect = ts as RectTransform;
        rect.offsetMax = Vector2.zero;
        rect.offsetMin = Vector2.zero;
        dialogCtrl.Init(pos);
        return dialogCtrl;
    }

    void Init(Vector3 pos){
        calendar = this.transform.Find("CalendarAnchor/Calendar").GetComponent<Calendar>();
        calendar.transform.localPosition = pos;
    }

    public void Close(){
        Destroy(gameObject);
    }
}
