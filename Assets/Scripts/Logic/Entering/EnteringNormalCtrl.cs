using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//常规输入界面
public class EnteringNormalCtrl : MonoBehaviour
{
    public Transform grid;
    public Transform ftpAnchor;

    List<IGetValue> _enteringItemCtrl = new List<IGetValue>();

    public static EnteringNormalCtrl Show(Transform parent){
        GameObject item = Instantiate(Resources.Load("Prefabs/Entering/EnteringNormal") as GameObject);
        EnteringNormalCtrl ctrl = item.GetComponent<EnteringNormalCtrl>();
        RectTransform ts = (RectTransform)item.transform;
        ts.SetParent(parent);
        Common.NormaliseTransform(ts);
        ctrl.Init();
        return ctrl;
    }

    void Init()
    {
        _enteringItemCtrl.Clear();
        for (int i = 0; i < Define.EnteringNormalTitles.Length; i++)
        {
            int index = Define.EnteringNormalTitlesIndex[i];
            string title = Define.EnteringNormalTitles[i];

            if(title.Contains("ftp")){
                _enteringItemCtrl.Add(EnteringItem_Rate.Show(ftpAnchor, title));
                continue;
            }
            else if(title == "商品"){
                _enteringItemCtrl.Add(EnteringItem_Select.Show(grid, title));
            }
            else{
                if(Define.EnteringNormal_LableIndex.Contains(index)){
                    _enteringItemCtrl.Add(EnteringItem_Label.Show(grid, title));
                }
                else if(Define.EnteringNormal_MoneyIndex.Contains(index)){
                    _enteringItemCtrl.Add(EnteringItem_Money.Show(grid, title));
                }
                else{
                    _enteringItemCtrl.Add(EnteringItem_Rate.Show(grid, title));
                }
            }
        }

        _inputFields = grid.GetComponentsInChildren<InputField>();
    }

    string[] GetAllInputVals(){
        string[] vals = new string[_enteringItemCtrl.Count];
        for (int i = 0; i < _enteringItemCtrl.Count; i++)
        {
            vals[i] = _enteringItemCtrl[i].GetValue();
        }
        return vals;
    }

    //点击录入
    public void OnClickEntering(){
        FFT_Data data = new FFT_Data(GetAllInputVals());
        DataManager.inst.enteringDatas.Add(data);
        // ExcelTool.WritExcelOneRow("Assets/Resources/Excel/all_1129.xlsx", 1666, Define.EnteringNormalTitlesIndex, GetAllInputVals());
        // transform.Find("Button/Text").GetComponent<Text>().text = "OK";
    }

    public void OnClickWriteToExcel(){
        int enteringDatasCount = DataManager.inst.enteringDatas.Count;
        if(enteringDatasCount == 0){
            Debug.LogError("没有录入数据, 没法写入");
            return;
        }
        ExcelTool.WriteExcelRows(DataManager.EXCEL_PATH, DataManager.inst.GetFFTDataCount() + 2, 
            enteringDatasCount, DataManager.inst.GetEnteringStr());

        DataManager.inst.PutEnteringToImport();

        Debug.LogError("写入Execel完成");
    }

    public void OnClickBack(){
        GameObject.Destroy(gameObject);
    }

    public void OnClickShow(){
        DisplayDataCtrl.Show(transform, DataManager.inst.importDatas, Load);
    }

    public void Load(FFT_Data data){
        int index = 0;
        _enteringItemCtrl[index++].SetValue(data.systemNum);
        _enteringItemCtrl[index++].SetValue(data.saleBank);
        _enteringItemCtrl[index++].SetValue(data.acceptingBank);
        _enteringItemCtrl[index++].SetValue(data.creditNum);
        _enteringItemCtrl[index++].SetValue(data.applicant);
        _enteringItemCtrl[index++].SetValue(data.beneficiary);
        _enteringItemCtrl[index++].SetValue(data.commodity);
        _enteringItemCtrl[index++].SetValue(data.commodityRemark);
        _enteringItemCtrl[index++].SetValue(data.termOfCredit);
        _enteringItemCtrl[index++].SetValue(data.invoiceValue.ToString());
        _enteringItemCtrl[index++].SetValue(data.amountOfCredit.ToString());
        _enteringItemCtrl[index++].SetValue(data.remainMoney.ToString());
        _enteringItemCtrl[index++].SetValue(data.beginDate.ToString());
        _enteringItemCtrl[index++].SetValue(data.endDate.ToString());
        _enteringItemCtrl[index++].SetValue(data.extraDate.ToString());
        _enteringItemCtrl[index++].SetValue(data.chargeRate.ToString());
        _enteringItemCtrl[index++].SetValue(data.ftp.ToString());
        _enteringItemCtrl[index++].SetValue(data.issuingDate.ToString());
        _enteringItemCtrl[index++].SetValue(data.validity.ToString());
    }

    #region 快捷键

    // List<InputField> inputFields = new List<InputField>();
    InputField[] _inputFields;
    int _index;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Tab)){
            int index = GetInputFocusIndex();
            if(index == -1){
                return;
            }
            else{
                index = ++index % _inputFields.Length;
                _inputFields[index].ActivateInputField();
            }

            // _index = ++_index % _inputFields.Length;
        }
    }

    int GetInputFocusIndex(){
        for (int i = 0; i < _inputFields.Length; i++)
        {
            if(_inputFields[i].isFocused){
                return i;
            }
        }

        return -1;
    }

    int GetInputFiledIndex(InputField input){
        for (int i = 0; i < _inputFields.Length; i++)
        {
            if(_inputFields[i] == input){
                return i;
            }
        }

        return 0;
    }
         
    #endregion
}
