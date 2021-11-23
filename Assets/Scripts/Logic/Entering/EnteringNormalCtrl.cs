using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//常规输入界面
public class EnteringNormalCtrl : MonoBehaviour
{
    public Transform grid;

    // string[] titles = new string[]{
    //     "系统编号", "卖出行", "承兑行", "信用证号", "申请人", "受益人", "商品", "信用证期限",
    //     "发票金额","信用证金额","承兑金额","起息日","到期日","宽限期","贴现天数","利率","手续费率","ftp",
    //     "综合利率","利息","手续费","费用合计","贴现金额","开证日期","有效期"
    // };

    // int[] indexs = new int[]{
    //     1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,21,22,24,26,28,29
    // };

    List<EnteringItemCtrl> _enteringItemCtrl = new List<EnteringItemCtrl>();

    void Start()
    {
        _enteringItemCtrl.Clear();
        for (int i = 0; i < Define.EnteringNormalTitles.Length; i++)
        {
            _enteringItemCtrl.Add(EnteringItemCtrl.Show(grid, Define.EnteringNormalTitles[i], EnteringInfoType.Rate));
        }
    }

    string[] GetAllInputVals(){
        string[] vals = new string[_enteringItemCtrl.Count];
        for (int i = 0; i < _enteringItemCtrl.Count; i++)
        {
            vals[i] = _enteringItemCtrl[i].inputVal;
        }
        return vals;
    }

    //点击录入
    public void OnClickEntering(){
        ExcelTool.WritExcelOneRow("Assets/Resources/Excel/FFT_all.xlsx", 30, Define.EnteringNormalTitlesIndex, GetAllInputVals());
    }
}
