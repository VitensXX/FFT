using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Excel.Core;
using Excel.Exceptions;
using Excel;
using System.Data;
using OfficeOpenXml;

public class ExcelTool {
 
    /// <summary>
    /// 读取表数据，生成对应的数组
    /// </summary>
    /// <param name="filePath">excel文件全路径</param>
    /// <returns>Item数组</returns>
    // public static Item[] CreateItemArrayWithExcel(string filePath) {
    //     //获得表数据
    //     int columnNum = 0, rowNum = 0;
    //     DataRowCollection collect = ReadExcel(filePath, ref columnNum, ref rowNum);

    //     //根据excel的定义，第二行开始才是数据
    //     Item[] array = new Item[rowNum - 1];
    //     for(int i = 1; i < rowNum; i++) {
    //         Item item = new Item();
    //         //解析每列的数据
    //         item.itemId = uint.Parse(collect[i][0].ToString());
    //         item.itemName = collect[i][1].ToString();
    //         item.itemPrice = uint.Parse(collect[i][2].ToString());
    //         array[i - 1] = item;
    //     }
    //     return array;
    // }

    /// <summary>
    /// 读取excel文件内容
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <param name="columnNum">行数</param>
    /// <param name="rowNum">列数</param>
    // /// <returns></returns>
    // public static DataRowCollection ReadExcel(string filePath, ref int columnNum, ref int rowNum) {
    //     FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
    //     IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

    //     DataSet result = excelReader.AsDataSet();
    //     //Tables[0] 下标0表示excel文件中第一张表的数据
    //     columnNum = result.Tables[0].Columns.Count;
    //     rowNum = result.Tables[0].Rows.Count;

    //     Debug.LogError(result.Tables[0].Columns[1].ToString());
    //     return result.Tables[0].Rows;
    // }

    public static DataRowCollection ReadExcel(string filePath) {
        FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

        DataSet result = excelReader.AsDataSet();
        //Tables[0] 下标0表示excel文件中第一张表的数据
        // columnNum = result.Tables[0].Columns.Count;
        // rowNum = result.Tables[0].Rows.Count;

        // Debug.LogError(result.Tables[0].Rows.Count+" "+result.Tables[0].Columns.Count);
        return result.Tables[0].Rows;
    }

    public static void WriteExcel(string filePath, int row, int col, string val){
        FileInfo xlsxFile = new FileInfo(filePath);
 
        if (xlsxFile.Exists)
        {
            //通过ExcelPackage打开文件
            using (ExcelPackage package = new ExcelPackage(xlsxFile))
            {
                //修改excel的第一个sheet，下标从1开始
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                worksheet.Cells[row, col].Value = val;
                package.Save();
                Debug.Log("WriteToExcel Success");
            }
        }
    }

    public static void WritExcelOneRow(string filePath, int row, int[] cols, string[] vals){
        FileInfo xlsxFile = new FileInfo(filePath);
        if (xlsxFile.Exists){
            using (ExcelPackage package = new ExcelPackage(xlsxFile))
            {
                //修改excel的第一个sheet，下标从1开始
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                for (int i = 0; i < cols.Length; i++)
                {
                    worksheet.Cells[row, cols[i]].Value = vals[i];
                }
                package.Save();
                Debug.Log("WriteToExcel Success");
            }
        }
    }

}
