﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//常规输入界面
public class EnteringNormalCtrl : MonoBehaviour
{
    public Transform grid;
    public Transform ftpAnchor;

    List<IGetValue> _enteringItemCtrl = new List<IGetValue>();

    void Start()
    {
        _enteringItemCtrl.Clear();
        for (int i = 0; i < Define.EnteringNormalTitles.Length; i++)
        {
            int index = Define.EnteringNormalTitlesIndex[i];
            string title = Define.EnteringNormalTitles[i];

            if(title == "ftp"){
                _enteringItemCtrl.Add(EnteringItem_Rate.Show(ftpAnchor, title));
            }else{
                if(Define.EnteringNormal_LableIndex.Contains(index)){
                    _enteringItemCtrl.Add(EnteringItem_Label.Show(grid, title));
                }
                else if(Define.EnteringNormal_MoneyIndex.Contains(index)){
                    _enteringItemCtrl.Add(EnteringItem_Money.Show(grid, title));
                }
                else{
                    _enteringItemCtrl.Add(EnteringItem_Rate.Show(grid, title));
                }
            }
        }
    }

    string[] GetAllInputVals(){
        string[] vals = new string[_enteringItemCtrl.Count];
        for (int i = 0; i < _enteringItemCtrl.Count; i++)
        {
            vals[i] = _enteringItemCtrl[i].GetValue();
        }
        return vals;
    }

    //点击录入
    public void OnClickEntering(){
        ExcelTool.WritExcelOneRow("Assets/Resources/Excel/FFT_all.xlsx", 30, Define.EnteringNormalTitlesIndex, GetAllInputVals());
    }
}
