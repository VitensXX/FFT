using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System;

//一条福费廷数据
[System.Serializable]
public class FFT_Data
{
    public string systemNum;//系统编号 1
    public string saleBank;//卖出行 2
    public string acceptingBank;//承兑行 3
    public string creditNum;//信用证号 4
    public string applicant;//申请人 5
    public string beneficiary;//受益人 6
    public string commodity;//商品 7
    public string commodityRemark;//商品备注 8
    public string termOfCredit;//信用证期限 9
    public MoneyNum invoiceValue;//发票金额 10
    public MoneyNum amountOfCredit;//信用证金额 11
    public MoneyNum remainMoney;//承兑金额 12
    public DateNum beginDate;//起息日 13
    public DateNum endDate;//到期日 14
    public IntNum extraDate;//宽限期 15
    public IntNum dayCount;//贴现天数 16
    public PercentNum rate;//利率 17
    public PercentNum chargeRate;//手续费率 18
    public PercentNum ftp;// 19
    public PercentNum allRate;//综合利率 20
    // public PercentNum incomeRate;//净收入率 20
    public MoneyNum interest;//利息 21
    public MoneyNum charge;//手续费 22
    public MoneyNum totalCost;//费用合计 23
    // public MoneyNum totalIncome;//经营净收入 25
    public MoneyNum discountAmount;//贴现金额 24
    // public PercentNum transactionPrice;//成交价格 27
    public DateNum issuingDate;//开证日期 25
    public DateNum validity;//有效期 26

    public FFT_Data(){}

    public FFT_Data(DataRow dataRow){
        int i = 0;
        this.systemNum = dataRow[i++].ToString();
        this.saleBank = dataRow[i++].ToString();
        this.acceptingBank = dataRow[i++].ToString();
        this.creditNum = dataRow[i++].ToString();
        this.applicant = dataRow[i++].ToString();
        this.beneficiary = dataRow[i++].ToString();
        this.commodity = dataRow[i++].ToString();
        this.commodityRemark = dataRow[i++].ToString();
        this.termOfCredit = dataRow[i++].ToString();
        this.invoiceValue = new MoneyNum(dataRow[i++].ToString());
        this.amountOfCredit = new MoneyNum(dataRow[i++].ToString());
        this.remainMoney = new MoneyNum(dataRow[i++].ToString());
        this.beginDate = new DateNum(dataRow[i++].ToString());
        this.endDate = new DateNum(dataRow[i++].ToString());
        this.extraDate = new IntNum(dataRow[i++].ToString());
        this.dayCount = new IntNum(dataRow[i++].ToString());
        this.rate = new PercentNum(dataRow[i++].ToString());
        this.chargeRate = new PercentNum(dataRow[i++].ToString());
        this.ftp = new PercentNum(dataRow[i++].ToString());
        this.allRate = new PercentNum(dataRow[i++].ToString());
        // this.incomeRate = new PercentNum(dataRow[19].ToString());
        this.interest = new MoneyNum(dataRow[i++].ToString());
        this.charge = new MoneyNum(dataRow[i++].ToString());
        this.totalCost = new MoneyNum(dataRow[i++].ToString());
        // this.totalIncome = new MoneyNum(dataRow[24].ToString());
        this.discountAmount = new MoneyNum(dataRow[i++].ToString());
        // this.transactionPrice = new PercentNum(dataRow[26].ToString());
        this.issuingDate = new DateNum(dataRow[i++].ToString());//DateTime.Parse(dataRow[i++].ToString());
        this.validity = new DateNum(dataRow[i++].ToString());//DateTime.Parse(dataRow[i++].ToString());
    }

    public FFT_Data(string[] dataRow){
        int i = 0;
        this.systemNum = dataRow[i++].ToString();
        this.saleBank = dataRow[i++].ToString();
        this.acceptingBank = dataRow[i++].ToString();
        this.creditNum = dataRow[i++].ToString();
        this.applicant = dataRow[i++].ToString();
        this.beneficiary = dataRow[i++].ToString();
        this.commodity = dataRow[i++].ToString();
        this.commodityRemark = dataRow[i++].ToString();
        this.termOfCredit = dataRow[i++].ToString();
        this.invoiceValue = new MoneyNum(dataRow[i++].ToString());
        this.amountOfCredit = new MoneyNum(dataRow[i++].ToString());
        this.remainMoney = new MoneyNum(dataRow[i++].ToString());
        this.beginDate = new DateNum(dataRow[i++].ToString());
        this.endDate = new DateNum(dataRow[i++].ToString());
        this.extraDate = new IntNum(dataRow[i++].ToString());
        //贴现天数 =【到期日】-【起息日】+【宽限期】
        this.dayCount = new IntNum(DateNum.GetDeltaDay(beginDate, endDate) + extraDate.num);

        this.chargeRate = new PercentNum(dataRow[i++].ToString());
        this.ftp = new PercentNum(dataRow[i++].ToString());
        //利率=FTP*1.06，仅保留2位小数 这里的四舍五入是否正确?
        this.rate = new PercentNum((ftp.num * 1.06f).ToString("0.00"));
        
        //综合利率=利率+手续费率
        this.allRate = new PercentNum((rate.num + chargeRate.num).ToString("0.00"));
        //利息=承兑金额*利率*贴现天数/360 这里的四舍五入是否正确?
        this.interest = new MoneyNum((remainMoney.num * dayCount.num * rate.num / 360).ToString("0.00"));
        //手续费=承兑金额*手续费率*贴现天数/360
        this.charge = new MoneyNum((remainMoney.num * dayCount.num * chargeRate.num / 360).ToString("0.00"));
        //费用合计=利率+手续费
        this.totalCost = new MoneyNum((rate.num * charge.num).ToString("0.00"));
        //贴现金额=承兑金额-费用合计
        this.discountAmount = new MoneyNum(remainMoney.num - totalCost.num);
        this.issuingDate = new DateNum(dataRow[i++].ToString());//DateTime.Parse(dataRow[i++].ToString());
        this.validity = new DateNum(dataRow[i++].ToString());//DateTime.Parse(dataRow[i++].ToString());
    }

    public string[] GetStrArr(){
        string[] arr = new string[DataManager.ROW_COUNT];
        int i = 0;
        arr[i++] = systemNum;//1
        arr[i++] = saleBank;//2
        arr[i++] = acceptingBank;//3
        arr[i++] = creditNum;//4
        arr[i++] = applicant;//5
        arr[i++] = beneficiary;//6
        arr[i++] = commodity;//7
        arr[i++] = commodityRemark;//8
        arr[i++] = termOfCredit;//9
        arr[i++] = invoiceValue.ToString();//10
        arr[i++] = amountOfCredit.ToString();//11
        arr[i++] = remainMoney.ToString();//12
        arr[i++] = beginDate.ToString();//13
        arr[i++] = endDate.ToString();//14
        arr[i++] = extraDate.ToString();//15
        arr[i++] = dayCount.ToString();//16
        arr[i++] = rate.ToString();//17
        arr[i++] = chargeRate.ToString();//18
        arr[i++] = ftp.ToString();//19
        arr[i++] = allRate.ToString();//20
        arr[i++] = interest.ToString();//21
        arr[i++] = charge.ToString();//22
        arr[i++] = totalCost.ToString();//23
        arr[i++] = discountAmount.ToString();//24
        arr[i++] = issuingDate.ToString();//25
        arr[i++] = validity.ToString();//26

        return arr;
    }

    // public ParticleSystemRingBufferMode 
    public void Log(){
        Debug.LogError(
            "系统编号:"+systemNum + "  "+
            "卖出行:"+saleBank + "  "+
            "承兑行:"+acceptingBank + "  "+
            "信用证号:"+creditNum + "  "+
            "申请人:"+applicant + "  "+
            "受益人:"+beneficiary + "  "+
            "商品:"+commodity + "  "+
            "商品备注:"+commodityRemark + "  "+
            "信用证期限:"+termOfCredit + "  "+
            "发票金额:"+invoiceValue + "  "+
            "信用证金额:"+amountOfCredit + "  "+
            "承兑金额:"+remainMoney + "  "+
            "起息日:"+beginDate + "  "+
            "到期日:"+endDate + "  "+
            "宽限期:"+extraDate + "  "+
            "贴现天数:"+dayCount + "  "+
            "利率:"+rate + "  "+
            "手续费率:"+chargeRate + "  "+
            "ftp:"+ftp + "  "+
            "综合利率:"+allRate + "  "+
            // "净收入率:"+incomeRate + "  "+
            "利息:"+interest + "  "+
            "手续费:"+charge + "  "+
            "费用合计:"+totalCost + "  "+
            // "经营净收入:"+totalIncome + "  "+
            "贴现金额:"+discountAmount + "  "+
            // "成交价格:"+transactionPrice + "  "+
            "开证日期:"+issuingDate + "  "+
            "有效期:"+validity
        );
    }
}
