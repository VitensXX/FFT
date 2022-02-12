
using System;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace SpringGUI
{
    public static class SpringGUIDefaultControls
    {
        public struct Resources
        {
            public Sprite standard;
            public Sprite background;
            public Sprite inputField;
            public Sprite knob;
            public Sprite checkmark;
            public Sprite dropdown;
            public Sprite mask;
        }

        private static readonly Vector2 _defaultFunctionalGraphSize = new Vector2(300,300);
        private static readonly Vector2 _defaultPieGraphSize = new Vector2(200,200);
        private static readonly Vector2 _defaultUITreeSize = new Vector2(300 , 400);
        private static readonly Vector2 _defaultUITreeNodeSize = new Vector2(300 , 25);
        private static readonly Vector2 _defaultCalendarSize = new Vector2(220 , 160);
        private static readonly Vector2 _defaultDatePickerSize = new Vector2(180 , 25);
        private static readonly Vector2 _defaultColoredTapeSize = new Vector2(20 , 200);
        private static readonly Vector2 _defaultColorPicker = new Vector2(237 , 421);
        private static readonly Vector2 _defaultRadarMap = new Vector2(250 , 250);
        private static readonly Vector2 _defaultBarChart = new Vector2(450,300);

        private static GameObject CreateUIElementRoot( string name , Vector2 size )
        {
            GameObject child = new GameObject(name);
            RectTransform rectTransform = child.AddComponent<RectTransform>();
            rectTransform.sizeDelta = size;
            return child;
        }

        private static GameObject CreateUIObject( string name ,Transform parent ,Vector2 size  )
        {
            var go = CreateUIObject(name, parent);
            go.GetComponent<RectTransform>().sizeDelta = size;
            return go;
        }
        private static GameObject CreateUIObject( string name ,Transform parent)
        {
            GameObject go = new GameObject(name);
            go.AddComponent<RectTransform>();
            SetParentAndAlign(go,parent);
            return go;
        }
        private static void SetParentAndAlign( GameObject child,Transform parent )
        {
            if(null == parent)
                return;
            child.transform.SetParent(parent,false);
            SetLayerRecursively(child, parent.gameObject.layer);
        }
        private static void SetLayerRecursively(GameObject child,int layer)
        {
            child.layer = layer;
            Transform t = child.transform;
            for ( int i = 0 ; i < t.childCount ; i++ )
                SetLayerRecursively(t.GetChild(i).gameObject , layer);
        }
        private static DefaultControls.Resources convertToDefaultResources( Resources resources )
        {
            DefaultControls.Resources res = new DefaultControls.Resources();
            res.background = resources.background;
            res.checkmark = resources.checkmark;
            res.dropdown = resources.dropdown;
            res.inputField = resources.inputField;
            res.knob = resources.knob;
            res.mask = resources.mask;
            res.standard = resources.standard;
            return res;
        }

        /// <summary>
        /// Create functional graph
        /// </summary>
        /// <returns></returns>
        public static GameObject CreateFunctionalGraph( Resources resources )
        {
            GameObject functionalGraph = CreateUIElementRoot("FunctionalGraph" , _defaultFunctionalGraphSize);
            return functionalGraph;
        }

        /// <summary>
        /// Create pie graph
        /// </summary>
        /// <returns></returns>
        public static GameObject CreatePieGraph( Resources resources )
        {
            GameObject pieGraph = CreateUIElementRoot("PieGraph" , _defaultPieGraphSize);
            return pieGraph;
        }

        /// <summary>
        /// Create Calendar
        /// </summary>
        public static GameObject CreateCalendar( Resources resources )
        {
            DefaultControls.Resources res = convertToDefaultResources(resources);
            #region Create Calendar Container
            //create calendar
            GameObject calendar = DefaultControls.CreateImage(res);
            calendar.name = "Calendar";
            calendar.AddComponent<Calendar>();
            RectTransform calendarRect = calendar.GetComponent<RectTransform>();
            calendarRect.sizeDelta = _defaultCalendarSize;
            #endregion
            #region Create Title

            //create title
            GameObject title = CreateUIObject("Title",calendar.transform);
            RectTransform titleRect = title.GetComponent<RectTransform>();
            titleRect.pivot = new Vector2(0.5f,1);
            titleRect.anchorMin = new Vector2(0,1);
            titleRect.anchorMax = Vector2.one;
            titleRect.sizeDelta = new Vector2(0,30);
            
            //create last button
            GameObject lastButton = DefaultControls.CreateImage(res);
            lastButton.AddComponent<Button>();
            lastButton.GetComponent<Image>().sprite = res.dropdown;
            lastButton.transform.localEulerAngles = new Vector3(0,0,-90);
            lastButton.name = "LastButton";
            SetParentAndAlign(lastButton,title.transform);
            RectTransform lastButtonRect = lastButton.GetComponent<RectTransform>();
            lastButtonRect.anchorMin = new Vector2(0,1);
            lastButtonRect.anchorMax = new Vector2(0,1);
            lastButtonRect.sizeDelta = new Vector2(20,20);
            lastButtonRect.transform.localPosition += new Vector3(15,-15);

            //create next button
            GameObject nextButton = DefaultControls.CreateImage(res);
            nextButton.AddComponent<Button>();
            nextButton.GetComponent<Image>().sprite = res.dropdown;
            nextButton.transform.localEulerAngles = new Vector3(0 , 0 ,90);
            nextButton.name = "NextButton";
            SetParentAndAlign(nextButton , title.transform);
            RectTransform nextButtonRect = nextButton.GetComponent<RectTransform>();
            nextButtonRect.anchorMin = new Vector2(1 , 1);
            nextButtonRect.anchorMax = new Vector2(1 , 1);
            nextButtonRect.sizeDelta = new Vector2(20 , 20);
            nextButtonRect.transform.localPosition += new Vector3(-15 , -15);

            //create time button
            GameObject timeButton = CreateUIObject("TimeButton", title.transform);
            timeButton.AddComponent<Button>();
            RectTransform timeButtonRect = timeButton.GetComponent<RectTransform>();
            timeButtonRect.anchorMin = new Vector2(0.5f , 0);
            timeButtonRect.anchorMax = new Vector2(0.5f , 1);
            timeButtonRect.sizeDelta = new Vector2(160,0);

            //create time button text
            GameObject timeText = DefaultControls.CreateText(res);
            SetParentAndAlign(timeText,timeButton.transform);
            Text indexText = timeText.GetComponent<Text>();
            indexText.alignment = TextAnchor.MiddleCenter;
            indexText.text = DateTime.Now.ToShortDateString();
            RectTransform textRect = timeText.GetComponent<RectTransform>();
            textRect.anchorMin = Vector2.zero;
            textRect.anchorMax = Vector2.one;
            textRect.sizeDelta = Vector2.zero;
            timeButton.GetComponent<Button>().targetGraphic = indexText;

            #endregion
            #region Create Container

            //create container
            GameObject container = DefaultControls.CreateImage(res);
            container.name = "Container";
            SetParentAndAlign(container , calendar.transform);
            RectTransform rectContainer = container.GetComponent<RectTransform>();
            rectContainer.anchorMin = new Vector2(0 , 0.5f);
            rectContainer.anchorMax = new Vector2(1 , 0.5f);
            rectContainer.sizeDelta = new Vector2(-20 , 126);
            rectContainer.localPosition -= new Vector3(0,17);

            //create weeks
            GameObject weeks = DefaultControls.CreateImage(res);
            weeks.name = "Weeks";
            SetParentAndAlign(weeks , container.transform);
            RectTransform weeksRect = weeks.GetComponent<RectTransform>();
            weeksRect.anchorMin = new Vector2(0 , 1);
            weeksRect.anchorMax = Vector2.one;
            weeksRect.pivot = new Vector2(0.5f , 1);
            weeksRect.sizeDelta = new Vector2(0 , 18);
            GridLayoutGroup glg = weeks.AddComponent<GridLayoutGroup>();
            glg.cellSize = new Vector2(26 , 18);
            glg.spacing = new Vector2(3 , 0);
            weeks.GetComponent<Image>().color = Color.gray;
            //create week Text
            GameObject weekText = DefaultControls.CreateText(res);
            weekText.name = "WeekTemplate";
            Text text = weekText.GetComponent<Text>();
            text.alignment = TextAnchor.MiddleCenter;
            text.text = "Sunday";
            SetParentAndAlign(weekText , weeks.transform);

            //create days
            GameObject days = DefaultControls.CreateImage(res);
            days.name = "Days";
            SetParentAndAlign(days , container.transform);
            RectTransform daysRect = days.GetComponent<RectTransform>();
            daysRect.anchorMin = Vector2.zero;
            daysRect.anchorMax = Vector2.one;
            daysRect.sizeDelta = new Vector2(0 , -18);
            daysRect.localPosition -= new Vector3(0 , 9 , 0);
            GridLayoutGroup glg2 = days.AddComponent<GridLayoutGroup>();
            glg2.cellSize = new Vector2(27.7f , 17f);
            glg2.spacing = new Vector2(1 , 1);
            //create day text
            GameObject dayText = DefaultControls.CreateButton(res);
            dayText.name = "DayTemplate";
            dayText.transform.Find("Text").GetComponent<Text>().text = "31";
            dayText.GetComponent<Image>().sprite = null;
            dayText.GetComponent<Image>().color = Color.cyan;
            SetParentAndAlign(dayText , days.transform);

            //create months
            GameObject months = DefaultControls.CreateImage(res);
            months.name = "Months";
            SetParentAndAlign(months , container.transform);
            RectTransform monthRect = months.GetComponent<RectTransform>();
            monthRect.anchorMin = Vector2.zero;
            monthRect.anchorMax = Vector2.one;
            monthRect.sizeDelta = new Vector2(0 , 0);
            GridLayoutGroup glg3 = months.AddComponent<GridLayoutGroup>();
            glg3.cellSize = new Vector2(47 , 36);
            glg3.spacing = new Vector2(4 , 9);
            //create monthText
            GameObject monthText = DefaultControls.CreateButton(res);
            monthText.name = "MonthTemplate";
            monthText.transform.Find("Text").GetComponent<Text>().text = "January";
            monthText.GetComponent<Image>().sprite = null;
            monthText.GetComponent<Image>().color = Color.cyan;
            SetParentAndAlign(monthText , months.transform);
            months.SetActive(false);

            #endregion
            return calendar;
        }

        /// <summary>
        /// Create Date Picker
        /// </summary>
        public static GameObject CreateDatePicker( Resources resources )
        {
            DefaultControls.Resources res = convertToDefaultResources(resources);
            // Create date picker
            GameObject datePicker = DefaultControls.CreateImage(res);
            datePicker.name = "DatePicker";
            datePicker.AddComponent<DatePicker>();
            RectTransform pickerRect = datePicker.GetComponent<RectTransform>();
            pickerRect.sizeDelta = _defaultDatePickerSize;

            // Create date text
            GameObject dateText = DefaultControls.CreateText(res);
            dateText.name = "DateText";
            SetParentAndAlign(dateText , datePicker.transform);
            RectTransform textRect = dateText.GetComponent<RectTransform>();
            textRect.anchorMin = Vector2.zero;
            textRect.anchorMax = new Vector2(0,1);
            textRect.pivot = new Vector2(0,0.5f);
            textRect.sizeDelta = new Vector2(150,0);
            Text textText = dateText.GetComponent<Text>();
            textText.text = System.DateTime.Today.ToShortDateString();
            textText.alignment = TextAnchor.MiddleLeft;

            // Create pick button
            GameObject pickButton = DefaultControls.CreateImage(res);
            pickButton.name = "PickButton";
            SetParentAndAlign(pickButton,datePicker.transform);
            pickButton.AddComponent<Button>();
            RectTransform buttonRect = pickButton.GetComponent<RectTransform>();
            buttonRect.anchorMin = new Vector2(1,0);
            buttonRect.anchorMax = Vector2.one;
            buttonRect.sizeDelta = new Vector2(_defaultDatePickerSize.y,0);
            pickButton.GetComponent<Image>().sprite = res.dropdown;
            buttonRect.transform.localPosition -= new Vector3(_defaultDatePickerSize.y / 2,0,0);

            //Create Calendar
            GameObject calendar = CreateCalendar(resources);
            calendar.transform.SetParent(datePicker.transform);
            calendar.transform.localPosition -= new Vector3(0, _defaultDatePickerSize.y/2+_defaultCalendarSize.y/2, 0);
            calendar.SetActive(false);
            return datePicker;
        }


        /// <summary>
        /// Create Line Chart Graph
        /// </summary>
        /// <param name="resources"></param>
        /// <returns></returns>
        public static GameObject CreateLineChartGraph( Resources resources )
        {
            // line chart 
            GameObject lienChart = CreateUIElementRoot("LineChart" , new Vector2(425 , 200));

            // x axis unit
            GameObject xUnit = DefaultControls.CreateText(convertToDefaultResources(resources));
            xUnit.transform.SetParent(lienChart.transform);
            var xrect = xUnit.GetComponent<RectTransform>();
            xrect.pivot = new Vector2(1 , 0.5f);
            xUnit.transform.localPosition = new Vector3(-215,-100);

            // y axis unit 
            GameObject yUnit = DefaultControls.CreateText(convertToDefaultResources(resources));
            yUnit.transform.SetParent(lienChart.transform);
            var yrect = yUnit.GetComponent<RectTransform>();
            yrect.pivot = new Vector2(0.5f , 0f);
            yrect.transform.localPosition = new Vector3(-212.5f , 105);
            return lienChart;
        }

        /// <summary>
        /// Create Radar Map
        /// </summary>
        /// <param name="resources"></param>
        /// <returns></returns>
        public static GameObject CreateRadarMap( Resources resources )
        {
            GameObject radarmap = CreateUIElementRoot("RadarMap" , _defaultRadarMap);
            return radarmap;
        }

        /// <summary>
        /// Create the bar chart.
        /// </summary>
        /// <returns>The bar chart.</returns>
        /// <param name="resources">Resources.</param>
        public static GameObject CreateBarChart( Resources resources )  
        {
            GameObject barChart = CreateUIElementRoot("BarChart", _defaultBarChart);
            Vector2 size = barChart.GetComponent<RectTransform>().sizeDelta;
            Vector2 origin = new Vector2(-size.x/ 2.0f,-size.y/2.0f);
            //create horizontal unit text template
            GameObject horizontalUnit = DefaultControls.CreateText(convertToDefaultResources(resources));
            horizontalUnit.name = "HorizontalUnitTemplate";
            horizontalUnit.transform.SetParent(barChart.transform);
            RectTransform hRect = horizontalUnit.GetComponent<RectTransform>();
            hRect.pivot = new Vector2(1,0.5f);
            hRect.transform.localPosition = origin + new Vector2(-5,0);
            Text hText = hRect.GetComponent<Text>();
            hText.alignment = TextAnchor.MiddleRight;
            hText.text = "Horizontal Unit";
            //create vertical   unit text template
            GameObject verticalUnit = DefaultControls.CreateText(convertToDefaultResources(resources));
            verticalUnit.name = "VerticalUnitTemplate";
            verticalUnit.transform.SetParent(barChart.transform);
            RectTransform vRect = verticalUnit.GetComponent<RectTransform>();
            vRect.pivot = new Vector2(0.5f,1);
            vRect.transform.localPosition = origin + new Vector2(0,-5);
            Text vText = verticalUnit.GetComponent<Text>();
            vText.alignment = TextAnchor.UpperCenter;
            vText.text = "Vertical Unit";
            return barChart;
        }
    }
}