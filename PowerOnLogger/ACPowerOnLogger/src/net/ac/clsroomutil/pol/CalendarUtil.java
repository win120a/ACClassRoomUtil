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
package net.ac.clsroomutil.pol;

import java.util.*;

public class CalendarUtil implements ICalendarUtil {

    Calendar obj;

    public CalendarUtil(Calendar processObject) {
        obj = processObject;
    }

    /*
     Calendar Object get() returns use in code
     Calendar.MINUTE
     Calendar.MONTH + 1
     Calendar.YEAR
     Calendar.DAY_OF_WEEK // Sunday = 1
     Calendar.DAY_OF_MONTH
     Calendar.SECOND;
     */
    @Override
    public int getYear() {
        return obj.get(Calendar.YEAR);
    }

    @Override
    public int getMonth() {
        int month = obj.get(Calendar.MONTH) + 1;
        return month;
    }

    @Override
    public int getDay() {
        return obj.get(Calendar.DAY_OF_MONTH);
    }

    @Override
    public int getHour() {
        return obj.get(Calendar.HOUR_OF_DAY);
    }

    @Override
    public int getMinute() {
        return obj.get(Calendar.MINUTE);
    }

    @Override
    public int getSecond() {
        return obj.get(Calendar.SECOND);
    }

    @Override
    public String getDayOfWeek() {
        return processDOWReturn(obj.get(Calendar.DAY_OF_WEEK));
    }

    private String processDOWReturn(int originalReturn) {
        switch (originalReturn) {
            case 1:
                return "Sunday";
            case 2:
                return "Monday";
            case 3:
                return "Tuesday";
            case 4:
                return "Wednesday";
            case 5:
                return "Thursday";
            case 6:
                return "Friday";
            case 7:
                return "Saturday";
            default:
                return null;
        }
    }
}
