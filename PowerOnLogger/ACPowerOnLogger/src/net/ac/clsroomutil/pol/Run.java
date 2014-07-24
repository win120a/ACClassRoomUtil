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

import java.io.*;
import java.util.*;

public class Run implements Logger{
  @Override
  public String getSystemInstallPath(){
    return System.getenv("SystemRoot");
  }

  @Override
  public StringBuilder construct(Run instance, CalendarUtil calu){
    StringBuilder sb = new StringBuilder();
    sb.append(instance.getSystemInstallPath());
    sb.append(Logger.HalfLogPath);
    sb.append(Logger.LogFileName);
    sb.append(calu.getYear());
    sb.append("-");
    sb.append(calu.getMonth());
    sb.append("-");
    sb.append(calu.getDay());
    sb.append("_");
    sb.append(calu.getHour());
    sb.append("H ");
    sb.append(calu.getMinute());
    sb.append("M ");
    sb.append(calu.getSecond());
    sb.append("S_");
    sb.append(calu.getDayOfWeek());
    sb.append(Logger.LogFileSuffix);
    return sb;
  }
  
  @Override
  public void log(StringBuilder builder, Run instance){
    @SuppressWarnings("UnusedAssignment")
    File fileObj = null;
    @SuppressWarnings("UnusedAssignment")
    File folderObj = null;
    try{
      fileObj = new File(builder.toString());
      folderObj = new File(instance.getSystemInstallPath() + 
                           "\\System32\\AC-Engine\\PowerOnLogger");
      if(!(folderObj.exists())){
        folderObj.mkdirs();
      }
      fileObj.createNewFile();
    }
    catch(IOException ioe){
      System.out.println("Something wrong! Message is " + ioe.getMessage());
      System.exit(1);
    } 
  }
  
  public static void main(String[] a){
    Run thisInstance = new Run();
    Calendar cal = Calendar.getInstance();
    CalendarUtil calu = new CalendarUtil(cal);
    StringBuilder sb = thisInstance.construct(thisInstance, calu);
    // System.out.println(sb.toString());
    thisInstance.log(sb, thisInstance);
  }
}