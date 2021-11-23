using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Excel.Core;
using Excel.Exceptions;
using Excel;
using System.Data;
using OfficeOpenXml;

public class FilterUICtrl : MonoBehaviour
{
    public bool test;

    List<FFT_Data> _datas = new List<FFT_Data>();
    // Start is called before the first frame update
    void Start()
    {
        //获取所有数据
        _datas.Clear();
        DataRowCollection rows = ExcelTool.ReadExcel("Assets/Resources/Excel/FFT_all.xlsx");
        for (int i = 1; i < 10; i++)
        {
            _datas.Add(new FFT_Data(rows[i]));
            // _datas[i-1].Log();
        }

    //    Debug.LogError(_datas[0].amountOfCredit.Val);
        // Debug.LogError();
        _datas.Sort((a, b)=>{
            if(a.amountOfCredit.num > b.amountOfCredit.num){
                return -1;
            }
            else if(a.amountOfCredit.num < b.amountOfCredit.num){
                return 1;
            }
            else{
                return 0;
            }
        });
        // Sort();

        for (int i = 0; i < _datas.Count; i++)
        {
            Debug.LogError(_datas[i].amountOfCredit.num + "  "+_datas[i].systemNum );
        }
    }

    //排序
    void Sort(){
        for (int i = 0; i < _datas.Count - 1; i++)
        {
            for (int j = 0; j < _datas.Count - 1 - i; j++)
            {
                if(_datas[i].amountOfCredit.num < _datas[j].amountOfCredit.num){
                    Switch(_datas[i], _datas[j]);
                }
            }
        }

        for (int i = 0; i < _datas.Count; i++)
        {
            Debug.LogError(_datas[i].amountOfCredit.num + "  "+_datas[i].systemNum );
        }
    }

    void Switch(FFT_Data a, FFT_Data b){
        Debug.LogError(a.amountOfCredit.num+  "  "+b.amountOfCredit.num);
        FFT_Data temp = a;
        a = b;
        b = temp;
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if(test){
    //         test = false;
    //         Start();
    //     }
    // }
}
