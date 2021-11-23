using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;

//一条福费廷数据
public class FFT_Data
{
    public string systemNum;//系统编号 1
    public string saleBank;//卖出行 2
    public string acceptingBank;//承兑行 3
    public string creditNum;//信用证号 4
    public string applicant;//申请人 5
    public string beneficiary;//受益人 6
    public string commodity;//商品 7
    public string termOfCredit;//信用证期限 8
    public MoneyNum invoiceValue;//发票金额 9
    public MoneyNum amountOfCredit;//信用证金额 10
    public MoneyNum remainMoney;//承兑金额 11
    public string beginDate;//起息日 12
    public string endDate;//到期日 13
    public int extraDate;//宽限期 14
    public int dayCount;//贴现天数 15
    public PercentNum rate;//利率 16
    public PercentNum chargeRate;//手续费率 17
    public PercentNum ftp;// 18
    public PercentNum allRate;//综合利率 19
    // public PercentNum incomeRate;//净收入率 20
    public MoneyNum interest;//利息 21
    public MoneyNum charge;//手续费 22
    public MoneyNum totalCost;//费用合计 24
    // public MoneyNum totalIncome;//经营净收入 25
    public MoneyNum discountAmount;//贴现金额 26
    // public PercentNum transactionPrice;//成交价格 27
    public string issuingDate;//开证日期 28
    public string validity;//有效期 29


    public FFT_Data(DataRow dataRow){
        this.systemNum = dataRow[0].ToString();
        this.saleBank = dataRow[1].ToString();
        this.acceptingBank = dataRow[2].ToString();
        this.creditNum = dataRow[3].ToString();
        this.applicant = dataRow[4].ToString();
        this.beneficiary = dataRow[5].ToString();
        this.commodity = dataRow[6].ToString();
        this.termOfCredit = dataRow[7].ToString();
        this.invoiceValue = new MoneyNum(dataRow[8].ToString());
        this.amountOfCredit = new MoneyNum(dataRow[9].ToString());
        this.remainMoney = new MoneyNum(dataRow[10].ToString());
        this.beginDate = dataRow[11].ToString();
        this.endDate = dataRow[12].ToString();
        this.extraDate = int.Parse(dataRow[13].ToString());
        this.dayCount = int.Parse(dataRow[14].ToString());
        this.rate = new PercentNum(dataRow[15].ToString());
        this.chargeRate = new PercentNum(dataRow[16].ToString());
        this.ftp = new PercentNum(dataRow[17].ToString());
        this.allRate = new PercentNum(dataRow[18].ToString());
        // this.incomeRate = new PercentNum(dataRow[19].ToString());
        this.interest = new MoneyNum(dataRow[20].ToString());
        this.charge = new MoneyNum(dataRow[21].ToString());
        this.totalCost = new MoneyNum(dataRow[23].ToString());
        // this.totalIncome = new MoneyNum(dataRow[24].ToString());
        this.discountAmount = new MoneyNum(dataRow[25].ToString());
        // this.transactionPrice = new PercentNum(dataRow[26].ToString());
        this.issuingDate = dataRow[27].ToString();
        this.validity = dataRow[28].ToString();
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
