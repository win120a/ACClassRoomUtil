/**
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
**/

import java.io.*;

public class Run implements IWriter{
  private int decrypt(String[] ar){
    int vc = Integer.parseInt(ar[0]);
    int ask = Integer.parseInt(ar[1]);
    int final = vc + ask;
    return final;
  }

  public void execute(int code){
    switch(code){
        case 0:
          Runtime.getRuntime().exec("C:\Windows\System32\logoff.exe");
        case 1:
          Runtime.getRuntime().exec("cmd.exe " + "C:\t.cmd");
        case 2:
          Runtime.getRuntime().exec("cmd.exe " + "C:\t.cmd");
        default:
          return;
    }
  }
  private void writeText(String path,String text){
    File tBatchF = new File(path);
    FileOutputStream tBatchStream = FileOutputStream(tBatchF);
    PrintStream tBatchPStream = new PrintStream(tBatchStream);
    tBatchPStream.append(text);
    tBatchPStream.flush();
    tBatchPStream.close();
  }
  private void writeBR(String p){
    writeText(p, "\n");
  }
  public static void main(String[] a){
    Run thisInstance = new Run();
    if(a[0] == "x" && a[1] == "x"){
      switch(a[3]){
        case "lo":
          thisInstance.execute(0);
          break;
        case "pr":
          thisInstance.execute(1);
          break;
        case "re":
          thisInstance.execute(2);
          break;
        default:
          System.out.print("Invaild Arg!!!");
      }
    }
    else{
      int rv = thisInstance.decrypt(a);
      if(rv >= 5 && !(rv < 0)){
        StringBuffer sb = new StringBuffer();
        sb.append(IWriter.baseCmd);
        sb.append(IWriter.armv7a);
        sb.append(rv);
        writeText("C:\\t.cmd", sb.toString());
        Runtime.getRuntime().exec("cmd.exe " + "C:\t.cmd");
      }
    }
  }
}
