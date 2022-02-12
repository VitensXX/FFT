
/*=========================================
* Author: springDong
* Description: SpringGUI.DatePicker
* DatePicker has lisened onDayClick/onMonthClick/onYearClick three interfaces .
* You can set date by DateTime property.
==========================================*/

using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SpringGUI
{
    public class DatePicker : UIBehaviour
    {
        private Text _dateText = null;
        private Calendar _calendar = null;
        private DateTime _dateTime = DateTime.Today;

        // get data from this property
        public DateTime DateTime
        {
            get { return _dateTime; }
            set
            {
                _dateTime = value;
                RefreshDateText();
            }
        }

        protected override void Awake()
        {
            _dateText = this.transform.Find("DateText").GetComponent<Text>();
            // _calendar = this.transform.Find("Calendar").GetComponent<Calendar>();
            // _calendar.onDayClick.AddListener(dateTime => { DateTime = dateTime; });
            // transform.Find("PickButtonRay").GetComponent<Button>().onClick.AddListener(( ) =>
            //  { _calendar.gameObject.SetActive(true); });
            // RefreshDateText();
        }

        CalendarDialog _calendarDialog;
        public void OnClickDate(){
            _calendarDialog = CalendarDialog.Show(transform.parent.parent.parent, transform.localPosition);
            _calendar = _calendarDialog.calendar;
            _calendar.onDayClick.AddListener(dateTime => { DateTime = dateTime; });
            // _calendar.transform.Find("PickButtonRay").GetComponent<Button>().onClick.AddListener(( ) =>
            //  { _calendar.gameObject.SetActive(true); });
            // RefreshDateText();
        }

        private void RefreshDateText()
        {
            if (_calendar.DisplayType == E_DisplayType.Standard)
            {
                switch (_calendar.CalendarType)
                {
                    case E_CalendarType.Day:
                        _dateText.text = DateTime.ToShortDateString();
                        break;
                    case E_CalendarType.Month:
                        _dateText.text = DateTime.Year + "/" + DateTime.Month;
                        break;
                    case E_CalendarType.Year:
                        _dateText.text = DateTime.Year.ToString();
                        break;
                }
            }
            else
            {
                switch ( _calendar.CalendarType )
                {
                    case E_CalendarType.Day:
                        _dateText.text = DateTime.Year + "年" + DateTime.Month + "月" + DateTime.Day + "日";
                        break;
                    case E_CalendarType.Month:
                        _dateText.text = DateTime.Year + "年" + DateTime.Month + "月";
                        break;
                    case E_CalendarType.Year:
                        _dateText.text = DateTime.Year + "年";
                        break;
                }
            }
            // _calendar.gameObject.SetActive(false);
            if(_calendarDialog != null){
                _calendarDialog.Close();
            }
        }
    }
}