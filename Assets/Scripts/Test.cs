using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Excel.Core;
using Excel.Exceptions;
using Excel;
using System.Data;
using OfficeOpenXml;
using UnityEditor;

public class Test : MonoBehaviour
{
    List<FFT_Data> datas = new List<FFT_Data>();
    // Start is called before the first frame update
    void Start()
    {
        // DataRowCollection rows = ExcelTool.ReadExcel("Assets/Resources/Excel/FFT_all.xlsx");
        // for (int i = 1; i < 3; i++)
        // {
            // datas.Add(new FFT_Data(rows[i]));
        // }

        // for (int i = 0; i < datas.Count; i++)
        // {
            // datas[1].Log();
        // }

        // FFT_DataManager manager = ScriptableObject.CreateInstance<FFT_DataManager>();
        // manager.datas = new FFT_Data[2000];
        // for (int i = 0; i < 2000; i++)
        // {
        //     FFT_Data data = new FFT_Data();
        //     data.systemNum = i.ToString();
        //     manager.datas[i] = data;
        // }
        // // data.systemNum ="1111";
        // // data.invoiceValue = new MoneyNum("222");
        // // data.ftp = new PercentNum("333");
        // // manager.datas[0] = data;
        // AssetDatabase.CreateAsset(manager, "Assets/Resources/testAsset.asset");
        // AssetDatabase.SaveAssets();
        // AssetDatabase.Refresh();

        // FFT_DataManager manager = Resources.Load<FFT_DataManager>("testAsset");
        // for (int i = 0; i < manager.datas.Length; i++)
        // {
        //     int testId = int.Parse(manager.datas[i].systemNum);
        //     if(testId > 1000 && testId < 1004){
        //         manager.datas[i].Log();
        //     }
        // }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
