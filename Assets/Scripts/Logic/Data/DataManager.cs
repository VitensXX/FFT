using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//所有数据汇总
public class DataManager
{
    public const int ROW_COUNT = 26;
    public const string EXCEL_PATH = "Assets/Resources/Excel/FFT_all.xlsx";
    // public FFT_DataManager fft_DataManager;
    List<FFT_Data> _importDatas = new List<FFT_Data>();
    List<FFT_Data> _enteringDatas = new List<FFT_Data>();//录入的数据 优先存在这里,需要写入excel的时候才会写入

    public static DataManager inst => MainCtrl.inst.dataManager;

    public List<FFT_Data> importDatas => _importDatas;
    public List<FFT_Data> enteringDatas => _enteringDatas;

    public DataManager(){
        // fft_DataManager = Resources.Load<FFT_DataManager>("testAsset");
    }

    //获取当前fft数据个数
    public int GetFFTDataCount(){
        // if(fft_DataManager.datas != null){
        //     return fft_DataManager.datas.Length;   
        // }
        // else{
        //     return 0;
        // }
        return _importDatas.Count;
    }


    public void Import(List<FFT_Data> datas){
        _importDatas = datas;
    }

    public void PutEnteringToImport(){
        _importDatas.AddRange(_enteringDatas);
        _enteringDatas.Clear();
    }

    public string[,] GetEnteringStr(){
        string[,] str = new string[_enteringDatas.Count, ROW_COUNT];
        for (int i = 0; i < _enteringDatas.Count; i++)
        {
            string[] oneDataArr = _enteringDatas[i].GetStrArr();
            for (int j = 0; j < ROW_COUNT; j++)
            {
                str[i,j] = oneDataArr[j];
            }
        }

        return str;
    }
}
