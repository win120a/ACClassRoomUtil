/*
   Copyright (C) 2011-2014 AC Inc. (Andy Cheung)

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Windows.Forms;

namespace LPUGUIProvider
{
    class Tools
    {
        public static int GenerateDateOfWeekNumber()
        {
            int num = 0;
            DayOfWeek dow = DateTime.Now.DayOfWeek;
            switch (dow.ToString())
            {
                case "Monday":
                    num = 2;
                    break;
                case "Tuesday":
                    num = 3;
                    break;
                case "Wednesday":
                    num = 4;
                    break;
                case "Thursday":
                    num = 5;
                    break;
                case "Friday":
                    num = 6;
                    break;
                case "Saturday":
                    num = 7;
                    break;
                case "Sunday":
                    num = 1;
                    break;
            }

            return num;
        }

        public static DayOfWeek ReturnTodayInChinese(Label label)
        {
            DayOfWeek dow = DateTime.Now.DayOfWeek;
            switch (dow.ToString())
            {
                case "Monday":
                    label.Text = "今天星期一";
                    break;
                case "Tuesday":
                    label.Text = "今天星期二";
                    break;
                case "Wednesday":
                    label.Text = "今天星期三";
                    break;
                case "Thursday":
                    label.Text = "今天星期四";
                    break;
                case "Friday":
                    label.Text = "今天星期五";
                    break;
                case "Saturday":
                    label.Text = "今天星期六";
                    break;
                case "Sunday":
                    label.Text = "今天星期天";
                    break;
            }

            return dow;
        }
    }
}
