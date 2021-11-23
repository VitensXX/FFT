using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Define
{
    public static string[] commodityTypes = new string[]{
        "货物贸易", "服务贸易", "融资租赁"
    };

    //基础录入数据母表表头
    public static string[] EnteringNormalTitles = new string[]{
        "系统编号", "卖出行", "承兑行", "信用证号", "申请人", "受益人", "商品", "信用证期限",
        "发票金额","信用证金额","承兑金额","起息日","到期日","宽限期","贴现天数","手续费率","ftp",
        "综合利率","利息","手续费","费用合计","贴现金额","开证日期","有效期"
    };

    public static int[] EnteringNormalTitlesIndex = new int[]{
        1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,17,18,19,21,22,24,26,28,29
    };

    public static List<int> EnteringNormal_LableIndex = new List<int>{
        1,2,3,4,5,6,7,8, 12,13,14,15,28,29
    };

    public static List<int> EnteringNormal_MoneyIndex = new List<int>{
        9,10,11,21,22,24,26
    };

    public static List<int> EnteringNormal_RateIndex = new List<int>{
        16,17,18,19
    };
}
