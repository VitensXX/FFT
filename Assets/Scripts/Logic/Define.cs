using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Define
{
    public static List<string> commodityTypes = new List<string>{
        "货物贸易", "服务贸易", "融资租赁"
    };

    //基础录入数据母表表头
    public static string[] EnteringNormalTitles = new string[]{
        "系统编号1", "卖出行2", "承兑行3", "信用证号4", "申请人5", "受益人6",
        "商品7", "商品备注8", "信用证期限9","发票金额10","信用证金额11","承兑金额12",
        "起息日13","到期日14","宽限期15","手续费率18","ftp19","开证日期25","有效期26"
    };

    public static int[] EnteringNormalTitlesIndex = new int[]{
        1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,18,19,25,26
    };

    public static List<int> EnteringNormal_LableIndex = new List<int>{
        1,2,3,4,5,6,7,8,9,15
    };

    public static List<int> EnteringNormal_MoneyIndex = new List<int>{
        10,11,12
    };

    public static List<int> EnteringNormal_DateIndex = new List<int>{
        13,14,25,26
    };

    public static List<int> EnteringNormal_RateIndex = new List<int>{
        18,19
    };

    static int[] _enteringNormalTitlesIndex;

    public static int[] GetEnteringNormalTitlesIndex(){
        if(_enteringNormalTitlesIndex == null){
            _enteringNormalTitlesIndex = new int[EnteringNormalTitles.Length];
            for (int i = 0; i < _enteringNormalTitlesIndex.Length; i++)
            {
                _enteringNormalTitlesIndex[i] = i+1;
            }
        }

        return _enteringNormalTitlesIndex;
    }
}
