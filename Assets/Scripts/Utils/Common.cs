using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common
{
    public static void NormaliseTransform(Transform ts){
        ts.localPosition = Vector3.zero;
        ts.localScale = Vector3.one;
        ts.localEulerAngles = Vector3.zero;

        RectTransform rectTS = ts as RectTransform;
        if(rectTS){
            rectTS.anchoredPosition3D = Vector3.zero;
            rectTS.offsetMax = Vector2.zero;
            rectTS.offsetMin = Vector2.zero;
        }
    }
}
