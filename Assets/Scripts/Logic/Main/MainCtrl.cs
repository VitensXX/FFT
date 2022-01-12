using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCtrl : MonoBehaviour
{
    public Transform root;
    public Text dateInfo;

    static MainCtrl _inst;

    public static MainCtrl inst => _inst;

    DataManager _dataManager;
    public DataManager dataManager => _dataManager;
    bool _imported = false;

    private void Start() {
        _dataManager = new DataManager();
        _inst = this;
        OnClickImport();
    }

    //点击录入
    public void OnClickEntering(){
        EnteringNormalCtrl.Show(root);
    }

    //导入数据
    public void OnClickImport(){
        if(_imported){
            return;
        }
        _imported = true;
        //Assets/Resources/Excel/FFT_all.xlsx
        ExcelTool.Import(DataManager.EXCEL_PATH, _dataManager);
    }

    //写入excel
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

    public void OnClickFilter(){
        
    }

    private void Update() {
        dateInfo.text = "当前数据量:"+_dataManager.GetFFTDataCount().ToString()  +"  录入数量:"+_dataManager.enteringDatas.Count; 
    }
}
