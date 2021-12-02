﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//常规输入界面
public class EnteringNormalCtrl : MonoBehaviour
{
    public Transform grid;
    public Transform ftpAnchor;

    List<IGetValue> _enteringItemCtrl = new List<IGetValue>();

    public static EnteringNormalCtrl Show(Transform parent){
        GameObject item = Instantiate(Resources.Load("Prefabs/Entering/EnteringNormal") as GameObject);
        EnteringNormalCtrl ctrl = item.GetComponent<EnteringNormalCtrl>();
        RectTransform ts = (RectTransform)item.transform;
        ts.SetParent(parent);
        ts.offsetMax = Vector2.zero;
        ts.offsetMin = Vector2.zero;
        ts.localScale = Vector3.one;
        ctrl.Init();
        return ctrl;
    }

    void Init()
    {
        _enteringItemCtrl.Clear();
        for (int i = 0; i < Define.EnteringNormalTitles.Length; i++)
        {
            int index = Define.EnteringNormalTitlesIndex[i];
            string title = Define.EnteringNormalTitles[i];

            if(title.Contains("ftp")){
                _enteringItemCtrl.Add(EnteringItem_Rate.Show(ftpAnchor, title));
            }
            else if(title == "商品"){
                _enteringItemCtrl.Add(EnteringItem_Select.Show(grid, title));
            }
            else{
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
        FFT_Data data = new FFT_Data(GetAllInputVals());
        DataManager.inst.enteringDatas.Add(data);
        // ExcelTool.WritExcelOneRow("Assets/Resources/Excel/all_1129.xlsx", 1666, Define.EnteringNormalTitlesIndex, GetAllInputVals());
        // transform.Find("Button/Text").GetComponent<Text>().text = "OK";
    }

    public void OnClickWriteToExcel(){
        int enteringDatasCount = DataManager.inst.enteringDatas.Count;
        if(enteringDatasCount == 0){
            Debug.LogError("没有录入数据, 没法写入");
            return;
        }
        ExcelTool.WriteExcelRows(DataManager.EXCEL_PATH, DataManager.inst.GetFFTDataCount() + 2, 
            enteringDatasCount, DataManager.inst.GetEnteringStr());

        DataManager.inst.PutEnteringToImport();

        Debug.LogError("写入Execel完成");
    }

    public void OnClickBack(){
        GameObject.Destroy(gameObject);
    }
}
