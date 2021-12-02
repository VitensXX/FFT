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

    private void Start() {
        _dataManager = new DataManager();
        _inst = this;
    }

    //点击录入
    public void OnClickEntering(){
        EnteringNormalCtrl.Show(root);
    }

    //导入数据
    public void OnClickImport(){
        //Assets/Resources/Excel/FFT_all.xlsx
        ExcelTool.Import(DataManager.EXCEL_PATH, _dataManager);
    }

    public void OnClickFilter(){
        
    }

    private void Update() {
        dateInfo.text = "当前数据量:"+_dataManager.GetFFTDataCount().ToString()  +"  录入数量:"+_dataManager.enteringDatas.Count; 
    }
}
