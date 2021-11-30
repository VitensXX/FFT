using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;

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
    public string beginDate;//起息日 13
    public string endDate;//到期日 14
    public int extraDate;//宽限期 15
    public int dayCount;//贴现天数 16
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
    public string issuingDate;//开证日期 25
    public string validity;//有效期 26

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
        this.beginDate = dataRow[i++].ToString();
        this.endDate = dataRow[i++].ToString();
        this.extraDate = int.Parse(dataRow[i++].ToString());
        this.dayCount = int.Parse(dataRow[i++].ToString());
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
        this.issuingDate = dataRow[i++].ToString();
        this.validity = dataRow[i++].ToString();
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
