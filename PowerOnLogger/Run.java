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

import java.io.*;
import java.util.*;

public class Run implements Logger{
  public String getSystemInstallPath(){
    return System.getenv("SystemRoot");
  }

  public static void main(String[] a){
    Run thisInstance = new Run();
    Calendar cal = Calendar.getInstance();
    CalendarUtil calu = new CalendarUtil(cal);
    StringBuilder sb = new StringBuilder();
    sb.append(Logger.LogFileName);
    sb.append(calu.getYear());
    sb.append(calu.getMonth());
    sb.append(calu.getDay());
    sb.append(" ");
    sb.append(calu.getHour());
    sb.append(calu.getMinute());
    sb.append(calu.getSecond());
    sb.append(calu.getDayOfWeek());
    File fileObj = new File(sb.toString());
    File.createNewFile();
  }
}
