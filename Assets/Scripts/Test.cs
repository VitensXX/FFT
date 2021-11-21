using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Excel.Core;
using Excel.Exceptions;
using Excel;
using System.Data;
using OfficeOpenXml;

public class Test : MonoBehaviour
{
    List<FFT_Data> datas = new List<FFT_Data>();
    // Start is called before the first frame update
    void Start()
    {
        DataRowCollection rows = ExcelTool.ReadExcel("Assets/Resources/Excel/FFT_all.xlsx");
        for (int i = 1; i < 10; i++)
        {
            datas.Add(new FFT_Data(rows[i]));
        }

        // for (int i = 0; i < datas.Count; i++)
        // {
            datas[0].Log();
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
